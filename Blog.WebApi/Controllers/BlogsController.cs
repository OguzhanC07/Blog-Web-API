﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Business.Interfaces;
using Blog.DTO.DTOs.BlogDtos;
using Blog.DTO.DTOs.CategoryBlogDtos;
using Blog.Entities.Concrete;
using Blog.WebApi.CustomFilters;
using Blog.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IBlogService _blogService;
        public BlogsController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<BlogListDto>>(await _blogService.GetAllSortedByPostedtimeAsync()));
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Blogg>))]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<BlogListDto>(await _blogService.FindByIdAsync(id)));
        }

        [HttpPost]
        [Authorize]
        [ValidModel]
        public async Task<IActionResult> Create([FromForm]BlogAddModel blogAddModel)
        {
            var uploadModel = await UploadFileAsync(blogAddModel.Image, "image/jpeg");

            if (uploadModel.UploadState == Enums.UploadState.Success)
            {
                blogAddModel.ImagePath = uploadModel.NewName;
                await _blogService.AddAsync(_mapper.Map<Blogg>(blogAddModel));
                return Created("", blogAddModel);
            }
            else if (uploadModel.UploadState == Enums.UploadState.NotExist)
            {
                await _blogService.AddAsync(_mapper.Map<Blogg>(blogAddModel));
                return Created("", blogAddModel);
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        [ValidModel]
        [ServiceFilter(typeof(ValidId<Blogg>))]
        public async Task<IActionResult> Update(int id , [FromForm]BlogUpdateModel blogUpdateModel)
        {
            if (id != blogUpdateModel.Id)
                return BadRequest("Geçersiz id");

            var uploadModel = await UploadFileAsync(blogUpdateModel.Image, "image/jpeg");

            if (uploadModel.UploadState == Enums.UploadState.Success)
            {
                var updatedBlog= await _blogService.FindByIdAsync(blogUpdateModel.Id);
                
                updatedBlog.ShortDesc = blogUpdateModel.ShortDesc;
                updatedBlog.Title = blogUpdateModel.Title;
                updatedBlog.Description = blogUpdateModel.Description;
                updatedBlog.ImagePath = uploadModel.NewName;
                await _blogService.UpdateAsync(updatedBlog);
                return NoContent();
            }
            else if (uploadModel.UploadState == Enums.UploadState.NotExist)
            {
                var updatedBlog = await _blogService.FindByIdAsync(blogUpdateModel.Id);
                updatedBlog.ShortDesc = blogUpdateModel.ShortDesc;
                updatedBlog.Title = blogUpdateModel.Title;
                updatedBlog.Description = blogUpdateModel.Description;
                
                await _blogService.UpdateAsync(updatedBlog);
                return NoContent();
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        [ServiceFilter(typeof(ValidId<Blogg>))]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _blogService.FindByIdAsync(id);
            if (result==null)
            {
                return BadRequest("Geçersiz id");
            }
            else
            {
                await _blogService.RemoveAsync(new Blogg { Id=id});
                return NoContent();
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> AddToCategory(CategoryBlogDto categoryBlogDto)
        {
            await _blogService.AddToCategoryAsync(categoryBlogDto);
            return Created("", categoryBlogDto);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveFromCategory(CategoryBlogDto categoryBlogDto)
        {
            await _blogService.RemoveFromCategoryAsync(categoryBlogDto);
            return NoContent();
        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> GetAllByCategoryId(int id)
        {
            return Ok(await _blogService.GetAllByCategoryIdAsync(id));
        }


    }
}

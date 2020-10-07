using AutoMapper;
using Blog.DTO.DTOs.BlogDtos;
using Blog.DTO.DTOs.CategoryDtos;
using Blog.DTO.DTOs.CommentDtos;
using Blog.Entities.Concrete;
using Blog.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebApi.Mapping.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Blog
            CreateMap<BlogListDto, Blogg>();
            CreateMap<Blogg, BlogListDto>();

            CreateMap<BlogUpdateModel, Blogg>();
            CreateMap<Blogg, BlogUpdateModel>();
            
            CreateMap<BlogAddModel, Blogg>();
            CreateMap<Blogg, BlogAddModel>();
            #endregion


            #region Category
            CreateMap<CategoryAddDto, Category>();
            CreateMap<Category, CategoryAddDto>();

            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryUpdateDto>();

            CreateMap<CategoryListDto, Category>();
            CreateMap<Category, CategoryListDto>();
            #endregion


            #region Comment
            CreateMap<Comment, CommentListDto>();
            CreateMap<CommentListDto, Comment>();

            CreateMap<Comment, CommentAddDto>();
            CreateMap<CommentAddDto, Comment>();
            #endregion


        }
    }
}

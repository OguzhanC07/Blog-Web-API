using Blog.Business.Interfaces;
using Blog.DataAccess.Interfaces;
using Blog.DTO.DTOs.CategoryBlogDtos;
using Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Concrete
{
    public class BlogManager : GenericManager<Blogg>, IBlogService
    {
        private readonly IGenericDal<Blogg> _genericDal;
        private readonly IGenericDal<CategoryBlog> _categoryDal;
        private readonly IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal, IGenericDal<Blogg> genericDal, IGenericDal<CategoryBlog> categoryDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _categoryDal = categoryDal;
            _blogDal = blogDal;
        }

        public async Task<List<Blogg>> GetAllSortedByPostedtimeAsync()
        {
            return await _genericDal.GetAllAsync(I => I.PostedTime);
        }
        public async Task AddToCategoryAsync(CategoryBlogDto categoryBlogDto)
        {
            var control = await _categoryDal.GetAsync(I=>I.BlogId==categoryBlogDto.BlogId && I.CategoryId==categoryBlogDto.CategoryId);
            if (control == null)
            {
                await _categoryDal.AddAsync(new CategoryBlog { BlogId = categoryBlogDto.BlogId, CategoryId = categoryBlogDto.CategoryId });
            }
        }


        public async Task RemoveFromCategoryAsync(CategoryBlogDto categoryBlogDto)
        {
            var deletedCategory = await _categoryDal.GetAsync(I => I.CategoryId == categoryBlogDto.CategoryId && I.BlogId == categoryBlogDto.BlogId);

            if (deletedCategory != null)
            {
                await _categoryDal.RemoveAsync(deletedCategory);
            }


        }

        public async Task<List<Blogg>> GetAllByCategoryIdAsync(int categoryId)
        {
            return await _blogDal.GetAllByCategoryIdAsync(categoryId);
        }

        public async Task<List<Category>> GetCategoriesAsync(int blogId)
        {
            return await _blogDal.GetCategoriesAsync(blogId);        
        }

        public async Task<List<Blogg>> GetLastFiveBlogAsync()
        {
            return await _blogDal.GetLastFiveBlogAsync();
        }

        public async Task<List<Blogg>> SearchAsync(string searchString)
        {
            return await _blogDal.GetAllAsync(I => I.Title.Contains(searchString) || I.ShortDesc.Contains(searchString) || I.Description.Contains(searchString));
        }
    }
}

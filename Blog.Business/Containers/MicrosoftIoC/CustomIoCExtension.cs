using Blog.Business.Concrete;
using Blog.Business.Interfaces;
using Blog.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Blog.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Business.Containers.MicrosoftIoC
{
    public static class CustomIoCExtension 
    {
        public static void AddDependicies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IBlogDal, EfBlogRepository>();
            services.AddScoped<IBlogService, BlogManager>();
        }
    }
}

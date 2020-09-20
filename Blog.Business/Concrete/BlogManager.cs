using Blog.Business.Interfaces;
using Blog.DataAccess.Interfaces;
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
        public BlogManager(IGenericDal<Blogg> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<List<Blogg>> GetAllSortedByPostedtimeAsync()
        {
           return await _genericDal.GetAllAsync(I => I.PostedTime);
        }


    }
}

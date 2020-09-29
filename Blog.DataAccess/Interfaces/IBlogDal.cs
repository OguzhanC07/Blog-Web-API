using Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Interfaces
{
    public interface IBlogDal : IGenericDal<Blogg>
    {
        Task<List<Blogg>> GetAllByCategoryIdAsync(int categoryId);
    }
}

using Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Interfaces
{
    public interface IBlogService : IGenericService<Blogg>
    {
        Task<List<Blogg>> GetAllSortedByPostedtimeAsync();
    }
}

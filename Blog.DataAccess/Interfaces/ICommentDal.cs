using Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Interfaces
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        public Task<List<Comment>> GetAllWithSubCommentsAsync(int blogId, int? parentId);
    }
}

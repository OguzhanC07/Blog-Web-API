using Blog.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Entities.Concrete
{
    public class CategoryBlog : ITable
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int CategoryId { get; set; }

        public Blogg Blogs { get; set; }
        public Category Category { get; set; }
    }
}

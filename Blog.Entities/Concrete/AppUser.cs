using Blog.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Entities.Concrete
{
    public class AppUser : ITable
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        List<Blogg> Blogs { get; set; }
    }
}

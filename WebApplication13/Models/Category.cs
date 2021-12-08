using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication13.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Slogan { get; set; }

        public string Description { get; set; }

        public string ImgSrc { get; set; }

        public string ImgAlt { get; set; }

        public int Order { get; set; }

        public int? Parent_id {get; set;}

        public ICollection<Category> Childs { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication13.Models.ViewModels
{
    public class PostViewModel
    {
        public IEnumerable<Post> Posts{ get; set; }
        public int TotalCount { get; set; }

    }
}

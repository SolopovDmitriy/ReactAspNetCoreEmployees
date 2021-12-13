using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApplication13.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication13.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : Controller
    {
        private ClinicDBContext _context;

        public PostController(ClinicDBContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public Post Get(string id)   // await fetch(`post/${encodedValue}`);  await fetch(`post/palpatio2`);
        {
            return _context.Posts
            .Where(x => x.UrlSlug.Equals(id))
            .FirstOrDefault();
        }


        public IEnumerable<Post> Get() //  const response = await fetch('post');   //получаем список всех постов
        {           
            return _context.Posts.ToArray();
        }


        //public IActionResult Index()
        //{
        //    return View("AllPosts");
        //}

        //public IActionResult PostNotFound()
        //{
        //    return View("PostNotFound");
        //}

        //public IActionResult getPosts(int Id)
        //{
        //    if (Id == 0) { return RedirectToAction("Post", "Index"); }
        //    var posts = _context.Posts
        //        .Where(x => x.PostedOn == true && x.CategoryId == Id)
        //        .OrderBy(x => x.DateOfPublished);
        //    return View("PostsByCategoryes", posts);
        //}

        //public IActionResult getPost(string Id)
        //{          
        //    Post post = _context.Posts
        //        .Where(x => x.UrlSlug.Contains(Id))
        //        .FirstOrDefault();             
        //    if(post == null)
        //    {
        //        return RedirectToAction("PostNotFound", "Post");
        //    }
        //    else
        //    {
        //        return View("OnePost", post);
        //    }
        //}


    }
}

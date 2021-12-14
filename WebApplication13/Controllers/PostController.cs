using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApplication13.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication13.Models.ViewModels;

namespace WebApplication13.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : Controller
    {
        private ClinicDBContext _context;
        public int PageSize = 3;

        public PostController(ClinicDBContext context)
        {
            _context = context;
        }


        ////api/person/byId?id=1
        //[HttpGet("byId")]
        //public string Get(int id)
        //{
        //}

        ////api/person/byName?firstName=a&lastName=b
        //[HttpGet("byName")]
        //public string Get(string firstName, string lastName, string address)
        //{
        //}


        // https://localhost:44394/post/onePost?id=palpatio2 
        [HttpGet("onePost")]
        public Post Get(string id)   // await fetch(`post/${encodedValue}`);  await fetch(`post/palpatio2`);
        {
            return _context.Posts
            .Where(x => x.UrlSlug.Equals(id))
            .FirstOrDefault();
        }

      

        // https://localhost:44394/post/all?page=1 
        [HttpGet("all")]
        public PostViewModel Get(int page) //  const response = await fetch('post');   //получаем список всех постов
        {
            if (page <= 0)
            {
                page = 1;
            }
            PostViewModel model = new PostViewModel
            {
                Posts = _context.Posts
                    .OrderBy(p => p.Id)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize).ToArray(),
                TotalCount = _context.Posts.Count()
            };

            return model;
        }


        //public IEnumerable<Post> Get(int page, int count) 
        //{
        //    return _context.Posts.Where(p => p.Id == page).ToArray();
        //}


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

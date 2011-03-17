using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoPapel.UI.MVC.Models;
using NoPapel.UI.MVC.ViewModels;

namespace NoPapel.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        Context ctx = new Context();
        
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var posts = from p in ctx.Posts
                        orderby p.PublishDate descending
                        select p;

            var viewModel = new IndexViewModel();
            viewModel.Posts = posts.ToList();

            return View(viewModel);
        }

        public ActionResult NewPost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewPost(Post post)
        {
            if (ModelState.IsValid)
            {
                post.PublishDate = DateTime.Now;
                post.User = ctx.Users.First();
                
                ctx.Posts.Add(post);
                ctx.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(post);
        }

        public ActionResult ViewPost(int id)
        {
            var post = ctx.Posts.First(x => x.Id == id);
            
            return View(post);
        }
    }
}

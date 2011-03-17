using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NoPapel.UI.MVC.Models;
using System.Data.Entity.Database;

namespace NoPapel.UI.MVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            DbDatabase.SetInitializer<Context>(new DropCreateDatabaseIfModelChanges<Context>());
            
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            //var ctx = new Context();

            //var tag = new Tag();
            //tag.Name = "textos";

            //var user = new User();
            //user.Name = "dalvarez";

            //var post = new Post();
            //post.Title = "Mi Primer post";
            //post.Content = "Contenido de mi primer post";
            //post.PublishDate = DateTime.Now;
            //post.AddTag(tag);

            //user.AddPost(post);

            //ctx.Tags.Add(tag);
            //ctx.Users.Add(user);
            //ctx.Posts.Add(post);

            //ctx.SaveChanges();
        }
    }
}
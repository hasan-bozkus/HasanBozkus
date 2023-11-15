using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanBozkus.ViewComponents.Blog
{
    public class RecentPost : ViewComponent 
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            var result = bm.GetList().ToList().TakeLast(1);
            return View(result);
        }
    }
}

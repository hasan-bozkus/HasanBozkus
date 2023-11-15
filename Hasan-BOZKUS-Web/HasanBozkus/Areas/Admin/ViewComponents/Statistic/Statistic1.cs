using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HasanBozkus.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = bm.GetList().Count();
            ViewBag.v2 = c.Contacts.Count();
            ViewBag.v3 = c.Comments.Count();

            ViewBag.şehiradi = "Mardin";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=mardin&mode=xml&lang=tr&units=metric&appid=dd6e5716727e03344c38dfb6a2419c27";
            XDocument document = XDocument.Load(connection);
            ViewBag.havadurumu = document.Descendants("temperature").ElementAt(0).Attribute("value").Value + "\'C";
            return View();
        }
    }
}

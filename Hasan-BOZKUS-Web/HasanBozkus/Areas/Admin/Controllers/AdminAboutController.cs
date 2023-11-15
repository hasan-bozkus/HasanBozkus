using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2010.Excel;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using HasanBozkus.Areas.Admin.Models.AdminAboutModel;
using HasanBozkus.Models;

namespace HasanBozkus.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class AdminAboutController : Controller
    {
        Context c = new Context();
        AboutManager abm = new AboutManager(new EFAboutRepository());

        [HttpGet]
        public IActionResult Hakkinda_listesini_getir()
        {
            var values = abm.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var aboutvalues = abm.TGetById(id);
            return View(aboutvalues);
        }

        [HttpPost]
        public IActionResult Index(About about)
        {
            var username = User.Identity.Name;
            var usermail = c.Abouts.Where(x => x.AboutDetails1 == username).Select(y => y.AboutDetails1).FirstOrDefault();
            var writerid = c.Abouts.Where(x => x.AboutDetails1 == usermail).Select(y => y.AboutId).FirstOrDefault();
            var blogvalue = abm.TGetById(about.AboutId);
            about.AboutId = 2;
            //blog.BlogCreateDate = DateTime.Parse(blogvalue.BlogCreateDate.ToShortDateString());
            about.AboutStatus = true;
            abm.TUpdate(about);
            return RedirectToAction("Hakkinda_listesini_getir");
        }

    }
}

﻿using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanBozkus.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class WidgetController : Controller
    {
        CatchManager cm = new CatchManager(new EFCatchRepository());

        Context c = new Context();

        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public IActionResult AdminCatchPartial()
        {
            return PartialView(Tuple.Create<Message2, AppUser>(new Message2(), new AppUser()));

        }

        [HttpPost]
        public IActionResult AdminCatchPartial(Catch p)
        {
            p.CatchDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.CatchStatus = true;
            cm.TAdd(p);
            return RedirectToAction("AdminSohbet", "Widget", new { id = p.CatchId });
        }

        public IActionResult AdminSohbet()
        {
           

            var username = User.Identity.Name;
            var userimage = c.Users.Where(x => x.UserName == username).Select(y => y.ImageUrl).FirstOrDefault();
            var userid = c.Users.Where(x => x.ImageUrl == userimage).Select(y => y.Id).FirstOrDefault();
            var values = cm.GetList(userid);

            ViewBag.imageuser = userimage;
            ViewBag.imageid = userid;
            return View(values);
        }
    }
}

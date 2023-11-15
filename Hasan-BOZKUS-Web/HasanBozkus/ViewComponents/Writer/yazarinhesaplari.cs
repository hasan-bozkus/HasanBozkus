﻿using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using HasanBozkus.Languages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanBozkus.ViewComponents.Writer
{
    public class yazarinhesaplari : ViewComponent
    {
        UserManager wm = new UserManager(new EFUserRepository()); 

        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var username = User.Identity.Name;
            ViewBag.userName = username;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var values = wm.GetUserById(writerId);

          
            return View(values);
        }
    }
}

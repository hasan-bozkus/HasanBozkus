using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanBozkus.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        UserManager wn = new UserManager(new EFUserRepository());
        
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            ViewBag.veri = username;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerid = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var writerimage = c.Writers.Where(x => x.WriterName == username).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.veri2 = writerimage;
            var values = wn.TGetById(writerid);
            return View(values);
        }
    }
}

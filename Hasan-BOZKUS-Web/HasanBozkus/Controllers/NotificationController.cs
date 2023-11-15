using BusinnesLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanBozkus.Controllers
{
    [Authorize(Roles = "Admin, Moderator, Writer")]
    public class NotificationController : Controller
    {
        NotificationManager mm = new NotificationManager(new EFNotificationRepository());

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllNotification()
        {
            var values = mm.GetList();
            return View(values);
        }
    }
}

using BusinnesLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using HasanBozkus.Languages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanBozkus.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
    {
        NewsLetterManager nm = new NewsLetterManager(new EFNewsLetterRepository());

        [HttpGet]
        public IActionResult AddMail()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddMail(NewsLetter p)
        {
            p.MailStatus = true;
            nm.AddNewsLetter(p);
            return PartialView();
        }
    }
}

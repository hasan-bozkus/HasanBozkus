using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using HasanBozkus.Languages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanBozkus.ViewComponents.About
{
    public class SocialMediaAbout : ViewComponent
    {
        iletisimadresleriManager ilm = new iletisimadresleriManager(new EFiletisimAdresleriReository());
        Context c = new Context();
        [AllowAnonymous]
        public IViewComponentResult Invoke(int id)
        {
             var values = ilm.GetList().Take(1).ToList();
            return View(values);
        }
    }
}

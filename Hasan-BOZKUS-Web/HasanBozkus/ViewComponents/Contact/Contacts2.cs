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

namespace HasanBozkus.ViewComponents.Contact
{
    public class Contacts2 : ViewComponent
    {
        iletisimadresleriManager ilm = new iletisimadresleriManager(new EFiletisimAdresleriReository());
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            var values = ilm.GetList().Take(1).ToList();
            return View(values);
        }
    }
}

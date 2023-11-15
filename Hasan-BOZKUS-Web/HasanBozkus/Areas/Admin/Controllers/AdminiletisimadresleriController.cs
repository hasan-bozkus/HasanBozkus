using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2010.Excel;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Reflection.Metadata;

namespace HasanBozkus.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminiletisimadresleriController : Controller
    {
        iletisimadresleriManager ilm = new iletisimadresleriManager(new EFiletisimAdresleriReository());
        Context c = new Context();

        [HttpGet]
        public IActionResult Index()
        {
            
            var adresvalues = ilm.GetList();
            return View(adresvalues);
        }

        [HttpGet]
        public IActionResult EditİletisimAdresi(int id)
        {
            var iletisimadresivalue = ilm.TGetById(id);
            return View(iletisimadresivalue);
        }


        [HttpPost]
        public IActionResult EditİletisimAdresi(iletisimadresleri ilma)
        {
            var iletisimname = User.Identity.Name;
            var iletisimbilgi = c.iletisimadresleris.Where(x => x.iletisimadi == iletisimname).Select(y => y.iletisimadi).FirstOrDefault();
            var iletisimid = c.iletisimadresleris.Where(x => x.iletisimadi == iletisimbilgi).Select(y => y.Id).FirstOrDefault();
            var iletismadreslerivalue = ilm.TGetById(ilma.Id);
            ilma.Id = 1;
            ilma.iletisimstatus = true;
            ilm.TUpdate(ilma);
            return RedirectToAction("Index");
        }
    }
}

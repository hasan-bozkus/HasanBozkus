using BusinnesLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2010.Excel;
using HasanBozkus.Languages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HasanBozkus.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EFAboutRepository());
        iletisimadresleriManager ilm = new iletisimadresleriManager(new EFiletisimAdresleriReository());

        private readonly IStringLocalizer<Lang> _stringLocalizer;

        readonly RequestLocalizationOptions _localizationOptions;

        public AboutController(IStringLocalizer<Lang> stringLocalizer, IOptions<RequestLocalizationOptions> localizationOptions)
        {
            _stringLocalizer = stringLocalizer;
            _localizationOptions = localizationOptions.Value;
        }

        [AllowAnonymous]
        public IActionResult AboutIndex(int id)
        {
            ViewBag.PageAbout = _stringLocalizer["page.About"];
            ViewBag.PageWhoAreWeOurMissionVision = _stringLocalizer["page.WhoAreWeOurMissionVision"];
            ViewBag.s = id;
            var values = abm.GetList();

            return View(values);
        }

        public PartialViewResult SocialMediaAbout(int id)
        {

            var iletisimvalues = abm.GetList();
            return PartialView(iletisimvalues);
        }
    }
}

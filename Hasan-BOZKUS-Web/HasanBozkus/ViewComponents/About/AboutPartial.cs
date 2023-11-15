using BusinnesLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using HasanBozkus.Languages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace HasanBozkus.ViewComponents.About
{
    public class AboutPartial : ViewComponent
    {

        AboutManager abm = new AboutManager(new EFAboutRepository());

        private readonly IStringLocalizer<Lang> _stringLocalizer;

        readonly RequestLocalizationOptions _localizationOptions;

        public AboutPartial(IStringLocalizer<Lang> stringLocalizer, IOptions<RequestLocalizationOptions> localizationOptions)
        {
            _stringLocalizer = stringLocalizer;
            _localizationOptions = localizationOptions.Value;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.PageAbout = _stringLocalizer["page.About"];
            ViewBag.InPageReadMore = _stringLocalizer["inPage.ReadMore"];
            var values = abm.GetList();
            return View(values);
        }
    }
}

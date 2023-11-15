using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using HasanBozkus.Languages;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanBozkus.Areas.Admin.ViewComponents.AdminNavbarpartialtoprofilesimage
{
    public class imagenamemailes : ViewComponent
    {
        private readonly IStringLocalizer<Lang> _stringLocalizer;

        readonly RequestLocalizationOptions _localizationOptions;

        public imagenamemailes(IStringLocalizer<Lang> stringLocalizer, IOptions<RequestLocalizationOptions> localizationOptions)
        {
            _stringLocalizer = stringLocalizer;
            _localizationOptions = localizationOptions.Value;
        }

        UserManager wm = new UserManager(new EFUserRepository());
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            ViewBag.veri = username;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var userimage = c.Users.Where(x=>x.Email == usermail).Select(y=>y.ImageUrl).FirstOrDefault();
            var writerid = c.Users.Where(x => x.ImageUrl == userimage).Select(y => y.Id).FirstOrDefault();
            var values = wm.TGetById(writerid);

            IRequestCultureFeature requestCulture = HttpContext.Features.Get<IRequestCultureFeature>();
            var allCultures = _localizationOptions.SupportedCultures
                    .Select(culture => new
                    {
                        culture.Name,
                        Text = culture.DisplayName
                    }).ToList();

            return View(values);
        }
    }
}

using HasanBozkus.Languages;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace HasanBozkus.ViewComponents.NewsLetter
{
    public class TechnologySoftwareOtherBlog : ViewComponent
    {
        private readonly IStringLocalizer<Lang> _stringLocalizer;

        readonly RequestLocalizationOptions _localizationOptions;

        public TechnologySoftwareOtherBlog(IStringLocalizer<Lang> stringLocalizer, IOptions<RequestLocalizationOptions> localizationOptions)
        {
            _stringLocalizer = stringLocalizer;
            _localizationOptions = localizationOptions.Value;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.InPageTechnologySoftwareOtherBlog = _stringLocalizer["inPage.TechnologySoftwareOtherBlogs"];
            IRequestCultureFeature requestCulture = HttpContext.Features.Get<IRequestCultureFeature>();
            var allCultures = _localizationOptions.SupportedCultures
                    .Select(culture => new
                    {
                        culture.Name,
                        Text = culture.DisplayName
                    }).ToList();

            return View(allCultures);
        }

    }
}

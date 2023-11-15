using HasanBozkus.Languages;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace HasanBozkus.ViewComponents.Category
{
    public class InPageCategories : ViewComponent
    {
        private readonly IStringLocalizer<Lang> _stringLocalizer;

        readonly RequestLocalizationOptions _localizationOptions;

        public InPageCategories(IStringLocalizer<Lang> stringLocalizer, IOptions<RequestLocalizationOptions> localizationOptions)
        {
            _stringLocalizer = stringLocalizer;
            _localizationOptions = localizationOptions.Value;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.InPageCategories = _stringLocalizer["inPage.Categories"];

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

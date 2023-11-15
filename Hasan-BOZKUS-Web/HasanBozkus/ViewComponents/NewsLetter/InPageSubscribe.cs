﻿using HasanBozkus.Languages;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace HasanBozkus.ViewComponents.NewsLetter
{
    public class InPageSubscribe : ViewComponent
    {
        private readonly IStringLocalizer<Lang> _stringLocalizer;

        readonly RequestLocalizationOptions _localizationOptions;

        public InPageSubscribe(IStringLocalizer<Lang> stringLocalizer, IOptions<RequestLocalizationOptions> localizationOptions)
        {
            _stringLocalizer = stringLocalizer;
            _localizationOptions = localizationOptions.Value;
        }

        public IViewComponentResult Invoke()
        {
            
            IRequestCultureFeature requestCulture = HttpContext.Features.Get<IRequestCultureFeature>();
            var allCultures = _localizationOptions.SupportedCultures
                    .Select(culture => new
                    {
                        culture.Name,
                        Text = culture.DisplayName
                    }).ToList();
            ViewBag.InPageSubscribe = _stringLocalizer["inPage.Subscribe"];
            return View(allCultures);
        }

    }
}

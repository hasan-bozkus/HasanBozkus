using HasanBozkus.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HasanBozkus.Languages;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
//using HasanBozkus.Models.BlogModel;

namespace HasanBozkus.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<Lang> _stringLocalizer;

        readonly RequestLocalizationOptions _localizationOptions;


        BlogManager bm = new BlogManager(new EFBlogRepository());

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<Lang> stringLocalizer, IOptions<RequestLocalizationOptions> localizationOptions)
        {
            _logger = logger;
            _stringLocalizer = stringLocalizer;
            _localizationOptions = localizationOptions.Value;
        }


        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.InPageOurBlogs = _stringLocalizer["inPage.OurBlogs"];
            ViewBag.InPageSoftwareLanguages = _stringLocalizer["inPage.SoftwareLanguages"];
            ViewBag.InPageSoftwareLanguages = _stringLocalizer["inPage.SoftwareLanguages"];
            ViewBag.InPageAlgorithm = _stringLocalizer["inPage.Algorithm"];
            ViewBag.PageAbout = _stringLocalizer["page.About"];
            ViewBag.PagePinnedBlogs = _stringLocalizer["page.PinnedBlogs"];
            ViewBag.InPageReadMore = _stringLocalizer["inPage.ReadMore"];
            ViewBag.InPageMore = _stringLocalizer["inPage.More"];
            ViewBag.InPagePrev = _stringLocalizer["inPage.Prev"];
            ViewBag.InPageNext = _stringLocalizer["inPage.Next"];

            var result = bm.GetList().Where(x => x.BlogStatus == true).TakeLast(3).ToList();

            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult aramacubugu()
        {
            return View();
        }
    }
}
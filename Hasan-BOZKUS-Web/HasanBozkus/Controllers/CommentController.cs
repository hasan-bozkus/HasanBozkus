using BusinnesLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using HasanBozkus.Languages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanBozkus.Controllers
{
    [Authorize(Roles = "Admin,Moderator,Writer")]
    [AllowAnonymous]
    public class CommentController : Controller
    {

        private readonly IStringLocalizer<Lang> _stringLocalizer;

        readonly RequestLocalizationOptions _localizationOptions;

        public CommentController(IStringLocalizer<Lang> stringLocalizer, IOptions<RequestLocalizationOptions> localizationOptions)
        {
            _stringLocalizer = stringLocalizer;
            _localizationOptions = localizationOptions.Value;
        }
        CommentManager cm = new CommentManager(new EFCommentRepository());
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PartialAddComment()
        {
            ViewBag.PageComment = _stringLocalizer["page.Comment"];
            ViewBag.InPageEnterTitle = _stringLocalizer["inPage.EnterTitle"];
            ViewBag.InPageEnterYourName = _stringLocalizer["inPage.EnterYourName"];
            ViewBag.InPageYourComment = _stringLocalizer["inPage.YourComment"];

            IRequestCultureFeature requestCulture = HttpContext.Features.Get<IRequestCultureFeature>();
            var allCultures = _localizationOptions.SupportedCultures
                    .Select(culture => new
                    {
                        culture.Name,
                        Text = culture.DisplayName
                    }).ToList();
            return PartialView(allCultures);
        }

        [HttpPost]
        public IActionResult PartialAddComment(Comment p)
        {
            p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.CommentStatus = true;
            //p.BlogId = 41;
            cm.CommentAdd(p);
            return RedirectToAction("BlogReadAll", "Blog", new { id = p.BlogId });
        }

        public PartialViewResult CommentListByBlog(int id)
        {
            var values = cm.GetList(id);
            return PartialView(values);
        }
    }
}

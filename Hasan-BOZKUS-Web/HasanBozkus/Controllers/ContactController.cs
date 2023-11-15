using BusinnesLayer.Concrete;
using BusinnesLayer.ValidationRules;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using DocumentFormat.OpenXml.Bibliography;
using EntityLayer.Concrete;
using FluentValidation.Results;
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

    [AllowAnonymous]
    public class ContactController : Controller
    {
        iletisimadresleriManager ilm = new iletisimadresleriManager(new EFiletisimAdresleriReository());
        ContactManager cm = new ContactManager(new EFContactRepository());
        Context c = new Context();

        private readonly IStringLocalizer<Lang> _stringLocalizer;

        readonly RequestLocalizationOptions _localizationOptions;

        public ContactController(IStringLocalizer<Lang> stringLocalizer, IOptions<RequestLocalizationOptions> localizationOptions)
        {
            _stringLocalizer = stringLocalizer;
            _localizationOptions = localizationOptions.Value;
        }

        [HttpGet]
        public IActionResult ContactIndex()
        {
            ViewBag.PageContactUs = _stringLocalizer["page.ContactUs"];
            ViewBag.PageShareYourThoughtsWithUs = _stringLocalizer["page.ShareYourThoughtsWithUs"];
            ViewBag.InPageAddress = _stringLocalizer["inPage.Address"];
            ViewBag.PageEmail = _stringLocalizer["page.Email"];
            ViewBag.InPageTelephone = _stringLocalizer["inPage.Telephone"];
            ViewBag.InPageYourName = _stringLocalizer["inPage.YourName"];
            ViewBag.InPageEMailAddress = _stringLocalizer["inPage.EMailAddress"];
            ViewBag.InPageSubject = _stringLocalizer["inPage.Subject"];
            ViewBag.InPageYourMessage = _stringLocalizer["inPage.YourMessage"];
            ViewBag.InPageSubmit = _stringLocalizer["inPage.Submit"];

            int id = 1;
            var eposta = c.iletisimadresleris.Where(x => x.Id == id).Select(y => y.eposta).FirstOrDefault();
            var telefon = c.iletisimadresleris.Where(x => x.Id == id).Select(y => y.phonenumber).FirstOrDefault();
            ViewBag.epostam = eposta;
            ViewBag.telefonum = telefon;
            return View();
        }

        [HttpPost]
        public IActionResult ContactIndex(Contact contact)
        {
            ContactValidator cv = new ContactValidator();
            ValidationResult result = cv.Validate(contact);
            if (result.IsValid)
            {
                contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                contact.ContactStatus = true;
                cm.ContactAdd(contact);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }



    }
}


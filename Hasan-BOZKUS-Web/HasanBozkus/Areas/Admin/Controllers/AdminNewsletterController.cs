using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Net;
using MailKit;
using X.PagedList;
using HasanBozkus.Areas.Admin.Models;

namespace HasanBozkus.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class AdminNewsletterController : Controller
    {
        NewsLetterManager nlm = new NewsLetterManager(new EFNewsLetterRepository());

        Context _c = new Context();

        public IActionResult Index()
        {
            var values = nlm.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult EmailPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EmailPost(NewsLetter newsLetter, string Subject, string Descricption)
        {
            // Veri tabanından eposta adreslerini alın.
            var emails = nlm.GetList();

            var newsLetterEmailPost = new NewsLetterPostEmail();

            foreach (var emailAddress in emails)
            {
                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("hasanbozkus.com.tr", "hhasanbozkus0147@gmail.com");
                MailboxAddress mailboxAddressTo = new MailboxAddress("User", emailAddress.Mail);

                mimeMessage.From.Add(mailboxAddressFrom);
                mimeMessage.To.Add(mailboxAddressTo);


                // Epostayı gönderin.
                var bodyBuilder = new BodyBuilder();


                bodyBuilder.HtmlBody = Descricption;
                newsLetterEmailPost.DateCreated = DateTime.UtcNow;
                mimeMessage.Body = bodyBuilder.ToMessageBody();
                mimeMessage.Subject = Subject;

                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("hhasanbozkus0147@gmail.com", "avejvezsokzpdntm");
                client.Send(mimeMessage);
                client.Disconnect(true);

                    
                // txt dosyasının adını oluşturun.
                var fileName = $"eposta-{DateTime.Now.ToString("yyyyMMddHHmmss")}.txt";

                // Dosya oluşturmak için bir dosya yolu oluşturun.
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/EMailPost/", $"eposta-{DateTime.Now.ToString("yyyyMMddHHmmss")}.txt");

                // Dosyayı oluşturmak için File.Create() yöntemini kullanın.
                var txtFile = System.IO.File.Create(filePath);

                // StreamWriter nesnesini oluşturun.
                var sw = new StreamWriter(txtFile);

                // StreamWriter nesnesine yaz
                sw.WriteLine($"Subject: {Subject}");
                sw.WriteLine($"Description: {Descricption}");
                sw.WriteLine($"CreateDate: {newsLetterEmailPost.DateCreated}");

                // StreamWriter nesnesini kapat
                sw.Close();

            }
            return View();
        }

        public IActionResult DeleteMail(int id)
        {
            var mailvue = nlm.TGetById(id);
            nlm.TDelete(mailvue);
            return RedirectToAction("Index");
        }
    }
}

using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using HasanBozkus.Languages;
using HasanBozkus.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HasanBozkus.ViewComponents.Blog
{
    public class sosyalmedya : ViewComponent
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        Context c = new Context();


        public async Task<IViewComponentResult> InvokeAsync(int id)
        {

            //IRequestCultureFeature requestCulture = HttpContext.Features.Get<IRequestCultureFeature>();
            //var allCultures = _localizationOptions.SupportedCultures
            //        .Select(culture => new
            //        {
            //            culture.Name,
            //            Text = culture.DisplayName
            //        }).ToList();

            //        //instagram takipçi sayısı bulma

            //        var client = new HttpClient();
            //        var request = new HttpRequestMessage
            //        {
            //            Method = HttpMethod.Get,
            //            RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/hasanbozkus0147"),
            //            Headers =
            //{
            //    { "X-RapidAPI-Key", "0d8cb4f5b0mshcf6e94f4f120a03p1e6e5bjsn85b6be86fe40" },
            //    { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
            //},
            //        };
            //        using (var response = await client.SendAsync(request))
            //        {
            //            response.EnsureSuccessStatusCode();
            //            var body = await response.Content.ReadAsStringAsync();
            //            İnstagramFollowiersVİewModel ViewModel =JsonConvert.DeserializeObject<İnstagramFollowiersVİewModel>(body);

            //            ViewBag.followers = ViewModel.followers;
            //        }

            //

            //var blogagoremedyahesaplari = c.Blogs.Include(x => x.Writers).Where(x => x.BlogId == id).FirstOrDefault();
            //ViewBag.medya = blogagoremedyahesaplari;
            var values = bm.Blogagoremedyahesbigetir(id);
          
            
            return View(values);
        }
    }
}

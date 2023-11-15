using DataAccsessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HasanBozkus.Models;

namespace HasanBozkus.Controllers
{
    public class ErrorPageController : Controller
    {
        Context c = new Context();

        public IActionResult Error1(string query)
        {
            var searchResults = c.Blogs
             .Where(p => p.BlogTitle.Contains(query) || p.Category.CategorName.Contains(query)).ToList(); /*|| p.BlogContent.Contains(query))*/


            // Sonuçları bir view model oluşturarak döndürebilirsiniz

            var model = new SearchViewModel
            {
                Query = query,
                Results = searchResults
            };

            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using BusinnesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;

namespace HasanBozkus.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        public IActionResult Index()
        {
            var values = cm.GetList();
            return View(values);
        }
    }
}

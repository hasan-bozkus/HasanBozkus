using BusinnesLayer.Concrete;
using BusinnesLayer.ValidationRules;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using DocumentFormat.OpenXml.Spreadsheet;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using X.PagedList;

namespace HasanBozkus.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        Context c = new Context();

        public IActionResult Index(int page = 1)
        {
            var values = cm.GetList().ToPagedList(page, 3);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            AdminCategoryValidator acv = new AdminCategoryValidator();
            ValidationResult result = acv.Validate(category);
            if (result.IsValid)
            {

                category.CategoryStatus = true;
                cm.TAdd(category);
                return RedirectToAction("Index", "Category");
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

        public IActionResult DeleteCategory(int id)
        {
            var value = cm.TGetById(id);
            cm.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var categoryvalue = cm.TGetById(id);
            return View(categoryvalue);
        }

        [HttpPost]
        public IActionResult EditCategory(Category category, int id)
        {
            var categoryid = c.Categories.Where(x => x.CategoryId == id).Select(y =>y.CategoryId).FirstOrDefault();
            var categoryvalue = cm.TGetById(category.CategoryId);
            category.CategoryId = categoryid;
            category.CategoryStatus = true;
            cm.TUpdate(category);
            return RedirectToAction("Index");

        }
    }
}
//var username = User.Identity.Name;
//var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
//var writerid = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
//var blogvalue = bm.TGetById(blog.BlogId);
//blog.WritersId = writerid;
//blog.BlogCreateDate = DateTime.Parse(blogvalue.BlogCreateDate.ToShortDateString());
//bm.TUpdate(blog);
//return RedirectToAction("BlogListByWriter");
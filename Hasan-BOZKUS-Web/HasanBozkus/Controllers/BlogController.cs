using BusinnesLayer.Abstract;
using BusinnesLayer.Concrete;
using BusinnesLayer.ValidationRules;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HasanBozkus.Models;
using X.PagedList;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Routing.Constraints;
//using HasanBozkus.Areas.Admin.Controllers;

namespace HasanBozkus.Controllers
{
    [Authorize(Roles = "Admin, Moderator, Writer")]
    public class BlogController : Controller
    {
        CommentManager cmm = new CommentManager(new EFCommentRepository());
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        BlogManager bm = new BlogManager(new EFBlogRepository());

     
       

        Context c = new Context();

        [AllowAnonymous]
        public IActionResult Index(int page = 1)
        {
            var result = bm.GetBlogListWithCategory().Where(x => x.BlogStatus == true).ToList().ToPagedList(page, 12);
    
            return View(result);
        }

        [AllowAnonymous]
        public async Task<IActionResult> BlogReadAll(int id)
        {
            
            var yorumsayısı = c.Comments.Where(x => x.BlogId == id).Select(y => y.CommentId).Count();
            ViewBag.yorumsayısı = yorumsayısı;
            ViewBag.i = id;
            ViewBag.CommentId = id;
            ViewBag.s = id;
            var username = User.Identity.Name;
            ViewBag.name = username;
            var values = bm.GetBlogById(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerid = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var values = bm.GetListWithCategoryByWriterBm(writerid);
            return View(values);
        }

        public void CategoryList()
        {
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {

                                                       Text = x.CategorName,
                                                       Value = x.CategoryId.ToString()

                                                   }).ToList();

            ViewData["Kategoriler"] = categoryvalues;
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {

                                                       Text = x.CategorName,
                                                       Value = x.CategoryId.ToString()

                                                   }).ToList();

            ViewBag.cv = categoryvalues;

            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerid = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();

            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WritersId = writerid;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            CategoryList();
            return View();

        }

        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }

        public async Task<IActionResult> ToggleStatus(int id)
        {
            var post = await c.Blogs.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            post.BlogStatus = !post.BlogStatus;
            c.Update(post);
            await c.SaveChangesAsync();

            return RedirectToAction(nameof(BlogListByWriter));
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {


            var blogvalue = bm.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategorName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;

            List<SelectListItem> list = (from x in Getdurum()
                                         select new SelectListItem
                                         {
                                             Text = x,
                                             Value = x
                                         }).ToList();

            ViewBag.list = list;
            return View(blogvalue);
        }

        public List<string> Getdurum()
        {
            String[] CitiesArray = new String[] { "false", "true" };
            return new List<string>(CitiesArray);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerid = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var blogvalue = bm.TGetById(blog.BlogId);
            blog.WritersId = writerid;
            blog.BlogCreateDate = DateTime.Parse(blogvalue.BlogCreateDate.ToShortDateString());
            bm.TUpdate(blog);
            return RedirectToAction("BlogListByWriter");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Searchcubugu(string query)
        {
            var searchResults = c.Blogs
             .Where(p => p.BlogTitle.Contains(query) || p.Category.CategorName.Contains(query)).ToList(); /*|| p.BlogContent.Contains(query))*/


            // Sonuçları bir view model oluşturarak döndürebilirsiniz

            var model = new SearchViewModel
            {
                Query = query,
                Results = searchResults
            };

            return PartialView(model);
        }

      
    }
}


public class BlogImages
{
    public int CategoryId { get; set; }
    public string BlogTitle { get; set; }
    public string BlogContent { get; set; }
    public DateTime BlogCreateDate { get; set; }
    public IFormFile BlogImage { get; set; }
    public IFormFile BlogsmallImage { get; set; }
}

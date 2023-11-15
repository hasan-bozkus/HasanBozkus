﻿using BusinnesLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanBozkus.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class AdminCommentController : Controller
    {
        CommentManager cm = new CommentManager(new EFCommentRepository());

        public IActionResult Index()
        {
            var values = cm.GetCommentsWithBlog();
            return View(values);
        }

        public IActionResult DeleteComment(int id)
        {
            var blogvalue = cm.TGetById(id);
            cm.TDelete(blogvalue);
            return RedirectToAction("Index");
        }
    }
}

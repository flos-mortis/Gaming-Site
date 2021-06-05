using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestStore.Models;

namespace TestStore.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationContext db;
        private UserManager<User> userManager;
        public NewsController(ApplicationContext db, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.db = db;
        }
        //[Authorize(Roles ="admin")]
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            return View(await db.Articles.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Article article)
        {
            // article.Author = await userManager.FindByIdAsync(userManager.GetUserId(User));
            //fffffffffffffffffffffffffffffffffffffff
            //article.Author = user;

            //var authorId = userManager.GetUserId(User);
            //article.Author = await userManager.FindByIdAsync(authorId);
            db.Articles.Add(article);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult NewsItem(int id)
        {
            return View(db.Articles.Find(id));
        }
    }
}

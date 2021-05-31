using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public NewsController(ApplicationContext db)
        {
            this.db = db;
        }
        [Authorize(Roles ="admin")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Article article)
        {
            db.Articles.Add(article);
            db.SaveChanges();
            return View();
        }
        public IActionResult NewsItem()
        {
            return View();
        }
    }
}

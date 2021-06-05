using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestStore.Models;

namespace TestStore.Controllers
{
    public class ShopController : Controller
    {
        private readonly ILogger<ShopController> _logger;
        private ApplicationContext db;
        public ShopController(ILogger<ShopController> logger, ApplicationContext db)
        {
            _logger = logger;
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Game_Profile()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Payment()
        {
            return View();
        }
        public IActionResult Action(string sortOrder)
        {
            ViewBag.PriceSortParam = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "";
            var games = from b in db.Games select b;

            switch (sortOrder)
            {
                case "price_desc":
                    games = games.OrderByDescending(b => b.Price);
                    break;
                default:
                    games = games.OrderBy(b => b.Price);
                    break;
            }
            return View();
        }
    }
}

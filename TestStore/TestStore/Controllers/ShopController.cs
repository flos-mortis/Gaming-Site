using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestStore.Models;
using TestStore.Models;
using TestStore.ViewModels;

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
        ApplicationContext db;
        UserManager<User> userManager;
        public ShopController(ApplicationContext db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Game_Profile()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Cart()
        {
            User user = await userManager.GetUserAsync(User);
            var viewModel = new OrderViewModel();
            viewModel.Games.AddRange(db.Games.Join(db.Orders.Where(ord => ord.UserId == user.Id),
                g => g.Id,
                o => o.GameId,
                (g, o) => new Game { Id = o.GameId}   )    
                );
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(Game game)
        {
            User user = await userManager.GetUserAsync(User);
            db.Orders.Add(new Order { GameId = game.Id, UserId = user.Id });
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [Authorize]
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

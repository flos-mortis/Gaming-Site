using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestStore.Models;
using TestStore.ViewModels;
using System.Security.Claims;
using System.Web;

namespace TestStore.Controllers
{
    public class ShopController : Controller
    {
        UserManager<User> userManager;
        private readonly ILogger<ShopController> _logger;
        private ApplicationContext db;
        public ShopController(ILogger<ShopController> logger, ApplicationContext db, UserManager<User> userManager)
        {
            _logger = logger;
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
        public IActionResult Cart()
        {
            var viewModel = new OrderViewModel();
            
            if (db.Games != null)
            {                
                
                /*viewModel.Games.AddRange(db.Games.Join(db.Orders.Where(ord => ord.UserId == userId),
                    g => g.Id,
                    o => o.GameId,
                    (g, o) => new Game { Id = o.GameId })
                    );*/
                viewModel.Games = GetOrderList();
            }
            if (viewModel.Games != null)
            {
                return View(viewModel.Games);
            }
            else return View("Index");
            }
        public List<Game> GetOrderList()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Game> orderList = new List<Game>();
            orderList.AddRange(db.Games.Join(db.Orders.Where(ord => ord.UserId == userId),
                    g => g.Id,
                    o => o.GameId,
                    (g, o) => new Game { Id = g.Id, Description = g.Description, Price = g.Price, SalePrice = g.SalePrice, GenreId = g.GenreId, Name = g.Name })
                    );
            return orderList;
        }
        [HttpGet]
        public IActionResult DeleteCartItem(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orderToDelete = db.Orders
                .Where(ord => ord.GameId == id && ord.UserId == userId)
                .FirstOrDefault();
            if (orderToDelete == null)
            {
                return View("Index");
            }
            return View(id);
        }
        [HttpPost, ActionName("DeleteCartItem")]
        public IActionResult DeleteCartItemConfirmed(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orderToDelete = db.Orders
                .Where(ord => ord.GameId == id && ord.UserId == userId)
                .FirstOrDefault();
            if (orderToDelete == null)
            {
                return View("Index");
            }
            db.Orders.Remove(orderToDelete);
            db.SaveChanges();
            return View("Index");
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ;
            Order order = new Order { GameId = id, UserId = userId };
            var orderExists = db.Orders
                .Where(ord => ord.GameId == order.GameId && ord.UserId == order.UserId)
                .FirstOrDefault();
            if (orderExists == null)
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
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
        public IActionResult Error()
        {
            return View();
        }
    }
}

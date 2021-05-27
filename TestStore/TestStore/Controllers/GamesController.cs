using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestStore.Models;

namespace TestStore.Controllers
{
    public class GamesController : Controller
    {
        private ApplicationContext db;
        public GamesController(ApplicationContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Games.ToListAsync());
        }
        public IActionResult GenresPartial()
        {
            return PartialView(db.Genres.ToList());
        }
        public IActionResult GenreCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GenreCreate(Genre genre)
        {
            db.Genres.Add(genre);
            await db.SaveChangesAsync();
            return RedirectToAction("Create");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Game game)
        {
            db.Games.Add(game);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //Get
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await db.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, //[Bind("ID,Title,ReleaseDate,Genre,Price")]
        Game game) //сделать GameExists(game.id)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                db.Update(game);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        //Get
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await db.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }
            db.Remove(game);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

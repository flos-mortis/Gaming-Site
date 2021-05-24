﻿using Microsoft.AspNetCore.Mvc;
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
    }
}

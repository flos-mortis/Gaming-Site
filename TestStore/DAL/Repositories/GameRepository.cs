using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entities;
using DAL.Interfaces;
using DAL.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    class GameRepository : IRepository<Game>
    {
        public ApplicationContext db;
        public GameRepository(ApplicationContext db)
        {
            this.db = db;
        }
        public void Create(Game item)
        {
            db.Games.Add(item);
        }

        public void Delete(int id)
        {
            Game game = GetById(id);
            if(game != null)
            {
                db.Games.Remove(game);
            }
        }

        public IEnumerable<Game> Find(Func<Game, bool> predicate)
        {
            return db.Games.Where(predicate).ToList();
        }

        public IEnumerable<Game> GetAll()
        {
            return db.Games.Include(game => game.Name).Include(game => game.Price);
        }

        public Game GetById(int id)
        {
            return db.Games.Find(id);
        }

        public void Update(Game item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}

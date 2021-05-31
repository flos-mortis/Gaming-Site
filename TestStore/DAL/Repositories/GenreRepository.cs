using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entities;
using DAL.Interfaces;
using DAL.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    class GenreRepository : IRepository<Genre>
    {
        public ApplicationContext db;
        public GenreRepository(ApplicationContext db)
        {
            this.db = db;
        }
        public void Create(Genre item)
        {
            db.Genres.Add(item);
        }

        public void Delete(int id)
        {
            Genre gen = GetById(id);
            if(gen != null)
            {
                db.Genres.Remove(gen);
            }
        }

        public IEnumerable<Genre> Find(Func<Genre, bool> predicate)
        {
            return db.Genres.Where(predicate).ToList();
        }

        public IEnumerable<Genre> GetAll()
        {
            return db.Genres;
        }

        public Genre GetById(int id)
        {
            return db.Genres.Find(id);
        }

        public void Update(Genre item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entities;
using DAL.Interfaces;
using DAL.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    class ArticleRepository : IRepository<Article>
    {
        private ApplicationContext db;
        public ArticleRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public void Create(Article item)
        {
            db.Articles.Add(item);
        }

        public void Delete(int id)
        {
            Article a = GetById(id);
            if (a != null)
            {
                db.Articles.Remove(a);
            }
        }

        public IEnumerable<Article> Find(Func<Article, bool> predicate)
        {
            return db.Articles.Include(art => art.Author).Where(predicate).ToList();
        }

        public IEnumerable<Article> GetAll()
        {
            return db.Articles.Include(art => art.Author);
        }

        public Article GetById(int id)
        {
            return db.Articles.Find(id);
        }

        public void Update(Article item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}

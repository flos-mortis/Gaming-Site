using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entities;
using DAL.Interfaces;
using DAL.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    class CommentRepository : IRepository<Comment>
    {
        public ApplicationContext db;
        public CommentRepository(ApplicationContext db)
        {
            this.db = db;
        }
        public void Create(Comment item)
        {
            db.Comments.Add(item);
        }

        public void Delete(int id)
        {
            Comment com = GetById(id);
            if(com != null)
            {
                db.Comments.Remove(com);
            }
        }

        public IEnumerable<Comment> Find(Func<Comment, bool> predicate)
        {
            return db.Comments.Include(com => com.Author).Where(predicate).ToList();
        }

        public IEnumerable<Comment> GetAll()
        {
            return db.Comments.Include(com => com.Author);
        }

        public Comment GetById(int id)
        {
            return db.Comments.Find(id);
        }

        public void Update(Comment item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}

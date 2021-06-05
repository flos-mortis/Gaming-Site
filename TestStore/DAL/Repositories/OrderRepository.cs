using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entities;
using DAL.Interfaces;
using DAL.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    class OrderRepository : IRepository<Order>
    {
        public ApplicationContext db;
        public OrderRepository(ApplicationContext db)
        {
            this.db = db;
        }
        public void Create(Order item)
        {
            db.Orders.Add(item);
        }

        public void Delete(int id)
        {
            Order ord = GetById(id);
            if (ord != null)
            {
                db.Orders.Remove(ord);
            }
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            return db.Orders.Where(predicate).ToList();
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders;
        }

        public Order GetById(int id)
        {
            return db.Orders.Find(id);
        }

        public void Update(Order item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Entities;
using DAL.EntityFramework;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace DAL.Repositories
{
    class UserProfileRepository : IUserProfileRepository
    {
        private readonly ApplicationContext db;
        
        public UserProfileRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public void Create(UserProfile item)
        {
            db.UserProfiles.Add(item);
        }

        public void Delete(int id)
        {
            UserProfile profile = GetById(id);
            if(profile != null)
            {
                db.UserProfiles.Remove(profile);
            }
        }

        public IEnumerable<UserProfile> Find(Func<UserProfile, bool> predicate)
        {
            return db.UserProfiles.Where(predicate).ToList();
        }

        public IEnumerable<UserProfile> GetAll()
        {
            return db.UserProfiles.Include(user => user.User);
        }

        public UserProfile GetByAccountId(string id)
        {
            return db.UserProfiles.Where(user => user.User.Id == id).FirstOrDefault();
        }

        public UserProfile GetById(int? id)
        {
            return db.UserProfiles.Find(id);
        }

        public void Update(UserProfile item)
        {
            UserProfile profile = GetById(item.Id);
            if(profile != null)
            {
                profile.UserName = item.UserName;
                profile.Email = item.Email;
                profile.Country = item.Country;
                profile.About = item.About;
                profile.Gender = item.Gender;
                profile.Picture = item.Picture;

                db.UserProfiles.Update(profile);
                db.SaveChanges();
            }
        }
    }
}

using DAL.Entities;
using System.Collections.Generic;
using System;

namespace DAL.Interfaces
{
    interface IUserProfileRepository
    {
        IEnumerable<UserProfile> GetAll();
        UserProfile GetById(int? id);
        UserProfile GetByAccountId(string id);
        IEnumerable<UserProfile> Find(Func<UserProfile, Boolean> predicate);
        void Create(UserProfile item);
        void Update(UserProfile item);
        void Delete(int id);
    }
}

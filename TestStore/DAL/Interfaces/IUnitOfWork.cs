using System;
using DAL.Entities;
using System.Threading.Tasks; 

namespace DAL.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        IUserProfileRepository UserProfiles { get; }
        IRepository<Game> Games { get; }
        IRepository<Genre> Genres { get; }
        IRepository<Comment> Comments { get; }
        IRepository<Article> Articles { get; }
        IRepository<Order> Orders { get; }
        void Save();
    }
}

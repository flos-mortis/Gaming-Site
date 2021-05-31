using System;
using DAL.Entities;
using System.Threading.Tasks; 

namespace DAL.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        IUserPasswordRepository UserPasswords { get; }
        IUserProfileRepository UserProfiles { get; }
        IRepository<Game> Games { get; }
        IRepository<Genre> Genres { get; }
        IRepository<Comment> Comments { get; }
        IRepository<Article> Articles { get; }
        void Save();
    }
}

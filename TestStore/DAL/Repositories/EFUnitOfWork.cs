using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.EntityFramework;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DAL.Repositories
{
    class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        private ArticleRepository articleRepository;
        private CommentRepository commentRepository;
        private GameRepository gameRepository;
        private GenreRepository genreRepository;
        private UserPasswordRepository userPasswordRepository;
        private UserProfileRepository userProfileRepository;

        public EFUnitOfWork(ApplicationContext db, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IAccountRepository UserPasswords
        {
            get
            {
                if (userPasswordRepository == null)
                    userPasswordRepository = new UserPasswordRepository(userManager, signInManager, db);
                return userPasswordRepository;
            }
        }

        public IUserProfileRepository UserProfiles
        {
            get
            {
                if (userProfileRepository == null)
                    userProfileRepository = new UserProfileRepository(db);
                return userProfileRepository;
            }
        }

        public IRepository<Game> Games
        {
            get
            {
                if (gameRepository == null)
                    gameRepository = new GameRepository(db);
                return gameRepository;
            }
        }

        public IRepository<Genre> Genres
        {
            get 
            {
                if (genreRepository == null)
                    genreRepository = new GenreRepository(db);
                return genreRepository;
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new CommentRepository(db);
                return commentRepository;
            }
        }

        public IRepository<Article> Articles
        {
            get
            {
                if(articleRepository == null)                
                    articleRepository = new ArticleRepository(db);
                return articleRepository;

            }
        }

        public IAccountRepository Accounts => throw new NotImplementedException();

        public IRepository<Order> Orders => throw new NotImplementedException();

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }    
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;
using DAL.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DAL.Repositories
{
    class UserPasswordRepository : IUserPasswordRepository
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ApplicationContext db;
        public UserPasswordRepository(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationContext db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.db = db;
        }
        public async Task<IdentityResult> ConfirmEmailAsync(User user, string code)
        {
            return await userManager.ConfirmEmailAsync(user, code);
        }

        public async Task<IdentityResult> CreateAsync(UserPassword item)
        {
            return await userManager.CreateAsync(item.User, item.Password);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public async Task<User> GetById(string id)
        {
            return await userManager.FindByIdAsync(id);
        }

        public async Task<User> GetByName(string username)
        {
            return await userManager.FindByNameAsync(username);
        }

        public async Task<string> GetEmailConfirmationToken(User user)
        {
            return await userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task SignOutAsync()
        {
            await signInManager.SignOutAsync();   
        }

        public async Task<SignInResult> UserSignInResult(string UserName, string Password, bool RememberMe)
        {
            return await signInManager.PasswordSignInAsync(UserName, Password, RememberMe, false);
        }
    }
}

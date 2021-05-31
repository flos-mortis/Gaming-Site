using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DAL.Entities;

namespace DAL.Interfaces
{
    interface IUserPasswordRepository
    {
        Task<IdentityResult> CreateAsync(UserPassword item);
        Task<SignInResult> UserSignInResult(string UserName, string Password, bool RememberMe);
        Task SignOutAsync();
        Task<User> GetByName(string username);
        Task<User> GetById(string id);
        Task<string> GetEmailConfirmationToken(User user);
        Task<IdentityResult> ConfirmEmailAsync(User user, string code);
        IEnumerable<User> GetAll();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace TestStore.Models
{
    public class CustomPasswordValidator : IPasswordValidator<User>
    {
        public int RequiredLength { get; set; }
        string UppercasePat = "(?=.*[A-Z])";
        string LowercasePat = "(?=.*[a-z])";
        public CustomPasswordValidator(int length)
        {
            RequiredLength = length;
        }
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
        {
            List<IdentityError> errors = new List<IdentityError>();

            if(String.IsNullOrEmpty(password) || password.Length < RequiredLength)
            {
                errors.Add(new IdentityError
                {
                    Description = $"Minimum password length is {RequiredLength}"
                });
               
            }  
            if (!Regex.IsMatch(password, UppercasePat))
            {
                errors.Add(new IdentityError
                {
                    Description = $"Password must contain at least one uppercase letter"
                });
            }
            if (!Regex.IsMatch(password, LowercasePat))
            {
                errors.Add(new IdentityError
                {
                    Description = $"Password must contain at least one lowercase letter"
                });
            }
            return Task.FromResult(errors.Count == 0
                ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }
    }
}

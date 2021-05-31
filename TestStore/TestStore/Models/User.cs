using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TestStore.Models
{
    public class User : IdentityUser
    {
        public DateTime? Year { get;set; }
        public string About { get; set; }
        public virtual Game FavGame { get; set; }
    }
}

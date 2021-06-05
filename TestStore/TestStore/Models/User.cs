using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TestStore.Models
{
    public class User : IdentityUser
    {
        public int Year { get;set; }
        public string About { get; set; }
        public string Country { get; set; }
        public byte[] Picture { get; set; }
        public virtual Game FavGame { get; set; }
        //public ICollection<Game> Games { get; set; }
    }
}

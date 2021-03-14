using System;
using System.Collections.Generic;

#nullable disable

namespace Playstore
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            Articles = new HashSet<Article>();
            CartItems = new HashSet<CartItem>();
            Comments = new HashSet<Comment>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FavGame { get; set; }
        public string About { get; set; }
        public string Image { get; set; }
        public DateTime DateCreated { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace Playstore
{
    public partial class Game
    {
        public Game()
        {
            CartItems = new HashSet<CartItem>();
            Comments = new HashSet<Comment>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public decimal Cost { get; set; }
        public DateTime DatePublished { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
        public string Image { get; set; }
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}

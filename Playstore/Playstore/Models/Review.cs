using System;
using System.Collections.Generic;

#nullable disable

namespace Playstore
{
    public partial class Review
    {
        public int Id { get; set; }
        public DateTime DatePublished { get; set; }
        public string Content { get; set; }
        public decimal Rate { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }

        public virtual Game Game { get; set; }
        public virtual UserInfo User { get; set; }
    }
}

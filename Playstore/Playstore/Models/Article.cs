using System;
using System.Collections.Generic;

#nullable disable

namespace Playstore
{
    public partial class Article
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public decimal Rating { get; set; }
        public int? Views { get; set; }
        public int UserId { get; set; }

        public virtual UserInfo User { get; set; }
    }
}

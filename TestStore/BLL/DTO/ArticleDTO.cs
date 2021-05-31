using System;

namespace BLL.DTO
{
    class ArticleDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public byte[] Picture { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Author { get; set; }
    }
}

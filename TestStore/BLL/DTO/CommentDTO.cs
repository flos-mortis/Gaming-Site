using System;

namespace BLL.DTO
{
    class CommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Article { get; set; }
        public string Author { get; set; }
    }
}

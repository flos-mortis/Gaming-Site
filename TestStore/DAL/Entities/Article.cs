using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.Entities
{
    class Article
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Content { get; set; }
        public byte[] Picture { get; set; }
        public DateTime? DateCreated { get; set; }
        public virtual User Author { get; set; }
    }
}

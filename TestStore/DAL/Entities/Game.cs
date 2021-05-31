using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.Entities
{
    class Game
    {
        public Game()
        {
            this.Genres = new HashSet<Genre>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descriprion { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Rating { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
    }
}

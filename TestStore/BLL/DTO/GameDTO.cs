using System;

namespace BLL.DTO
{
    class GameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descriprion { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Rating { get; set; }
    }
}

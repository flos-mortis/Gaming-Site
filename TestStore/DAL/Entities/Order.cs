
namespace DAL.Entities
{
    class Order
    {
        public int Id { get; set; }
        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}

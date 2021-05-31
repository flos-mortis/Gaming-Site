using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.Entities
{
    class UserPassword
    {
        public User User { get; set; }
        public string Password { get; set; }
    }
}

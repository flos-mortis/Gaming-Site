using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestStore.Models
{
    [Keyless]
    public class Order
    {
        public string UserId { get; set; }
        public int GameId { get; set; }

    }
}

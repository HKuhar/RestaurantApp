using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string Name { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }

        public DateTime Time { get; set; }

        public Cart Cart { get; set; }
    }
}

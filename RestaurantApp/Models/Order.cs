using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a street")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Please enter a number"), Range(1, int.MaxValue)]
        public int Number { get; set; }

        public DateTime Time { get; set; }

        public Cart Cart { get; set; }
    }
}

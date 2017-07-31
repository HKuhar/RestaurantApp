using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantApp.Entities
{
    public partial class Dishes
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
 
        [Required(ErrorMessage = "Please enter a price"), Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
    }
}

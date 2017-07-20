using System;
using System.Collections.Generic;

namespace RestaurantApp.Entities
{
    public partial class Dishes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}

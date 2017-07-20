using RestaurantApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class CartItem
    {
        public Dishes Dish { get; set; }
        public int Quantity { get; set; }
    }
}

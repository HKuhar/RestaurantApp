using RestaurantApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class FakeOrdersRepository : IOrdersRepository
    {
        private List<Order> orders = new List<Order>
        {
            new Order{OrderId = 1, Name = "Hrvoje Kuhar", Street = "Ozaljska", Number = 73, Time = DateTime.Now, Cart = new Cart{cartItems = new List<CartItem>{ new CartItem { Dish = new Dishes { Name = "Murgh Curry" }, Quantity = 2 } } } }
        };

        private int nextId = 2;

        public void AddOrder(Order o)
        {
            o.OrderId = nextId++;
            orders.Add(o);
        }

        public ICollection<Order> GetOrders()
        {
            return orders;
        }
    }
}

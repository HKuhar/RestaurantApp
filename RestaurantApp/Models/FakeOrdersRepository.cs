using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class FakeOrdersRepository : IOrdersRepository
    {
        private List<Order> orders = new List<Order>();

        private int nextId = 1;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class DbOrdersRepository : IOrdersRepository
    {
        public void AddOrder(Order o)
        {
            throw new NotImplementedException();
        }

        public ICollection<Order> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}

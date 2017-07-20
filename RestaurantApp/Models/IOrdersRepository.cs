using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public interface IOrdersRepository
    {
        ICollection<Order> GetOrders();

        void AddOrder(Order o);

    }
}

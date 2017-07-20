using RestaurantApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public interface IDishesRepository
    {
        ICollection<Dishes> GetDishes();

        void Save(Dishes dish);

        void Delete(int id);

        void Update(Dishes dish);
    }
}

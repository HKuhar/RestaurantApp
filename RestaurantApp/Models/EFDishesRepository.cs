using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantApp.Entities;

namespace RestaurantApp.Models
{
    public class EFDishesRepository : IDishesRepository
    {
        RestaurantDBContext context;

        public EFDishesRepository(RestaurantDBContext c)
        {
            context = c;
        }

        public void Delete(int id)
        {
            Dishes dishToDelete = context.Dishes.FirstOrDefault(d => d.Id == id);
            context.Dishes.Remove(dishToDelete);
            context.SaveChanges();
        }

        public ICollection<Dishes> GetDishes()
        {
            return context.Dishes.ToList();
        }

        public void Save(Dishes dish)
        {
            context.Add(dish);
            context.SaveChanges();
        }

        public void Update(Dishes dish)
        {
            Dishes dishToUpdate = context.Dishes.FirstOrDefault(d => d.Id == dish.Id);

            dishToUpdate.Name = dish.Name;
            dishToUpdate.Description = dish.Description;
            dishToUpdate.Price = dish.Price;

            context.Update(dishToUpdate);
            context.SaveChanges();
        }
    }
}

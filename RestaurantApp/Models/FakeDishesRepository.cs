using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantApp.Entities;

namespace RestaurantApp.Models
{
    public class FakeDishesRepository : IDishesRepository
    {
        private List<Dishes> FakeList = new List<Dishes> {
            new Dishes { Id = 1, Name = "Murgh Curry", Description = "Pieces of chicken cooked in Traditional Indian spices", Price = 65.00m },
            new Dishes { Id = 2, Name = "Murgh Tikka Butter Masala", Description = "Boneless chicken tikka cooked in delicious tomato gravy", Price = 70.00m },
            new Dishes { Id = 3, Name = "Murgh Makhani", Description = "Shredded Tandoori chicken cooked in tomato based gravy, oriental spices & butter", Price = 70.00m },
            new Dishes { Id = 4, Name = "Gosht Lazeez Khada Masala", Description = "Succulent pieces of lamb well cooked in thick gravy with whole Indian spices", Price = 80.00m }
        };

        public ICollection<Dishes> GetDishes()
        {
            return FakeList;
        }

        public void Save(Dishes dish)
        {
            Dishes maxIdDish = FakeList.OrderByDescending(d => d.Id).FirstOrDefault();
            dish.Id = maxIdDish.Id + 1;
            FakeList.Add(dish);
        }

        public void Delete(int id)
        {
            Dishes dishToDelete = FakeList.FirstOrDefault(d => d.Id == id);
            FakeList.Remove(dishToDelete);
        }

        public void Update(Dishes dish)
        {
            Dishes dishToUpdate = FakeList.FirstOrDefault(d => d.Id == dish.Id);

            dishToUpdate.Name = dish.Name;
            dishToUpdate.Description = dish.Description;
            dishToUpdate.Price = dish.Price;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantApp.Entities;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Controllers
{

    [Route("api/[controller]")]
    public class DishesController : Controller
    {
        IDishesRepository dRepository;

        public DishesController(IDishesRepository dr)
        {
            dRepository = dr;
        }

        [HttpGet]
        public ICollection<Dishes> Get()
        {
            return dRepository.GetDishes();
        }

        [HttpPost]
        public void Post([FromBody] Dishes dish)
        {
            dRepository.Save(dish);
        }

        [HttpPut]
        public void Put([FromBody] Dishes dish)
        {
            dRepository.Update(dish);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dRepository.Delete(id);
        }
    }
}

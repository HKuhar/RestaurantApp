using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace RestaurantApp.Controllers
{   

    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        IOrdersRepository oRepository;

        public OrdersController(IOrdersRepository or)
        {
            oRepository = or;
        }

        public string Get()
        {
            return JsonConvert.SerializeObject(oRepository.GetOrders());
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Components
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Cart c = HttpContext.Session.Get<Cart>("Cart");
            decimal total = 0;

            foreach (var item in c.cartItems)
            {
                total += (item.Dish.Price * item.Quantity);
            }

            ViewBag.Total = total;
            ViewBag.CartIsEmpty = c.cartItems.Count == 0;

            return View(c);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Entities;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RestaurantApp.Controllers
{
    public class HomeController : Controller
    {
        IDishesRepository dRepository;
        IOrdersRepository oRepository;

        public HomeController(IDishesRepository dr, IOrdersRepository or)
        {
            dRepository = dr;
            oRepository = or;
        }

        public ViewResult Index()
        {
            if (HttpContext.Session.Get<Cart>("Cart") == null)
            {
                HttpContext.Session.Set<Cart>("Cart", new Cart()); 
            }
            return View();
        }

        public ViewResult DishesList()
        {
            ViewBag.Random = HttpContext.Session.GetInt32("random");
            return View(dRepository.GetDishes());
        }

        public ViewResult Add()
        {
            return View();
        }

        public RedirectToActionResult Save(Dishes dish)
        {
            dRepository.Save(dish);

            return RedirectToAction("DishesList");
        }

        public RedirectToActionResult Delete(int dishId)
        {
            dRepository.Delete(dishId);

            return RedirectToAction("DishesList");
        }

        public ViewResult Edit(int dishId)
        {
            Dishes dish = dRepository.GetDishes().FirstOrDefault(d => d.Id == dishId);
            return View(dish);
        }

        public RedirectToActionResult Update(Dishes dish)
        {
            dRepository.Update(dish);

            return RedirectToAction("DishesList");
        }

        public RedirectToActionResult AddToCart(int dishId)
        {
            Cart c = GetCart();

            if ((c.cartItems.FirstOrDefault(i => i.Dish.Id == dishId)) == null)
            {
                Dishes dishToAdd = dRepository.GetDishes().FirstOrDefault(d => d.Id == dishId);

                CartItem itemToAdd = new CartItem { Dish = dishToAdd, Quantity = 1 };

                c.cartItems.Add(itemToAdd);
            }
            else
            {
                (c.cartItems.FirstOrDefault(i => i.Dish.Id == dishId)).Quantity += 1;
            }

            SaveCart(c);

            return RedirectToAction("DishesList");
        }

        public RedirectToActionResult RemoveCartItem(int dishId)
        {
            Cart c = GetCart();

            CartItem itemToRemove = c.cartItems.FirstOrDefault(i => i.Dish.Id == dishId);
            if (itemToRemove.Quantity == 1)
            {
                c.cartItems.Remove(itemToRemove);
            }
            else
            {
                itemToRemove.Quantity -= 1;
            }


            SaveCart(c);

            return RedirectToAction("DishesList");
        }

        public ViewResult Checkout()
        {
            return View();
        }

        public ViewResult ProcessCheckout(Order order)
        {
            order.Time = DateTime.Now;
            order.Cart = GetCart();

            oRepository.AddOrder(order);

            return View(order);
        }

        public RedirectToActionResult ClearCart()
        {
            HttpContext.Session.Remove("Cart");
            return RedirectToAction("Index");
        }

        public ViewResult OrdersList()
        {
            return View(oRepository.GetOrders());
        }


        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.Get<Cart>("Cart") ?? new Cart();
            return cart;
        }


        private void SaveCart(Cart cart)
        {
            HttpContext.Session.Set<Cart>("Cart", cart);
        }

    }
}

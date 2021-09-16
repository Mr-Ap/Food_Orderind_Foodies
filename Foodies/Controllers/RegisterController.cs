using Foodies.Models;
using Foodies.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ShoppingCart shoppingCart;

        public RegisterController (ShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Order order)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Checkout");
            }
            return View(order);
        }
        public ActionResult Checkout()
        {
            ViewBag.CheckoutMsg = "Thank You for ordering from Foodies..!";
            var checkOutViewModel = new CheckOutViewModel
            {
                shoppingCartItems = shoppingCart.GetShoppingCartItems(),
                ShoppingCartTotal=shoppingCart.GetShoppingCartTotal()
            };
            shoppingCart.ClearCart();
            return View(checkOutViewModel);

        }
    }
}

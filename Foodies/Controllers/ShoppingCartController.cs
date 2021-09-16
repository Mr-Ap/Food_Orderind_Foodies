using Foodies.Models;
using Foodies.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IFoodItemRepo _foodItemRepo;

        public ShoppingCartController(ShoppingCart shoppingCart,IFoodItemRepo foodItemRepo)
        {
            _shoppingCart = shoppingCart;
            _foodItemRepo = foodItemRepo;
        }
        public IActionResult Index()
        {
            var CartItem = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = CartItem;

            var shoppingCartViewModel = new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal=_shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddtoShoppingCart(int fooditemid)
        {
            var selectedFoodItem = _foodItemRepo.AllFoodItems.FirstOrDefault(f => f.FoodId == fooditemid);
            if(selectedFoodItem!=null)
            {
                _shoppingCart.AddToCart(selectedFoodItem, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int fooditemid)
        {
            var selectedFoodItem = _foodItemRepo.AllFoodItems.FirstOrDefault(f => f.FoodId == fooditemid);
            if (selectedFoodItem != null)
            {
                _shoppingCart.RemoveFromCart(selectedFoodItem);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult ClearCart()
        {
            _shoppingCart.ClearCart();
            return RedirectToAction("Index");
        }
    }
}

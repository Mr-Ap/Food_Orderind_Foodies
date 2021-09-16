using Foodies.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Models
{
    public class ShoppingCart
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId };

        }

        public void AddToCart(FoodItem foodItem, int amount)
        {
            var shoppingCartItem =
                _applicationDbContext.ShoppingCartItems.SingleOrDefault(
                    s => s.FoodItem.FoodId == foodItem.FoodId && s.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    FoodItem = foodItem,
                    Quantity = 1
                };
                _applicationDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Quantity++;
            }
            _applicationDbContext.SaveChanges();
        }

        public int RemoveFromCart(FoodItem foodItem)
        {

            var shoppingCartItem =
                _applicationDbContext.ShoppingCartItems.SingleOrDefault(
                    s => s.FoodItem.FoodId == foodItem.FoodId && s.ShoppingCartId == ShoppingCartId);
            var localamount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                    localamount = shoppingCartItem.Quantity;
                }
                else
                {
                    _applicationDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _applicationDbContext.SaveChanges();

            return localamount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            /*if (_applicationDbContext.ShoppingCartItems != null)
            {
                ShoppingCartItems = _applicationDbContext.ShoppingCartItems.ToList();
                return ShoppingCartItems;
            }
            else
            {
                ShoppingCartItems = _applicationDbContext.ShoppingCartItems.Where(s => ShoppingCartId == ShoppingCartId).Include(s => s.FoodItem).ToList();
                return ShoppingCartItems;
            }*/

            return ShoppingCartItems ?? (
                ShoppingCartItems =
                _applicationDbContext.ShoppingCartItems.Where(c => ShoppingCartId == ShoppingCartId)
                .Include(s => s.FoodItem)
                .ToList());
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _applicationDbContext.ShoppingCartItems.Where(s => ShoppingCartId == ShoppingCartId).Select(s => s.FoodItem.Price * s.Quantity).Sum();
            return total;
        }

        public void ClearCart()
        {
            var rows = from obj in _applicationDbContext.ShoppingCartItems
                      select obj;
            foreach (var row in rows)
                _applicationDbContext.ShoppingCartItems.Remove(row);
            _applicationDbContext.SaveChanges();
        }
    }
}

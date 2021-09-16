using Foodies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.ViewModels
{
    public class CheckOutViewModel
    {
        public List<ShoppingCartItem> shoppingCartItems;
        public decimal ShoppingCartTotal;
    }
}

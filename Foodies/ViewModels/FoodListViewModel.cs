using Foodies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.ViewModels
{
    public class FoodListViewModel
    {
        public IEnumerable<FoodItem> FoodItems { get; set; }
        public string CurrentCategory { get; set; }
    }
}

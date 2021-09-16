using Foodies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<FoodItem> TodaysMenu { get; set; }
        public IEnumerable<FoodItem> TodaysDiscount { get; set; }
    }
}

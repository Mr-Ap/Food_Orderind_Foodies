using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Models
{
    public interface IFoodItemRepo
    {
        IEnumerable<FoodItem> AllFoodItems { get; }
        FoodItem GetFoodItemById(int fooditemid);

        public IEnumerable<FoodItem> TodaySpecial { get; }

        public IEnumerable<FoodItem> TodayDiscount { get; }
    }
}

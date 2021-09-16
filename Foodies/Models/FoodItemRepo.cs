using Foodies.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Models
{
    public class FoodItemRepo : IFoodItemRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;

        //DI
        public FoodItemRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IEnumerable<FoodItem> AllFoodItems
        {
            get { return _applicationDbContext.FoodItems.Include(c => c.Category); }
        }

        IEnumerable<FoodItem> IFoodItemRepo.TodaySpecial
        {
            get { return _applicationDbContext.FoodItems.Include(c => c.Category).Where(i => i.IsTodaySpecial == true); }
        }

        IEnumerable<FoodItem> IFoodItemRepo.TodayDiscount
        {
            get { return _applicationDbContext.FoodItems.Include(c => c.Category).Where(i => i.HasDiscount == true); }
        }

        //today special is remaining
        public FoodItem GetFoodItemById(int fooditemid)
        {
            return AllFoodItems.FirstOrDefault(item => item.FoodId == fooditemid);
        }
    }
}

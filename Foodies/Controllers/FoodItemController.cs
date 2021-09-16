using Foodies.Models;
using Foodies.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Controllers
{
    public class FoodItemController : Controller
    {
        private readonly IFoodItemRepo _foodItemRepo;
        private readonly ICategoryRepo _categoryRepo;

        //DI

        public FoodItemController(IFoodItemRepo foodItemRepo,ICategoryRepo categoryRepo)
        {
            _foodItemRepo = foodItemRepo;
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public IActionResult Index(string FoodSearch)
        {
            ViewData["GetFoodItems"] = FoodSearch;
           // var query = from x in _foodItemRepo.AllFoodItems select x;
            var query=_foodItemRepo.AllFoodItems;

            if (!String.IsNullOrEmpty(FoodSearch))
            {
                query = query.Where(x => x.FoodName.Contains(FoodSearch) || x.FoodDescription.Contains(FoodSearch));
            }
            return View(new FoodListViewModel { FoodItems = query.ToList(), CurrentCategory = "" });
        }

        public IActionResult CategoryFilter(string category)
        {
            IEnumerable<FoodItem> foodItems;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                foodItems = _foodItemRepo.AllFoodItems.OrderBy(f => f.FoodId);
                currentCategory = "All Food Dishes";
            }
            else
            {
                foodItems = _foodItemRepo.AllFoodItems.Where(f => f.Category.CategoryName == category).OrderBy(f => f.FoodId);
                currentCategory = _categoryRepo.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }
            return View(new FoodListViewModel { FoodItems = foodItems, CurrentCategory = currentCategory });
        }

        public IActionResult Details(int id)
        {
            var fooditem = _foodItemRepo.GetFoodItemById(id);
            if(fooditem==null)
            {
                return NotFound();
            }
            return View(fooditem);
        }
    }
}

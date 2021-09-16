using Foodies.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Component
{
    public class CategoryMenu:ViewComponent
    {
        private ICategoryRepo _categoryRepo;
        public CategoryMenu(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepo.AllCategories.OrderBy(c => c.CategoryName);
            return View(categories);
        }
    }
}

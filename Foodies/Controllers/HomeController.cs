using Foodies.Models;
using Foodies.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFoodItemRepo _foodItemRepo;
        //DI
        public HomeController(IFoodItemRepo foodItemRepo)
        {
            _foodItemRepo = foodItemRepo;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                TodaysMenu = _foodItemRepo.TodaySpecial,
                TodaysDiscount=_foodItemRepo.TodayDiscount
            };
            return View(homeViewModel);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


    }
}

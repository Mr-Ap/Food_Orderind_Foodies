using Foodies.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Models
{
    public class CategoryRepo:ICategoryRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CategoryRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IEnumerable<Category> AllCategories => _applicationDbContext.Categories;
    }
}

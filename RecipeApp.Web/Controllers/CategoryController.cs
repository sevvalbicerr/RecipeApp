using Microsoft.AspNetCore.Mvc;
using RecipeApp.Core.Services.Interfaces;

namespace RecipeApp.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GetAllAsync());
        }

        public  async Task<IActionResult> GetCategorywithRecipe(int id) {
            return View(await _categoryService.GetSingleCategoryByIdWithProducts(id));
        
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Core.Models;
using RecipeApp.Core.Services.Interfaces;
using RecipeApp.Core.ViewModels.AddViewModel;
using RecipeApp.Core.ViewModels.OutViewModels;
using RecipeApp.Dal.DbContexts;
using System.Security.Claims;

namespace RecipeApp.Web.Controllers
{

    public class RecipeController : Controller
    {
        private readonly IRecipeService _recipeService;
		private readonly ICategoryService _categoryService;
        public RecipeController(IRecipeService recipeService, AppDbContext appDbContext, ICategoryService categoryService)
        {
            _recipeService = recipeService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            //var entities=await _appDbContext.Recipes.ToListAsync();
            //return View(entities);
            return View(await _recipeService.GetAllAsync());
        }

		
	}
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Core.Services.Interfaces;
using RecipeApp.Dal.DbContexts;

namespace RecipeApp.Web.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeService _recipeService;
        private readonly AppDbContext _appDbContext;

        public RecipeController(IRecipeService recipeService, AppDbContext appDbContext)
        {
            _recipeService = recipeService;
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            //var entities=await _appDbContext.Recipes.ToListAsync();
            //return View(entities);
            return View(await _recipeService.GetAllAsync());
        }
    }
}

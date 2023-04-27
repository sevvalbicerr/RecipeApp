using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    [Authorize]
    public class RecipeController : Controller
    {
        private readonly IRecipeService _recipeService;
		private readonly ICategoryService _categoryService;
        private readonly IFavoriteService _favoriteService;
        private readonly UserManager<User> _userManager;
        public RecipeController(IRecipeService recipeService, AppDbContext appDbContext, ICategoryService categoryService, IFavoriteService favoriteService, UserManager<User> userManager)
        {
            _recipeService = recipeService;
            _categoryService = categoryService;
            _favoriteService = favoriteService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            
            return View(await _recipeService.GetAllAsync());
        }





        public async Task<IActionResult> Save()
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(RecipeAddViewModel recipeVM)    
        {
            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    var error = ModelState[key].Errors.FirstOrDefault();
                    if (error != null)
                    {
                        var errorMessage = error.ErrorMessage;
                    }
                }
            }

            if (ModelState.IsValid)
            {
                var newMember = new RecipeAddViewModel
                {
                    Name = recipeVM.Name,
                    Description = recipeVM.Description,
                    Ingredients = recipeVM.Ingredients,
                    //TODO: image ekleme??
                    Image = recipeVM.Image,
                    CategoryId = recipeVM.CategoryId,
                    CreatedDate = DateTime.Now,

                    UserId = recipeVM.UserId
                };
                var recipe = await _recipeService.AddAsync(newMember);

                return RedirectToAction(nameof(Index));
            }

            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

       
    
    }
}

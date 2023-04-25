using AutoMapper.Execution;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeApp.Core.Models;
using RecipeApp.Core.Services.Interfaces;
using RecipeApp.Core.ViewModels;
using RecipeApp.Core.ViewModels.AddViewModel;
using System.Security.Claims;

namespace RecipeApp.Web.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly SignInManager<User> signInManager;
		private readonly UserManager<User> _userManager;
        private readonly IRecipeService _recipeService;
        private readonly ICategoryService _categoryService;

        public MemberController(SignInManager<User> signInManager, UserManager<User> userManager, IRecipeService recipeService, ICategoryService categoryService)
        {
            this.signInManager = signInManager;
            _userManager = userManager;
            _recipeService = recipeService;
            _categoryService = categoryService;
        }

        public IActionResult Index() { 
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
           await signInManager.SignOutAsync();
           return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Profile()
        {
			var user = await _userManager.FindByNameAsync(User.Identity.Name);

			// Kullanıcının profil bilgilerini, UserProfileViewModel sınıfı kullanarak oluşturun
			var model = new UserProfileViewModel
			{
				FullName = user.FullName,
				UserName = user.UserName,
				Phone=user.PhoneNumber,
				Email = user.Email,

			};
			//TODO: Güncelle butonuna basıldığında?
			return View(model);
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
            byte[] imageBytes = System.IO.File.ReadAllBytes("default.jpg");
            if (ModelState.IsValid)
            {
                var newMember = new RecipeAddViewModel
                {
                    Name = recipeVM.Name,
                    Description = recipeVM.Description,
                    Ingredients = recipeVM.Ingredients,
                    //TODO: image ekleme??
                    Image = imageBytes,
                    CategoryId = recipeVM.CategoryId,
                    UserId=recipeVM.UserId
                    };
                await _recipeService.AddAsync(newMember);
                return RedirectToAction(nameof(Index));
            }

            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }
    }
}

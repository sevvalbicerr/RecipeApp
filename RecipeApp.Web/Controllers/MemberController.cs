using AutoMapper;
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
        private readonly IMapper _mapper;

		public MemberController(SignInManager<User> signInManager, UserManager<User> userManager, IRecipeService recipeService, ICategoryService categoryService, IMapper mapper)
		{
			this.signInManager = signInManager;
			_userManager = userManager;
			_recipeService = recipeService;
			_categoryService = categoryService;
			_mapper = mapper;
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
			return View(model);
		}

        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileViewModel model)
        {
			//Update için

			if (!ModelState.IsValid)
			{
				return View();
			}
			//TODO: Username'i güncelleyince db'de güncelleniyor fakat sonrasında hesabım sayfası açılmıyor
			//çünkü usernamedeğiştiğinde var user = await _userManager.FindByNameAsync(User.Identity.Name); bu satır null geliyor. 
			if (ModelState.IsValid)
			{

				var user = await _userManager.FindByIdAsync(model.Id);
				user.FullName = model.FullName;
				user.Email = model.Email;
                user.PhoneNumber = model.Phone;
				var result = await _userManager.UpdateAsync(user);
				if (result.Succeeded)
				{
					TempData["SuccessMessage"] = "Hesap Bilgileriniz Güncellendi.";
					return RedirectToAction(nameof(Profile));
				}
				
			}

			return View();

		}


		public async Task<IActionResult> Delete(int id)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
            

			await _userManager.DeleteAsync(user);
            await signInManager.SignOutAsync();

            return RedirectToAction(nameof(Index));

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
            //TODO:Malzemeleri Ekleme!!

            if (ModelState.IsValid)
            {
                var newMember = new RecipeAddViewModel
                {
                    Name = recipeVM.Name,
                    Description = recipeVM.Description,
                    Ingredients = recipeVM.Ingredients,
                    //TODO: image ekleme??
                    Image= recipeVM.Image,
                    CategoryId = recipeVM.CategoryId,
                    CreatedDate= DateTime.Now,
             
                    UserId=recipeVM.UserId
                    };
                // Ingredientler 
                //newMember.Ingredients = recipeVM.Ingredients.Select(x => new Ingredient
                //{
                //    Name = x.Name,
                //    Amount = x.Amount,
                //    Unit=x.Unit
                //}).ToList();
                await _recipeService.AddAsync(newMember);
                return RedirectToAction(nameof(Index));
            }

            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }
    }
}

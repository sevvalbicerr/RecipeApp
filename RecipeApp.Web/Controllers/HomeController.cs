using AspNetCore.Identity.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.Core.Models;
using RecipeApp.Web.Models;
using RecipeApp.Core.ViewModel;
using System.Diagnostics;

namespace RecipeApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var user=await _userManager.CreateAsync(new()
            {
                UserName = model.UserName,
                Email = model.Email
            }, model.PasswordConfirmed);
            if (user.Succeeded)
            {
                TempData["SuccessMessage"] = "Üyelik kayıt işlemi başarılı.";
                return Redirect(nameof(HomeController.Index));
            }
            foreach(var item in user.Errors) 
            {
                ModelState.AddModelError(string.Empty,item.Description);
            }
            return View();
        }

        
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model, string? returnUrl=null)
        {
            returnUrl = returnUrl ?? Url.Action("Index", "Home");

            var HasUser= await _userManager.FindByEmailAsync(model.Email);
            if (HasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Email veya şifre yanlış.");
                return View();

            }

            var result =await _signInManager.PasswordSignInAsync(HasUser, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                return Redirect(returnUrl);
            }
            ModelState.AddModelErrorList(new List<string>() { "Email veya şifre yanlış" });
            return View();
        }
    }
}
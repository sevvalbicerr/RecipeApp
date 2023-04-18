using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.Core.Models;
using RecipeApp.Web.Models;
using RecipeApp.Web.ViewModel;
using System.Diagnostics;

namespace RecipeApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
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
    }
}
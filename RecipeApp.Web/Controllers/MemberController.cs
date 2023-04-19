using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.Core.Models;

namespace RecipeApp.Web.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;

        public MemberController(SignInManager<AppUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public IActionResult Index() { 
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
           await signInManager.SignOutAsync();
           return RedirectToAction("Index", "Home");
        }

        public IActionResult Profile()
        {
			//TODO:user bilgilerinin çekilmesi ve Update eklenecek
			return View();
        }
        
      

    }
}

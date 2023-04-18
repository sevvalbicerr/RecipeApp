using System.ComponentModel.DataAnnotations;

namespace RecipeApp.Core.ViewModel
{
    public class SignInViewModel
    {
        [Required(ErrorMessage ="Eposta giriniz!")]
        [Display(Description ="Eposta")]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}

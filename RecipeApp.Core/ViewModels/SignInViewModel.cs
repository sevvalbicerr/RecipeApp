using System.ComponentModel.DataAnnotations;

namespace RecipeApp.Core.ViewModels
{
    public class SignInViewModel
    {
        [EmailAddress(ErrorMessage = "Email Formatı yanlış")]
        [Required(ErrorMessage = "Email boş bırakılamaz!")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Parola boş bırakılamaz!")]
        [Display(Name = "Parola")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}

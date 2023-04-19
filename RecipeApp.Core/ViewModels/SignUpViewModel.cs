using System.ComponentModel.DataAnnotations;

namespace RecipeApp.Core.ViewModels
{
    public class SignUpViewModel
    {
        public SignUpViewModel()
        {
            
        }
        public SignUpViewModel(string userName, string email, string password, string passwordConfirmed)
        {
            UserName = userName;
            Email = email;
            Password = password;
            PasswordConfirmed = passwordConfirmed;
        }
        // TODO: Validationlar doğru gelmiyor
        [Required(ErrorMessage ="Kullanıcı adı boş bırakılamaz!")]
        [Display(Name ="Kullanıcı Adı")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage ="Email Formatı yanlış")]
        [Required(ErrorMessage = "Email boş bırakılamaz!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parola boş bırakılamaz!")]
        [Display(Name = "Parola")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Parola boş bırakılamaz!")]
        [Display(Name = "Parola")]
        [Compare(nameof(Password),ErrorMessage ="Parolalar aynı değil!")]
        public string PasswordConfirmed { get; set; }

    }
}

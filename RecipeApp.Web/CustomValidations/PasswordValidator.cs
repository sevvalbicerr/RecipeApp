using RecipeApp.Web.Models;
using Microsoft.AspNetCore.Identity;
using RecipeApp.Core.Models;

namespace RecipeApp.Web.CustomValidations
{
    public class PasswordValidator : IPasswordValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string? password)
        {
            var errors= new List<IdentityError>();
            if (password!.ToLower().Contains(user.UserName!.ToLower()))
            {
                errors.Add(new IdentityError { Code = "PasswordContainUserName", Description = "Şifre alanı kullanıcı adı içeremez. " });

            }

            if (password.ToLower().StartsWith("1234")){
                errors.Add(new IdentityError { Code = "PasswordNoContain1234", Description = "Şifre alanı ardışık sayı içeremez." });
            }

            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }

            return Task.FromResult(IdentityResult.Success);


        }
    }
}

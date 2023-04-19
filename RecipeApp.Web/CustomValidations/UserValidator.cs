using RecipeApp.Web.Models;
using Microsoft.AspNetCore.Identity;
using RecipeApp.Core.Models;

namespace RecipeApp.Web.CustomValidations
{
    public class UserValidator : IUserValidator<User>
    {
        // ! BP ! mümkün olduğunda else,else if kullanma
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            var errors= new List<IdentityError>();
            var isDigit = int.TryParse(user.UserName[0].ToString(), out _);

            if (isDigit)
            {
                errors.Add(new IdentityError() { Code = "UsernameContainFirstLetterDigit", 
                    Description="Kullanıcı adı rakamla başlayamaz." });
            }

            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }
            return Task.FromResult(IdentityResult.Success);

        }


    }
}

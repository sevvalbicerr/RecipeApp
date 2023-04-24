using RecipeApp.Core.Models;
using RecipeApp.Dal.DbContexts;
using RecipeApp.Web.CustomValidations;
using RecipeApp.Web.Models;

namespace AspNetCore.Identity.Extensions
{
    public static class StartupExtensions
    {
        public static void AddIdentityWithExt(this IServiceCollection services)
        {
            services.AddIdentity<User, UserRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvwyz1234567890_";

                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = false;
            }).AddPasswordValidator<PasswordValidator>()
            .AddUserValidator<UserValidator>()
            .AddEntityFrameworkStores<AppDbContext>();
        }
    }
}

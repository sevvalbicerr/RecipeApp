using RecipeApp.Core.Models;
using RecipeApp.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Core.Repositories.Interfaces
{
    public interface IFavoriteRepository:IRepository<Favorite>
    {
        Favorite GetFavoriteWithRecipeAndUser(int recipeId,string UserId);
        Task<IEnumerable<Favorite>> GetAllFavoritesWithRecipe();
    }
}

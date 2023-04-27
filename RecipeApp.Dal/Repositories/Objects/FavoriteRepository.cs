using Microsoft.EntityFrameworkCore;
using RecipeApp.Core.Models;
using RecipeApp.Core.Repositories.Interfaces;
using RecipeApp.Dal.DbContexts;
using RecipeApp.Dal.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Dal.Repositories.Objects
{
    public class FavoriteRepository : Repository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public Favorite GetByRecipeAndUser(int recipeId, string UserId)
        {
            return _dbContext.Favorites.FirstOrDefault(f => f.RecipeId == recipeId && f.UserId == UserId);
        }

        public async Task<IEnumerable<Favorite>> GetAllfavoriteswithRecipe()
        {
           return await _dbContext.Favorites.Include(x => x.Recipe).ToListAsync(); 
             
        }

     
    }
}

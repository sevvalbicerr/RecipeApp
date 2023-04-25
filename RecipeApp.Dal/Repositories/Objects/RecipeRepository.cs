using Microsoft.EntityFrameworkCore;
using RecipeApp.Core.Models;
using RecipeApp.Core.Repositories.Interfaces;
using RecipeApp.Core.ViewModels.AddViewModel;
using RecipeApp.Dal.DbContexts;
using RecipeApp.Dal.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Dal.Repositories.Objects
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        private readonly DbSet<Recipe> _dbSet;
        public RecipeRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbSet = dbContext.Set<Recipe>();
        }

       
    }
}

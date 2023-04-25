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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

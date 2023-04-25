using RecipeApp.Core.Models;
using RecipeApp.Core.Repositories.Base;
using RecipeApp.Core.ViewModels.AddViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Core.Repositories.Interfaces
{
    public interface IRecipeRepository:IRepository<Recipe>
    {
        
    }
}

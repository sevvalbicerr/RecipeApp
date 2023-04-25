using RecipeApp.Core.Models;
using RecipeApp.Core.Services.Base;
using RecipeApp.Core.ViewModels.OutViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Core.Services.Interfaces
{
    public interface ICategoryService:IService<Category,CategoryOutVM>
    {

    }
}

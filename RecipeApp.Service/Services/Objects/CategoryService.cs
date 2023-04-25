using AutoMapper;
using RecipeApp.Core.Models;
using RecipeApp.Core.Repositories.Base;
using RecipeApp.Core.Services.Interfaces;
using RecipeApp.Core.ViewModels.OutViewModels;
using RecipeApp.Service.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Service.Services.Objects
{
    public class CategoryService : Service<Category, CategoryOutVM>, ICategoryService
    {
        public CategoryService(IRepository<Category> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

using AutoMapper;
using RecipeApp.Core.Models;
using RecipeApp.Core.Repositories.Base;
using RecipeApp.Core.Repositories.Interfaces;
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
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(IRepository<Category> repository, IMapper mapper, ICategoryRepository categoryRepository) : base(repository, mapper)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryOutVM> GetSingleCategoryByIdWithRecipes(int categoryId)
        {
            var category = await _categoryRepository.GetSingleCategoryByIdWithProducts(categoryId);
            var categoryDTO = _mapper.Map<CategoryOutVM>(category);
            return categoryDTO;
        }

       
    }
}

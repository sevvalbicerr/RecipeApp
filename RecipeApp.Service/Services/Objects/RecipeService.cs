using AutoMapper;
using RecipeApp.Core.Models;
using RecipeApp.Core.Repositories.Base;
using RecipeApp.Core.Repositories.Interfaces;
using RecipeApp.Core.Services.Interfaces;
using RecipeApp.Core.ViewModels.AddViewModel;
using RecipeApp.Core.ViewModels.OutViewModels;
using RecipeApp.Service.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Service.Services.Objects
{
    public class RecipeService : Service<Recipe, RecipeOutVM>, IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        public RecipeService(IRepository<Recipe> repository, IMapper mapper, IRecipeRepository recipeRepository) : base(repository, mapper)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<RecipeOutVM> AddAsync(RecipeAddViewModel dto)
        {
            var entity = _mapper.Map<Recipe>(dto);
            await _recipeRepository.AddAsync(entity);
            await _recipeRepository.SaveChangeAsync();
            var entityVm = _mapper.Map<RecipeOutVM>(entity);
            return entityVm;
        }
    }
}

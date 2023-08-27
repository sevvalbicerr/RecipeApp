using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RecipeApp.Service.Services.Objects
{
    public class RecipeServicewithNoCaching : Service<Recipe, RecipeOutVM>, IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        public RecipeServicewithNoCaching(IRepository<Recipe> repository, IMapper mapper, IRecipeRepository recipeRepository) : base(repository, mapper)
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

        public List<RecipeOutVM> GetAllRecipesInOrderByDateDesc()
        {
            var entities =  _recipeRepository.GetAllRecipesInOrderByDateDesc();
            var entitiesVM = _mapper.Map<List<RecipeOutVM>>(entities);
            return entitiesVM;
        }

        public async Task<List<RecipeOutVM>> GetRecipeWithFilter(string SearchString)
        {
            if (string.IsNullOrWhiteSpace(SearchString))
            {
                // Boş sorgu durumunda tüm kayıtları getirin
                var recipeX = await _recipeRepository.GetAll().ToListAsync();
                var recipeOutVM = _mapper.Map<List<RecipeOutVM>>(recipeX);
                return recipeOutVM;
               
            }
            var searchTerms = SearchString.Trim().Split(' ');
            var recipe= await _recipeRepository.GetAll().ToListAsync();
            foreach (var term in searchTerms)
            {
                recipe = recipe.Where(r => searchTerms.Any(s => r.Name.Contains(s) || r.Ingredients.Contains(s) || r.Description.Contains(s))).ToList();
                var recipeOutVM = _mapper.Map<List<RecipeOutVM>>(recipe);
                return recipeOutVM;
            }

           
            
            return null;
        }
    }
}

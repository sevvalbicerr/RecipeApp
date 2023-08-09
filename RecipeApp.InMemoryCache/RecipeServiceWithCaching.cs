using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RecipeApp.Core.Models;
using RecipeApp.Core.Repositories.Interfaces;
using RecipeApp.Core.Services.Interfaces;
using RecipeApp.Core.ViewModels;
using RecipeApp.Core.ViewModels.AddViewModel;
using RecipeApp.Core.ViewModels.OutViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.InMemoryCache
{
    public class RecipeServiceWithCaching : IRecipeService
    {

        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly string CacheKey = "recipesCache";

        public RecipeServiceWithCaching(IMemoryCache cache, IMapper mapper, IRecipeRepository recipeRepository)
        {
            _cache = cache;
            _mapper = mapper;
            _recipeRepository = recipeRepository;
            if (!_cache.TryGetValue(CacheKey, out _))
            {
                _cache.Set(CacheKey, _recipeRepository.GetAllRecipeWithOrderedByDesc());
            }
        }

        public Task<RecipeOutVM> AddAsync(RecipeAddViewModel dto)
        {
            throw new NotImplementedException();
        }

        public Task<RecipeOutVM> AddAsync(RecipeOutVM entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RecipeOutVM>> GetAllAsync()
        {
            return Task.FromResult(_cache.Get<IEnumerable<RecipeOutVM>>(CacheKey));
        }

        public Task<RecipeOutVM> GetByIdAsync(int id)
        {
            var recipe = _cache.Get<List<RecipeOutVM>>(CacheKey).FirstOrDefault(x => x.Id == id);
            if (recipe == null)
            {
                throw new Exception($"{typeof(Recipe).Name}({id}) not Found.");
            }
            return Task.FromResult(recipe);
        }

        public List<RecipeOutVM> GetRecipeOrderByDesc()
        {
            var entities = _recipeRepository.GetAllRecipeWithOrderedByDesc();
            CacheAllRecipesAsync();
            var entitiesVM = _mapper.Map<List<RecipeOutVM>>(entities);
            return entitiesVM;
        }

        public Task<List<RecipeOutVM>> GetRecipewithFilter(string SearchString)
        {
            throw new NotImplementedException();
        }

        public Task<NoContentViewModel> UpdateAsync(RecipeOutVM entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<RecipeOutVM>> WhereAsync(Expression<Func<Recipe, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task CacheAllRecipesAsync()
        {
            await _cache.Set(CacheKey, _recipeRepository.GetAll().ToListAsync());
        }
        public void CacheAllRecipes()
        {
            _cache.Set(CacheKey, _recipeRepository.GetAll().ToList());
        }
    }
}

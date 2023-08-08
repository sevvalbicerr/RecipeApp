using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RecipeApp.Core.Models;
using RecipeApp.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Service.Services.Objects
{
    public class RecipeServiceWithCache
    {
        private readonly IRecipeRepository _repository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly string CasheProductKey = "RecipesCache";
        public RecipeServiceWithCache(IMemoryCache cache, IMapper mapper, IRecipeRepository repository)
        {
            _cache = cache;
            _mapper = mapper;
            _repository = repository;
            if (!_cache.TryGetValue(CasheProductKey, out _))
            {
                _cache.Set(CasheProductKey, _repository.GetAll());
            }
        }

        public void CasheAllRecipes()
        {
            _cache.Set(CasheProductKey, _repository.GetAll().ToList());
        }
        

        public Task<IEnumerable<Recipe>> GetAllAsync()
        {
            return Task.FromResult(_cache.Get<IEnumerable<Recipe>>(CasheProductKey));
        }

        public Task<Recipe> GetByIdAsync(int id)
        {
            var product = _cache.Get<List<Recipe>>(CasheProductKey).FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                throw new Exception($"{typeof(Recipe).Name}({id}) not Found.");
            }
            return Task.FromResult(product);
        }

        

        //public async Task RemoveAsync(Recipe entity)
        //{
        //    _repository.Remove(entity);
        //    await CasheAllProductsAsync();

        //}

     
        //public async Task UpdateAsync(Recipe entity)
        //{
        //    _repository.Update(entity);
        //    await CasheAllProductsAsync();
        //}

     
        public async Task CasheAllProductsAsync()
        {
            await _cache.Set(CasheProductKey, _repository.GetAll().ToListAsync());
        }
        public void CasheAllProducts()
        {
            _cache.Set(CasheProductKey, _repository.GetAll().ToList());
        }
    }
}

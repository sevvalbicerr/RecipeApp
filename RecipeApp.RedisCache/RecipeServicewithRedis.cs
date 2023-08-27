using AutoMapper;
using Newtonsoft.Json;
using RecipeApp.Core.Models;
using RecipeApp.Core.Repositories.Interfaces;
using RecipeApp.Core.Services.Interfaces;
using RecipeApp.Core.ViewModels;
using RecipeApp.Core.ViewModels.AddViewModel;
using RecipeApp.Core.ViewModels.OutViewModels;
using RecipeApp.Dal.Repositories.Objects;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.RedisCache
{
    public class RecipeServicewithRedis : IRecipeService
    {

        //TODO: Dto bug-fix yapılmalı,sonrasında servis metotları düzenlenecek.

        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _db;
        private readonly IMapper _mapper;
        private readonly IRecipeRepository _repository;
        private readonly string CacheKey = "RecipesRedisCache";

        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        public RecipeServicewithRedis(IConnectionMultiplexer redis, IRecipeRepository repository, IMapper mapper)
        {
            _redis = redis;

            _db = _redis.GetDatabase();

            _repository = repository;

          
            if (string.IsNullOrEmpty(_db.StringGet(CacheKey)))
            {
                var jsondata = JsonConvert.SerializeObject(_repository.GetAllRecipesInOrderByDateDesc(),settings);
                _db.StringSet(CacheKey, jsondata);
            }
            _mapper = mapper;
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
        public async Task<IEnumerable<RecipeOutVM>> GetAllAsync()
        {
            var recipes =await _db.StringGetAsync(CacheKey);
            var jsonData = JsonConvert.DeserializeObject<IEnumerable<RecipeOutVM>>(recipes);
            return jsonData;

        }
        public IEnumerable<RecipeOutVM> GetAll()
        {
            var recipes =  _db.StringGet(CacheKey);
            var jsonData=JsonConvert.DeserializeObject<IEnumerable<RecipeOutVM>>(recipes );
            return jsonData;
        }

        public RecipeOutVM GetById(int id)
        {
            var cachedValue =  _db.StringGet($"Recipe:{id}");
            var jsonData = JsonConvert.DeserializeObject<RecipeOutVM>(cachedValue);
            if (jsonData == null)
            {
                throw new Exception($"{typeof(Recipe).Name}({id}) not Found.");
            }
            return jsonData;
        }
        public Task<RecipeOutVM> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public List<RecipeOutVM> GetAllRecipesInOrderByDateDesc()
        {
            var entities = _repository.GetAllRecipesInOrderByDateDesc();
            CacheAllRecipes();
            var entitiesVM = _mapper.Map<List<RecipeOutVM>>(entities);
            return entitiesVM;
        }

        public Task<List<RecipeOutVM>> GetRecipeWithFilter(string SearchString)
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

       
        public void CacheAllRecipes()
        {
            var jsondata = JsonConvert.SerializeObject(_repository.GetAllRecipesInOrderByDateDesc(), settings);
            _db.StringSet(CacheKey, jsondata);
        }
    }
}

using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.InMemoryCache
{
    public class CacheManager : ICacheManager
    {
        private readonly IMemoryCache _memoryCache;

        public CacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync<T>(string key)
        {
            try
            {
                T item=(T) _memoryCache.Get(key);
                return Task.FromResult(item);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void Remove<T>(string key)
        {
            var res = true;
            try
            {
                if (!string.IsNullOrEmpty(key))
                {
                     _memoryCache.Remove(key);
                }
                else
                    res = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Set<T>(string key, T value, DateTimeOffset ExpirationTime)
        {
            var res = true;
            try
            {
                if(!string.IsNullOrEmpty(key))
                {
                    _memoryCache.Set(key, value, ExpirationTime);
                }
                else
                    res=false;
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update<T>(string key, T value)
        {
            throw new NotImplementedException();
        }
    }
}

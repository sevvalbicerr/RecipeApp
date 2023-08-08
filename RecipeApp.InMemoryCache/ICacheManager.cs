using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.InMemoryCache
{
    public interface ICacheManager:IDisposable
    {
        Task<T> GetAsync<T>(string key);

        void Update<T>(string key, T value);

        void Remove<T>(string key);

        bool Set<T>(string key, T value,DateTimeOffset ExpirationTime);
    }
}

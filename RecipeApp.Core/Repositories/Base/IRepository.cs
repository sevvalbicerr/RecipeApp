using System.Linq.Expressions;

namespace RecipeApp.Core.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IQueryable<T>> GetAllAsync();
        //Buna belki gerek yoktur emin değilim.
        Task<T> GetByIdAsync(int id);

        Task<IQueryable<T>> WhereAsync(Expression<Func<T,bool>> expression);

        void SaveChange();
        Task SaveChangeAsync();


    }
}

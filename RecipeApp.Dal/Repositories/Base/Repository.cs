using Microsoft.EntityFrameworkCore;
using RecipeApp.Core.Repositories.Base;
using RecipeApp.Dal.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Dal.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext dbContext, DbSet<T> dbSet)
        {
            _dbContext = dbContext;
            _dbSet = dbSet;
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void DeleteAsync(T entity)
        {
            //TODO: id ile mi işlem yapmam lazım, Bunu araştır. 
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            var c = _dbSet.AsNoTracking().AsQueryable();
            return c;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangeAsync()
        {
           await _dbContext.SaveChangesAsync();
        }

        public void UpdateAsync(T entity)
        {
             _dbSet.Update(entity);
        }

        public async Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }
    }
}

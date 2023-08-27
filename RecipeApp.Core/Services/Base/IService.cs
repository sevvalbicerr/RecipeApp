using RecipeApp.Core.Models.Base;
using RecipeApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Core.Services.Base
{
    public interface IService<InT,OutT> where InT : BaseEntity where OutT : class
    {
        Task<OutT> AddAsync(OutT entity);
        Task<NoContentViewModel> UpdateAsync(OutT entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<OutT>> GetAllAsync();
        Task<OutT> GetByIdAsync(int id);

        Task<IQueryable<OutT>> WhereAsync(Expression<Func<InT, bool>> expression);
    }
}

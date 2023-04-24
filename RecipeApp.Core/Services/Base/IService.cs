using RecipeApp.Core.DTOs;
using RecipeApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Core.Services.Base
{
    public interface IService<InT,OutT> where InT : BaseEntity where OutT : class, new()
    {
        Task<OutT> AddAsync(OutT entity);
        Task<NoContentDto> UpdateAsync(OutT entity);
        Task<NoContentDto> DeleteAsync(int id);
        Task<IQueryable<OutT>> GetAllAsync();
        //Buna belki gerek yoktur emin değilim.
        Task<OutT> GetByIdAsync(int id);

        Task<IQueryable<OutT>> WhereAsync(Expression<Func<InT, bool>> expression);
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Core.Models.Base;
using RecipeApp.Core.Repositories.Base;
using RecipeApp.Core.Services.Base;
using RecipeApp.Core.ViewModels;
using RecipeApp.Core.ViewModels.OutViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Service.Services.Base
{
    public class Service<InT, OutT> : IService<InT, OutT> where InT : BaseEntity where OutT : class
    {
        protected readonly IRepository<InT> _repository;
        protected readonly IMapper _mapper;
        

        public Service(IRepository<InT> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OutT> AddAsync(OutT entity)
        {
            var NewEntity= _mapper.Map<InT>(entity);

            try
            {
                await _repository.AddAsync(NewEntity);
                await _repository.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding favorite to the database.", ex);
            }
           
            
            return entity;

        }

        public async Task DeleteAsync(int id)
        {
            var entity=await _repository.GetByIdAsync(id);
            _repository.DeleteAsync(entity);
            await _repository.SaveChangeAsync();
             
        }

        public async Task<IEnumerable<OutT>> GetAllAsync()
        {
            var entities =await  _repository.GetAll().ToListAsync();
            var entityVM=_mapper.Map<List<OutT>>(entities);
            return entityVM;
        }

        public async Task<OutT> GetByIdAsync(int id)
        {
            var entitiy= await _repository.GetByIdAsync(id);
            var entityVM=_mapper.Map<OutT>(entitiy);
            return entityVM;
        }

        public Task<NoContentViewModel> UpdateAsync(OutT entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<OutT>> WhereAsync(Expression<Func<InT, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}

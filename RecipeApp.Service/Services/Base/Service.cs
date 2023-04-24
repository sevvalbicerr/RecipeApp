using AutoMapper;
using RecipeApp.Core.Models;
using RecipeApp.Core.Repositories.Base;
using RecipeApp.Core.Services.Base;
using RecipeApp.Core.ViewModels;
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
        private readonly IRepository<InT> _repository;
        protected readonly IMapper _mapper;
        public Service()
        {
        }

        public Service(IRepository<InT> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OutT> AddAsync(OutT entity)
        {
            var NewEntity= _mapper.Map<InT>(entity);
            await _repository.AddAsync(NewEntity);
            return entity;

        }

        public Task<NoContentViewModel> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OutT>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var entityVM=_mapper.Map<IEnumerable<OutT>>(entities);
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

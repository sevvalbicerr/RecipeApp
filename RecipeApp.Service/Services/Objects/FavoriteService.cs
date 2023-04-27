using AutoMapper;
using RecipeApp.Core.Models;
using RecipeApp.Core.Repositories.Base;
using RecipeApp.Core.Repositories.Interfaces;
using RecipeApp.Core.Services.Interfaces;
using RecipeApp.Core.ViewModels.OutViewModels;
using RecipeApp.Service.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Service.Services.Objects
{
    public class FavoriteService : Service<Favorite, FavoriteOutVM>, IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;
        public FavoriteService(IRepository<Favorite> repository, IMapper mapper, IFavoriteRepository favoriteRepository) : base(repository, mapper)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task<IEnumerable<FavoriteOutVM>> GetAllfavoriteswithRecipe()
        {
            var fav=await _favoriteRepository.GetAllfavoriteswithRecipe();
            var favVm= _mapper.Map<IEnumerable<FavoriteOutVM>>(fav);
            return favVm;
        }

        public FavoriteOutVM GetByRecipeAndUser(int recipeId, string UserId)
        {
          var fav= _favoriteRepository.GetByRecipeAndUser(recipeId, UserId);
            var FavVM=_mapper.Map<FavoriteOutVM>(fav);
            return FavVM;

        }
    }
}

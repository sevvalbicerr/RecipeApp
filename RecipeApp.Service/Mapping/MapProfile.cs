using AutoMapper;
using RecipeApp.Core.Models;
using RecipeApp.Core.ViewModels.AddViewModel;
using RecipeApp.Core.ViewModels.OutViewModels;

namespace NLayer.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Recipe,RecipeOutVM>().ReverseMap();
            CreateMap<Recipe,RecipeAddViewModel>().ReverseMap();
            CreateMap<Category,CategoryOutVM>().ReverseMap();
        }
    }
}

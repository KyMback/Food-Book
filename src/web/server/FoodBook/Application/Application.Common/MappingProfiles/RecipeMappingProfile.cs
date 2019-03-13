using AutoMapper;
using FoodBook.Application.Common.Recipes;
using FoodBook.Domain.Entities.Recipes;
using FoodBook.Infrastructure.Common.Extensions;
using JetBrains.Annotations;

namespace FoodBook.Application.Common.MappingProfiles
{
    [UsedImplicitly]
    internal class RecipeMappingProfile : Profile
    {
        public RecipeMappingProfile()
        {
            CreateMap<RecipeCreateRequest, Recipe>()
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                .ForMember(d => d.Ingredients, o => o.MapFrom(s => s.Ingredients))
                .ForAllOtherMembers(o => o.Ignore());
            
            CreateMap<Recipe, RecipeCreateResponse>();
        }
    }
}
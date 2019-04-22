using AutoMapper;
using FoodBook.Application.Common.Recipes.Create;
using FoodBook.Application.Common.Recipes.Update;
using FoodBook.Domain.Entities.Recipes;
using JetBrains.Annotations;

namespace FoodBook.Application.Common.Recipes
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
            
            CreateMap<RecipeUpdateRequest, Recipe>()
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                .ForMember(d => d.Ingredients, o => o.MapFrom(s => s.Ingredients))
                .ForAllOtherMembers(o => o.Ignore());
            
            CreateMap<Recipe, RecipeUpdateResponse>();
        }
    }
}
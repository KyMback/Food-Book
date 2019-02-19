using AutoMapper;
using FoodBook.Application.Recipes;
using FoodBook.Domain.Entities.Entities.Recipes;
using FoodBook.Infrastructure.Common.Extensions;

namespace FoodBook.Application.MappingProfiles
{
    public class RecipeMappingProfile : Profile
    {
        public RecipeMappingProfile()
        {
            CreateMap<RecipeCreateRequest, Recipe>()
                .Ignore(recipe => recipe.Steps)
                .Ignore(recipe => recipe.Id);
            CreateMap<Recipe, RecipeCreateResponse>();
        }
    }
}
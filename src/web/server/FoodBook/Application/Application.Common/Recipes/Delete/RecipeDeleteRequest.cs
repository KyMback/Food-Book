using System;
using MediatR;

namespace FoodBook.Application.Common.Recipes.Delete
{
    public class RecipeDeleteRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
using System.Threading;
using System.Threading.Tasks;
using FoodBook.Domain.Recipes;
using FoodBook.Infrastructure.DataAccess.Interfaces;
using JetBrains.Annotations;
using MediatR;

namespace FoodBook.Application.Common.Recipes.Delete
{
    [UsedImplicitly]
    internal class RecipeDeleteHandler : IRequestHandler<RecipeDeleteRequest>
    {
        private readonly IRecipeService _recipeService;
        private readonly IUnitOfWork _unitOfWork;

        public RecipeDeleteHandler(
            IRecipeService recipeService,
            IUnitOfWork unitOfWork)
        {
            _recipeService = recipeService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RecipeDeleteRequest request, CancellationToken cancellationToken)
        {
            await _recipeService.Delete(request.Id);
            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}
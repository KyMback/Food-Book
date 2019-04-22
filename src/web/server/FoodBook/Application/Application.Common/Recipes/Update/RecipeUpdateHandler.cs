using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FoodBook.Domain.Entities.Recipes;
using FoodBook.Domain.Recipes;
using FoodBook.Infrastructure.Common.Services;
using FoodBook.Infrastructure.DataAccess.Interfaces;
using JetBrains.Annotations;
using MediatR;

namespace FoodBook.Application.Common.Recipes.Update
{
    [UsedImplicitly]
    internal class RecipeUpdateHandler : IRequestHandler<RecipeUpdateRequest, RecipeUpdateResponse>
    {
        private readonly IRecipeService _recipeService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExecutionContextService _executionContextService;
        private readonly IMapper _mapper;

        public RecipeUpdateHandler(
            IRecipeService recipeService,
            IUnitOfWork unitOfWork,
            IExecutionContextService executionContextService,
            IMapper mapper)
        {
            _recipeService = recipeService;
            _unitOfWork = unitOfWork;
            _executionContextService = executionContextService;
            _mapper = mapper;
        }

        public async Task<RecipeUpdateResponse> Handle(RecipeUpdateRequest request, CancellationToken cancellationToken)
        {
            Recipe original = await _recipeService.GetById(request.Id);
            if (original.CreatedById != _executionContextService.GetCurrentUserAccountId())
            {
                throw new InvalidOperationException();
            }

            Recipe recipe = _mapper.Map(request, original);
            await _recipeService.Save(recipe);
            await _unitOfWork.Commit();
            return _mapper.Map<RecipeUpdateResponse>(recipe);
        }
    }
}
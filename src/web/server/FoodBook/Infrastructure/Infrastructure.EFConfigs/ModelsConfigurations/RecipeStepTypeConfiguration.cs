using FoodBook.Domain.Entities.Recipes;
using FoodBook.Infrastructure.EFConfigs.Constants;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodBook.Infrastructure.EFConfigs.ModelsConfigurations
{
    [UsedImplicitly]
    public class RecipeStepTypeConfiguration : BaseEntityTypeConfiguration<RecipeStep>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<RecipeStep> builder)
        {
            builder
                .Property(step => step.Description)
                .HasMaxLength(LengthConstants.LongMaxLength);
            builder
                .Property(step => step.StepNumber)
                .IsRequired();
            builder
                .Property(step => step.RecipeId)
                .IsRequired();
            builder
                .HasIndex(step => step.RecipeId);
        }
    }
}
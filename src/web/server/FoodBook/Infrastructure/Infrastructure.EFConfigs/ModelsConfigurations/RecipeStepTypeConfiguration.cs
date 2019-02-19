using FoodBook.Domain.Entities.Entities.Recipes;
using FoodBook.Infrastructure.EFConfigs.Constants;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodBook.Infrastructure.EFConfigs.ModelsConfigurations
{
    [UsedImplicitly]
    public class RecipeStepTypeConfiguration : BaseEntityTypeConfiguration<RecipeStep>
    {
        public override void Configure(EntityTypeBuilder<RecipeStep> builder)
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
            
            base.Configure(builder);
        }
    }
}
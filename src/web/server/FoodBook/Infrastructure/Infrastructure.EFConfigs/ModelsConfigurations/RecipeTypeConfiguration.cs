using FoodBook.Domain.Entities.Entities.Recipes;
using FoodBook.Infrastructure.EFConfigs.Constants;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodBook.Infrastructure.EFConfigs.ModelsConfigurations
{
    [UsedImplicitly]
    public class RecipeTypeConfiguration : BaseEntityTypeConfiguration<Recipe>
    {
        public override void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder
                .Property(recipe => recipe.Title)
                .HasMaxLength(LengthConstants.ShortMaxLength)
                .IsRequired();
            builder
                .Property(recipe => recipe.Ingredients)
                .HasMaxLength(LengthConstants.LongMaxLength)
                .IsRequired();
            builder
                .HasMany(recipe => recipe.Steps)
                .WithOne()
                .HasForeignKey(step => step.RecipeId);
            
            base.Configure(builder);
        }
    }
}
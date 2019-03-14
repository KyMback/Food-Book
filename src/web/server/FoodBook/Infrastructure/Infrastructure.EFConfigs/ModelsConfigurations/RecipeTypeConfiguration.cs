using FoodBook.Domain.Entities;
using FoodBook.Domain.Entities.Recipes;
using FoodBook.Infrastructure.EFConfigs.Constants;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodBook.Infrastructure.EFConfigs.ModelsConfigurations
{
    [UsedImplicitly]
    public class RecipeTypeConfiguration : BaseEntityTypeConfiguration<Recipe>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Recipe> builder)
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
            
            builder
                .HasOne(recipe => recipe.CreatedBy)
                .WithMany()
                .HasForeignKey(recipe => recipe.CreatedById);
            
            builder.HasOne(recipe => recipe.Rating)
                .WithOne()
                .HasForeignKey<Rating>(rating => rating.EntityId);
        }
    }
}
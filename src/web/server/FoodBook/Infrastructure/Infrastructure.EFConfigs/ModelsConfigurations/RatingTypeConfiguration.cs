using FoodBook.Domain.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodBook.Infrastructure.EFConfigs.ModelsConfigurations
{
    [UsedImplicitly]
    internal class RatingTypeConfiguration: BaseEntityTypeConfiguration<Rating>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Rating> builder)
        {
        }
    }
}
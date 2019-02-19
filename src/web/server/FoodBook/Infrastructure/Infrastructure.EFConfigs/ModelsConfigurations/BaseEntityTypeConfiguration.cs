using FoodBook.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodBook.Infrastructure.EFConfigs.ModelsConfigurations
{
    public class BaseEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            string typeName = typeof(TEntity).Name;
            
            builder.ToTable($"{typeName}s");
            builder
                .HasKey(entity => entity.Id)
                .HasName($"{typeName}Id");
        }
    }
}
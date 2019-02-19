using FoodBook.Domain.Entities.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodBook.Infrastructure.EFConfigs.ModelsConfigurations
{
    [UsedImplicitly]
    public class UserAccountTypeConfiguration : BaseEntityTypeConfiguration<UserAccount>
    {
        public override void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.HasAlternateKey(account => account.Email);
            
            base.Configure(builder);
        }
    }
}
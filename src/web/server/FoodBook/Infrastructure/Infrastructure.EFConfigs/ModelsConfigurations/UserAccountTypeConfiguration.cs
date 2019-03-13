using FoodBook.Domain.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodBook.Infrastructure.EFConfigs.ModelsConfigurations
{
    [UsedImplicitly]
    public class UserAccountTypeConfiguration : BaseEntityTypeConfiguration<UserAccount>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<UserAccount> builder)
        {
            builder.HasAlternateKey(account => account.Email);
            builder.HasAlternateKey(account => account.Login);
        }
    }
}
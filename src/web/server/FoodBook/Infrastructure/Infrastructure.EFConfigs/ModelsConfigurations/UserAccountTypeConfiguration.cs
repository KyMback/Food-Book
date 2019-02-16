using FoodBook.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodBook.Infrastructure.EFConfigs.ModelsConfigurations
{
    public class UserAccountTypeConfiguration : BaseEntityTypeConfiguration<UserAccount>
    {
        public override void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            base.Configure(builder);

            builder.HasAlternateKey(account => account.Email);
        }
    }
}
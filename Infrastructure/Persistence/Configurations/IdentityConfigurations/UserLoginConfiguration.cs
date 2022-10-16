using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.IdentityConfigurations;

public class UserLoginConfiguration: IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.ToTable("user_logins");
        
        builder.Property(x => x.LoginProvider).HasColumnName("login_provider");
        builder.Property(x => x.ProviderDisplayName).HasColumnName("provider_display_name");
        builder.Property(x => x.ProviderKey).HasColumnName("provider_key");
        builder.Property(x => x.UserId).HasColumnName("user_id");
    }
}
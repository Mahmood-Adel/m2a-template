using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.IdentityConfigurations;

public class UserTokenConfiguration: IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.ToTable("user_tokens");
        
        builder.Property(x => x.LoginProvider).HasColumnName("login_provider");
        builder.Property(x => x.Name).HasColumnName("name");
        builder.Property(x => x.UserId).HasColumnName("user_id");
        builder.Property(x => x.Value).HasColumnName("value");
    }
}
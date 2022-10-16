// using Domain.Common;
// using Infrastructure.Identity;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// namespace Infrastructure.Persistence.Configurations;
//
// public class CreatableModelConfiguration: IEntityTypeConfiguration<CreatableModel>
// {
//     public void Configure(EntityTypeBuilder<CreatableModel> builder)
//     {
//         // builder.Property(x => x.CreatedById).IsRequired(false);
//         // builder.Property(x => x.DeletedById).IsRequired(false);
//         // builder.HasOne<User>();
//         // builder.HasOne<User>("DeletedById");
//     }
// }
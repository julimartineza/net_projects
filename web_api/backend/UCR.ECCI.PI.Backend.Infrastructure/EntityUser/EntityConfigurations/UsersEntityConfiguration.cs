using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using UCR.ECCI.PI.Backend.Domain.Users.Entities;
using UCR.ECCI.PI.Backend.Domain.Users.ValueObjects;

namespace UCR.ECCI.PI.Backend.Infrastructure.EntityUser.EntityConfigurations;

public class UsersEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.UserId);

        builder.ToTable("User");

        builder.Property(e => e.UserId)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: idString => PersonId.Create(idString));
        builder.HasIndex(e => e.UserId).IsUnique();

        builder.Property(e => e.Username)
            .IsRequired()
            .HasMaxLength(50)
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: usernameString => Username.Create(usernameString));
        builder.HasIndex(e => e.Username).IsUnique();

        builder.Property(e => e.Avatar)
            .IsRequired()
            .HasMaxLength(200)
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: avatarString => Avatar.Create(avatarString));

        builder.Property(e => e.IsActive)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: isActiveBool => IsActive.Create(isActiveBool));

        builder.Property(e => e.Email)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: emailString => Email.Create(emailString));
    }
}

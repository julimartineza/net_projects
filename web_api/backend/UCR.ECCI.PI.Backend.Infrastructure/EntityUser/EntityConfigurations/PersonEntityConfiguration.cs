using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UCR.ECCI.PI.Backend.Domain.Buildings.Entities;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.Users.Entities;
using UCR.ECCI.PI.Backend.Domain.Users.ValueObjects;

namespace UCR.ECCI.PI.Backend.Infrastructure.EntityUser.EntityConfigurations;

public class PersonEntityConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        //builder.HasKey(e => e.PersonId);
        builder.HasKey(e => e.Email);

        builder.ToTable("Person");

        builder.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("Email") // Explicit column name
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: emailString => Email.Create(emailString));

        builder.Property(e => e.PersonId)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: idString => PersonId.Create(idString));

        builder.Property(e => e.FullName)
            .IsRequired()
            .HasMaxLength(100)
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: nameString => FullName.Create(nameString));

        builder.Property(e => e.Nickname)
            .HasMaxLength(50)
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: nicknameString => Nickname.Create(nicknameString));

        builder.Property(e => e.Username)
            .IsRequired()
            .HasMaxLength(50)
            .HasConversion(
                convertToProviderExpression: valueObject => valueObject.Value,
                convertFromProviderExpression: usernameString => Username.Create(usernameString));
        builder.HasIndex(e => e.Username).IsUnique();

    }
}

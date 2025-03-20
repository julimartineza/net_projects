using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UCR.ECCI.PI.Backend.Domain.Trees.Entities;

namespace UCR.ECCI.PI.Backend.Infrastructure.EntityTree.EntityConfigurations
{
    /// <summary>
    /// Configuration for the Tree entity.
    /// </summary>
    internal class TreeEntityConfiguration : IEntityTypeConfiguration<Tree>
    {
        public void Configure(EntityTypeBuilder<Tree> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("Tree");

            builder.Property(e => e.Id)
                .IsRequired();

            builder.Property(e => e.LocationX)
                .IsRequired();

            builder.Property(e => e.LocationY)
                .IsRequired();

            builder.Property(e => e.LocationZ)
                .IsRequired();

            builder.Property(e => e.Scale)
                .IsRequired();
        }
    }
}

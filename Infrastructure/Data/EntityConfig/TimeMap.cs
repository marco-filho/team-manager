using TeamManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TeamManager.Infrastructure.Data.EntityConfig
{
    public class TimeMap : IEntityTypeConfiguration<Time>
    {
        public void Configure(EntityTypeBuilder<Time> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(t => t.DataInclusao)
                .IsRequired();

            builder.HasMany(t => t.Jogadores)
                .WithOne();

            builder.Navigation(t => t.Jogadores);
        }
    }
}

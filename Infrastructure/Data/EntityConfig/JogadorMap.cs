using TeamManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TeamManager.Infrastructure.Data.EntityConfig
{
    public class JogadorMap : IEntityTypeConfiguration<Jogador>
    {
        public void Configure(EntityTypeBuilder<Jogador> builder)
        {
            builder.HasKey(j => j.Id);

            builder.Property(j => j.NomeCompleto)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(j => j.Idade)
                .IsRequired();

            builder.Property(j => j.TimeId)
                .IsRequired();

            builder.HasOne<Time>()
                .WithMany(t => t.Jogadores)
                .HasForeignKey(j => j.TimeId)
                .IsRequired();
        }
    }
}

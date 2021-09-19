using TeamManager.Domain.Entities;
using TeamManager.Infrastructure.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace TeamManager.Infrastructure.Data.Common
{
    public class TeamManagerContext : DbContext
    {
        public TeamManagerContext(DbContextOptions<TeamManagerContext> options)
            : base(options)
        {}

        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Time> Times { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new JogadorMap());
            builder.ApplyConfiguration(new TimeMap());
        }
    }
}

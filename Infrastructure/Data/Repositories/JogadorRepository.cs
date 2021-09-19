using TeamManager.Domain.Entities;
using TeamManager.Domain.Interfaces;
using TeamManager.Infrastructure.Data.Common;

namespace TeamManager.Infrastructure.Data.Repositories
{
    public class JogadorRepository : EfRepository<Jogador>, IJogadorRepository
    {
        public JogadorRepository(TeamManagerContext dbContext)
            : base(dbContext)
        {

        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TeamManager.Domain.Entities;
using TeamManager.Domain.Interfaces;
using TeamManager.Infrastructure.Data.Common;

namespace TeamManager.Infrastructure.Data.Repositories
{
    public class TimeRepository : EfRepository<Time>, ITimeRepository
    {
        public TimeRepository(TeamManagerContext dbContext)
            : base(dbContext)
        {

        }

        public IEnumerable<Time> IncludeJogadores()
        {
            return _dbContext
                .Times
                .Include(t => t.Jogadores)
                .AsEnumerable();
        }
    }
}

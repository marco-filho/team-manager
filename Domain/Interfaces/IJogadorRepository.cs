using TeamManager.Domain.Entities;
using System.Collections.Generic;

namespace TeamManager.Domain.Interfaces
{
    public interface IJogadorRepository
    {
        Jogador Get(int id);
        IEnumerable<Jogador> GetAll();
        void Insert(Jogador jogador);
        void Update(Jogador jogador);
        void Delete(int id);
    }
}

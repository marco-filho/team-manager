using TeamManager.Domain.Entities;
using System.Collections.Generic;

namespace TeamManager.Domain.Interfaces
{
    public interface ITimeRepository
    {
        IEnumerable<Time> IncludeJogadores();
        Time Get(int id);
        IEnumerable<Time> GetAll();
        void Insert(Time time);
        void Update(Time time);
        void Delete(int id);
    }
}

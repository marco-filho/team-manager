using TeamManager.ViewModels;
using System.Collections.Generic;

namespace TeamManager.Interfaces
{
    public interface ITimeViewModelService
    {
        IEnumerable<TimeViewModel> IncludeJogadores();
        TimeViewModel Get(int id);
        IEnumerable<TimeViewModel> GetAll();
        void Insert(TimeViewModel viewModel);
        void Update(TimeViewModel viewModel);
        void Delete(int id);
    }
}

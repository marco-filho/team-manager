using TeamManager.ViewModels;
using System.Collections.Generic;

namespace TeamManager.Interfaces
{
    public interface IJogadorViewModelService
    {
        JogadorViewModel Get(int id);
        IEnumerable<JogadorViewModel> GetAll();
        void Insert(JogadorViewModel viewModel);
        void Update(JogadorViewModel viewModel);
        void Delete(int id);
    }
}

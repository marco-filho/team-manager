using AutoMapper;
using TeamManager.Domain.Entities;
using TeamManager.Domain.Interfaces;
using TeamManager.Interfaces;
using TeamManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamManager.Services
{
    public class JogadorViewModelService : IJogadorViewModelService
    {
        private readonly IJogadorRepository _jogadorRepository;
        private readonly IMapper _mapper;

        public JogadorViewModelService(IJogadorRepository jogadorRepository, IMapper mapper)
        {
            _jogadorRepository = jogadorRepository;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            _jogadorRepository.Delete(id);
        }

        public JogadorViewModel Get(int id)
        {
            var entity = _jogadorRepository.Get(id);
            if (entity == null)
                return null;

            return _mapper.Map<JogadorViewModel>(entity);
        }

        public IEnumerable<JogadorViewModel> GetAll()
        {
            var list = _jogadorRepository.GetAll();
            if (list == null)
                return new JogadorViewModel[] { };

            return _mapper.Map<IEnumerable<JogadorViewModel>>(list);
        }

        public void Insert(JogadorViewModel viewModel)
        {
            var entity = _mapper.Map<Jogador>(viewModel);

            _jogadorRepository.Insert(entity);
        }

        public void Update(JogadorViewModel viewModel)
        {
            var entity = _mapper.Map<Jogador>(viewModel);

            _jogadorRepository.Update(entity);
        }
    }
}

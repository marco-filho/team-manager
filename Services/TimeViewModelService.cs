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
    public class TimeViewModelService : ITimeViewModelService
    {
        private readonly ITimeRepository _timeRepository;
        private readonly IMapper _mapper;

        public TimeViewModelService(ITimeRepository timeRepository, IMapper mapper)
        {
            _timeRepository = timeRepository;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            _timeRepository.Delete(id);
        }

        public TimeViewModel Get(int id)
        {
            var entity = _timeRepository.Get(id);
            if (entity == null)
                return null;

            return _mapper.Map<TimeViewModel>(entity);
        }

        public IEnumerable<TimeViewModel> GetAll()
        {
            var list = _timeRepository.GetAll();
            if (list == null)
                return new TimeViewModel[] { };

            return _mapper.Map<IEnumerable<TimeViewModel>>(list);
        }

        public IEnumerable<TimeViewModel> IncludeJogadores()
        {
            var list = _timeRepository.IncludeJogadores();
            if (list == null)
                return new TimeViewModel[] { };

            return _mapper.Map<IEnumerable<TimeViewModel>>(list);
        }

        public void Insert(TimeViewModel viewModel)
        {
            var entity = _mapper.Map<Time>(viewModel);

            _timeRepository.Insert(entity);
        }

        public void Update(TimeViewModel viewModel)
        {
            var entity = _mapper.Map<Time>(viewModel);

            _timeRepository.Update(entity);
        }
    }
}

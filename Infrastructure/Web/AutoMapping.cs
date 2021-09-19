using AutoMapper;
using TeamManager.Domain.Entities;
using TeamManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamManager.Infrastructure.Web
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Jogador, JogadorViewModel>();
            CreateMap<JogadorViewModel, Jogador>();
            CreateMap<Time, TimeViewModel>();
            CreateMap<TimeViewModel, Time>();
        }
    }
}

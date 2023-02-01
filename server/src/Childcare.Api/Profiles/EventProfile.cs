using System;
using AutoMapper;
using Childcare.Api.ViewModels;
using Childcare.Api.ViewModels.Addresses;
using Childcare.Api.ViewModels.Events;
using Childcare.Services.Services.DTOs;

namespace Childcare.API.Profiles
{
    public class EventsProfile : Profile
    {
        public EventsProfile()
        {
            ConfigureModelToDto();
            ConfigureDtoToModel();
        }

        private void ConfigureModelToDto()
        {
            CreateMap<UpdateEventViewModel, EventDTO>();
            CreateMap<CreateEventViewModel, EventDTO>();
        }

        private void ConfigureDtoToModel()
        {
            CreateMap<EventDTO, EventViewModel>();
        }
    }
}
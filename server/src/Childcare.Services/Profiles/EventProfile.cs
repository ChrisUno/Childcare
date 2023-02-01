using AutoMapper;
using Childcare.Dal.Models;
using Childcare.Services.Services.DTOs;

namespace Childcare.Services.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            ConfigureDomainToDto();
            ConfigureDtoToDomain();
        }

        private void ConfigureDomainToDto()
        {
            CreateMap<Event, EventDTO>();
        }

        private void ConfigureDtoToDomain()
        {
            CreateMap<EventDTO, Event>();
        }
    }
}
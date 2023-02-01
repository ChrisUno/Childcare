using AutoMapper;
using Childcare.Dal.Models;
using Childcare.Services.Services.DTOs;

namespace Childcare.Services.Profiles
{
    public class RelationshipTypeProfile : Profile
    {
        public RelationshipTypeProfile()
        {
            ConfigureDomainToDto();
            ConfigureDtoToDomain();
        }

        private void ConfigureDomainToDto()
        {
            CreateMap<RelationshipType, RelationshipTypeDTO>();
        }

        private void ConfigureDtoToDomain()
        {
            CreateMap<RelationshipTypeDTO, RelationshipType>();
        }
    }
}
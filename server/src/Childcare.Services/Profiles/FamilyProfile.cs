using AutoMapper;
using Childcare.Dal.Models;
using Childcare.Services.Services.DTOs;

namespace Childcare.Services.Profiles
{
    public class FamilyProfile : Profile
    {
        public FamilyProfile()
        {
            ConfigureDomainToDto();
            ConfigureDtoToDomain();
        }

        private void ConfigureDomainToDto()
        {
            CreateMap<Family, FamilyDTO>();
        }

        private void ConfigureDtoToDomain()
        {
            CreateMap<FamilyDTO, Family>();
        }
    }
}
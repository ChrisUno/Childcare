using AutoMapper;
using Childcare.Dal.Models;
using Childcare.Services.Services.DTOs;

namespace Childcare.Services.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            ConfigureDomainToDto();
            ConfigureDtoToDomain();
        }

        private void ConfigureDomainToDto()
        {
            CreateMap<Address, AddressDTO>();
        }

        private void ConfigureDtoToDomain()
        {
            CreateMap<AddressDTO, Address>();
        }
    }
}
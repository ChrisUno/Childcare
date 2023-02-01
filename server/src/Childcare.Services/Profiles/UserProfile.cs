using AutoMapper;
using Childcare.Dal.Models;
using Childcare.Services.Services.DTOs;

namespace Childcare.Services.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            ConfigureDomainToDto();
            ConfigureDtoToDomain();
        }

        private void ConfigureDomainToDto()
        {
            CreateMap<User, UserDTO>();
        }

        private void ConfigureDtoToDomain()
        {
            CreateMap<UserDTO, User>();
        }
    }
}
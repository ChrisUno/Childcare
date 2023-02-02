using System;
using AutoMapper;
using Childcare.Api.ViewModels;
using Childcare.Api.ViewModels.Addresses;
using Childcare.Api.ViewModels.Users;
using Childcare.Services.Services.DTOs;

namespace Childcare.API.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            ConfigureModelToDto();
            ConfigureDtoToModel();
        }

        private void ConfigureModelToDto()
        {
            CreateMap<CreateUserViewModel, UserDTO>();
            CreateMap<UpdateUserViewModel, UserDTO>();
        }

        private void ConfigureDtoToModel()
        {
            CreateMap<UserDTO, UserViewModel>();
        }
    }
}
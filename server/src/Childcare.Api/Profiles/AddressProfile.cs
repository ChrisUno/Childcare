using System;
using AutoMapper;
using Childcare.Api.ViewModels;
using Childcare.Api.ViewModels.Addresses;
using Childcare.Services.Services.DTOs;

namespace Childcare.API.Profiles
{
    public class AddressesProfile : Profile
    {
        public AddressesProfile()
        {
            ConfigureModelToDto();
            ConfigureDtoToModel();
        }

        private void ConfigureModelToDto()
        {
            CreateMap<UpdateAddressViewModel, AddressDTO>();
            CreateMap<CreateAddressViewModel, AddressDTO>();
        }

        private void ConfigureDtoToModel()
        {
            CreateMap<AddressDTO, AddressViewModel>();
        }
    }
}
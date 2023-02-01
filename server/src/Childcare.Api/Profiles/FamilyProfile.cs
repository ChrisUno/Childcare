using System;
using AutoMapper;
using Childcare.Api.ViewModels;
using Childcare.Api.ViewModels.Addresses;
using Childcare.Api.ViewModels.Family;
using Childcare.Services.Services.DTOs;

namespace Childcare.API.Profiles
{
    public class FamilyProfile : Profile
    {
        public FamilyProfile()
        {
            ConfigureModelToDto();
            ConfigureDtoToModel();
        }

        private void ConfigureModelToDto()
        {
            CreateMap<UpdateFamilyViewModel, FamilyDTO>();
            CreateMap<CreateFamilyViewModel, FamilyDTO>();
        }

        private void ConfigureDtoToModel()
        {
            CreateMap<FamilyDTO, FamilyViewModel>();
        }
    }
}
using System;
using AutoMapper;
using Childcare.Api.ViewModels;
using Childcare.Api.ViewModels.Addresses;
using Childcare.Api.ViewModels.RelationshipTypes;
using Childcare.Services.Services.DTOs;

namespace Childcare.API.Profiles
{
    public class RelationshipTypesProfile : Profile
    {
        public RelationshipTypesProfile()
        {
            ConfigureModelToDto();
            ConfigureDtoToModel();
        }

        private void ConfigureModelToDto()
        {
            CreateMap<CreateRelationshipTypeViewModel, RelationshipTypeDTO>();
        }

        private void ConfigureDtoToModel()
        {
            CreateMap<RelationshipTypeDTO, RelationshipTypeViewModel>();
        }
    }
}
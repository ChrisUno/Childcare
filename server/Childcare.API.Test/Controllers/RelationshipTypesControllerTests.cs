using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Childcare.Services.Services.DTOs;
using Childcare.Services.Interfaces;
using Childcare.Api.Controllers;
using Childcare.Api.ViewModels;
using Childcare.API.Test.Extensions;
using Unosquare.EntityFramework.Specification.EFCore.Extensions;

namespace Childcare.API.Test.Controllers
{
    public class RelationshipTypesControllerTests
    {
        private readonly IRelationshipTypeService _RelationshipTypeService;
        private readonly ILogger<RelationshipTypesController> _logger;
        private readonly IMapper _mapper;

        public RelationshipTypesControllerTests()
        {
            _RelationshipTypeService = Substitute.For<IRelationshipTypeService>();
            _logger = Substitute.For<ILogger<RelationshipTypesController>>();
            _mapper = Substitute.For<IMapper>();
        }

        [Fact]
        public void GetRelationshipTypes_WhenUsersExist_MapsAndReturns()
        {
            // Arrange
            var relationshipTypeDTOs = new List<RelationshipTypeDTO> { new RelationshipTypeDTO() };
            var relationshipTypesViewModels = new List<RelationshipTypeViewModel> { new RelationshipTypeViewModel() };
            var controller = RetrieveController();

            _RelationshipTypeService.GetRelationshipTypes().Returns(relationshipTypeDTOs);
            _mapper.Map<List<RelationshipTypeViewModel>>(relationshipTypeDTOs).Returns(relationshipTypesViewModels);

            // Act
            var actionResult = controller.GetRelations();

            // Assert
            var result = actionResult.AssertObjectResult<IList<RelationshipTypeViewModel>, OkObjectResult>();

            result.Should().BeSameAs(relationshipTypesViewModels);

             _RelationshipTypeService.Received(1).GetRelationshipTypes();

            _mapper.Received(1).Map<List<RelationshipTypeViewModel>>(relationshipTypeDTOs);
        }

        [Fact]
        public void GetRelationshipTypes_WhenNoRelationshipTypesExist_ReturnsNoContent()
        {
            // Arrange            
            var controller = RetrieveController();

            // Act

            var actionResult = controller.GetRelations();

            // Assert
            actionResult.AssertResult<IList<RelationshipTypeViewModel>, NoContentResult>();
        }

        private RelationshipTypesController RetrieveController()
        {
            return new RelationshipTypesController(_logger, _mapper, _RelationshipTypeService);
        }
    }
}
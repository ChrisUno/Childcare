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

namespace Childcare.API.Test.Controllers
{
    public class FamilyControllerTests
    {
        private readonly IFamilyService _FamilyService;
        private readonly ILogger<FamilyController> _logger;
        private readonly IMapper _mapper;

        public FamilyControllerTests()
        {
            _FamilyService = Substitute.For<IFamilyService>();
            _logger = Substitute.For<ILogger<FamilyController>>();
            _mapper = Substitute.For<IMapper>();
        }

        [Fact]
        public void GetFamily_WhenFamiliesExist_MapsAndReturns()
        {
            // Arrange
            var familyDTOs = new List<FamilyDTO> { new FamilyDTO() };
            var familyViewModels = new List<FamilyViewModel> { new FamilyViewModel() };
            var controller = RetrieveController();

            _FamilyService.GetFamilies().Returns(familyDTOs);
            _mapper.Map<List<FamilyViewModel>>(familyDTOs).Returns(familyViewModels);

            // Act
            var actionResult =  controller.GetFamilies();

            // Assert
            var result = actionResult.AssertObjectResult<IList<FamilyViewModel>, OkObjectResult>();

            result.Should().BeSameAs(familyViewModels);

             _FamilyService.Received(1).GetFamilies();

            _mapper.Received(1).Map<List<FamilyViewModel>>(familyDTOs);
        }

        [Fact]
        public void GetFamily_WhenNoFamiliesExist_ReturnsNoContent()
        {
            // Arrange            
            var controller = RetrieveController();

            // Act
            var actionResult =  controller.GetFamilies();

            // Assert
            actionResult.AssertResult<IList<FamilyViewModel>, NoContentResult>();
        }

        private FamilyController RetrieveController()
        {
            return new FamilyController(_logger, _mapper, _FamilyService);
        }
    }
}
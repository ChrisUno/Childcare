using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Childcare.Api.Test.Extensions;
using Childcare.API.Controllers;
using Childcare.API.ViewModels;
using Childcare.Services.Services.DTOs;
using Childcare.Services.Interfaces;

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
        public async Task GetFamily_WhenUsersExist_MapsAndReturns()
        {
            // Arrange
            var familyDTOs = new List<FamilyDTO> { new FamilyDTO() };
            var familyViewModels = new List<FamilyViewModel> { new FamilyViewModel() };
            var controller = RetrieveController();

            _FamilyService.GetFamilies().Returns(familyDTOs);
            _mapper.Map<List<FamilyViewModel>>(FamilyDTOs).Returns(FamilyViewModels);

            // Act
            var actionResult = await controller.GetFamily();

            // Assert
            var result = actionResult.AssertObjectResult<IList<FamilyViewModel>, OkObjectResult>();

            result.Should().BeSameAs(FamilyViewModels);

            await _FamilyService.Received(1).GetFamilies();

            _mapper.Received(1).Map<List<FamilyViewModel>>(FamilyDTOs);
        }

        [Fact]
        public async Task GetFamily_WhenNoUsersExist_ReturnsNoContent()
        {
            // Arrange            
            var controller = RetrieveController();

            // Act
            var actionResult = await controller.GetFamily();

            // Assert
            actionResult.AssertResult<IList<FamilyViewModel>, NoContentResult>();
        }

        private FamilyController RetrieveController()
        {
            return new FamilyController(_logger, _FamilyService, _mapper);
        }
    }
}
using AutoMapper;
using Childcare.Api.Controllers;
using Childcare.Api.ViewModels;
using Childcare.API.Test.Extensions;
using Childcare.Services.Interfaces;
using Childcare.Services.Services.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;


namespace Childcare.API.Test.Controllers
{
    public class AddressControllerTests
    {
        private readonly IAddressService _addressService;
        private readonly ILogger<AddressesController> _logger;
        private readonly IMapper _mapper;

        public AddressControllerTests()
        {
            _addressService = Substitute.For<IAddressService>();
            _logger = Substitute.For<ILogger<AddressesController>>();
            _mapper = Substitute.For<IMapper>();
        }

        [Fact]
        public void GetAddresses_WhenAddressesExist_MapsAndReturns()
        {
            // Arrange
            var addressDTOs = new List<AddressDTO> { new AddressDTO() };
            var addressViewModels = new List<AddressViewModel> { new AddressViewModel() };
            var controller = RetrieveController();

            _addressService.GetAddresses().Returns(addressDTOs);
            _mapper.Map<List<AddressViewModel>>(addressDTOs).Returns(addressViewModels);

            // Act
            var actionResult =  controller.GetAddresses();

            // Assert
            var result = actionResult.AssertObjectResult<IList<AddressViewModel>, OkObjectResult>();

            result.Should().BeSameAs(addressViewModels);

             _addressService.Received(1).GetAddresses();

            _mapper.Received(1).Map<List<AddressViewModel>>(addressDTOs);
        }

        [Fact]
        public void GetAddresses_WhenNoAddressesExist_ReturnsNoContent()
        {
            // Arrange            
            var controller = RetrieveController();

            // Act
            var actionResult =  controller.GetAddresses();

            // Assert
            actionResult.AssertResult<IList<AddressViewModel>, NoContentResult>();
        }

        private AddressesController RetrieveController()
        {
            return new AddressesController(_logger, _mapper, _addressService );
        }
    }
}
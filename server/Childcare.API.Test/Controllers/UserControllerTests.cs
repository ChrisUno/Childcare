using AutoMapper;
using Childcare.Api.Controllers;
using Childcare.Api.ViewModels;
using Childcare.Services.Interfaces;
using Childcare.Services.Services.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;


namespace Childcare.API.Test.Controllers
{
    public class UserControllerTests
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;
        private readonly IMapper _mapper;

        public UserControllerTests()
        {
            _userService = Substitute.For<IUserService>();
            _logger = Substitute.For<ILogger<UsersController>>();
            _mapper = Substitute.For<IMapper>();
        }

        [Fact]
        public async Task GetUsers_WhenUsersExist_MapsAndReturns()
        {
            // Arrange
            var userDtos = new List<UserDTO> { new UserDTO() };
            var userViewModels = new List<UserViewModel> { new UserViewModel() };
            var controller = RetrieveController();

            _userService.GetUsers().Returns(userDtos);
            _mapper.Map<List<UserViewModel>>(userDtos).Returns(userViewModels);

            // Act
            var actionResult = await controller.GetUsers();

            // Assert
            var result = actionResult.AssertObjectResult<IList<UserViewModel>, OkObjectResult>();

            result.Should().BeSameAs(userViewModels);

            await _userService.Received(1).GetUsers();

            _mapper.Received(1).Map<List<UserViewModel>>(userDtos);
        }

        [Fact]
        public async Task GetUsers_WhenNoUsersExist_ReturnsNoContent()
        {
            // Arrange            
            var controller = RetrieveController();

            // Act
            var actionResult = await controller.GetUsers();

            // Assert
            actionResult.AssertResult<IList<UserViewModel>, NoContentResult>();
        }

        private UsersController RetrieveController()
        {
            return new UsersController(_logger, _userService, _mapper);
        }
    }
}
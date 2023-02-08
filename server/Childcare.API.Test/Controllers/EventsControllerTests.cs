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
    public class EventsControllerTests
    {
        private readonly IEventService _EventService;
        private readonly ILogger<EventsController> _logger;
        private readonly IMapper _mapper;

        public EventsControllerTests()
        {
            _EventService = Substitute.For<IEventService>();
            _logger = Substitute.For<ILogger<EventsController>>();
            _mapper = Substitute.For<IMapper>();
        }

        [Fact]
        public void GetEvent_WhenUsersExist_MapsAndReturns()
        {
            // Arrange
            var eventDTOs = new List<EventDTO> { new EventDTO() };
            var eventViewModels = new List<EventViewModel> { new EventViewModel() };
            var controller = RetrieveController();

            _EventService.GetEvents().Returns(eventDTOs);
            _mapper.Map<List<EventViewModel>>(eventDTOs).Returns(eventViewModels);

            // Act
            var actionResult =  controller.GetEvents();

            // Assert
            var result = actionResult.AssertObjectResult<IList<EventViewModel>, OkObjectResult>();

            result.Should().BeSameAs(eventViewModels);

             _EventService.Received(1).GetEvents();

            _mapper.Received(1).Map<List<EventViewModel>>(eventDTOs);
        }

        [Fact]
        public void GetEvent_WhenNoEventsExist_ReturnsNoContent()
        {
            // Arrange            
            var controller = RetrieveController();

            // Act
            var actionResult =  controller.GetEvents();

            // Assert
            actionResult.AssertResult<IList<EventViewModel>, NoContentResult>();
        }

        private EventsController RetrieveController()
        {
            return new EventsController(_logger, _mapper, _EventService );
        }
    }
}
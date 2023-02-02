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
using Childcare.Services.Services.DTOs;EventService
using Childcare.Services.Interfaces;

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
            _logger = Substitute.For<ILogger<EventController>>();
            _mapper = Substitute.For<IMapper>();
        }

        [Fact]
        public async Task GetEvent_WhenUsersExist_MapsAndReturns()
        {
            // Arrange
            var eventDTOs = new List<EventDTO> { new EventDTO() };
            var eventViewModels = new List<EventViewModel> { new EventViewModel() };
            var controller = RetrieveController();

            _EventService.GetEvents().Returns(eventDTOs);
            _mapper.Map<List<EventViewModel>>(EventDTOs).Returns(EventViewModels);

            // Act
            var actionResult = await controller.GetEvent();

            // Assert
            var result = actionResult.AssertObjectResult<IList<EventViewModel>, OkObjectResult>();

            result.Should().BeSameAs(EventViewModels);

            await _EventService.Received(1).GetEvents();

            _mapper.Received(1).Map<List<EventViewModel>>(EventDTOs);
        }

        [Fact]
        public async Task GetEvent_WhenNoUsersExist_ReturnsNoContent()
        {
            // Arrange            
            var controller = RetrieveController();

            // Act
            var actionResult = await controller.GetEvent();

            // Assert
            actionResult.AssertResult<IList<EventViewModel>, NoContentResult>();
        }

        private EventController RetrieveController()
        {
            return new EventController(_logger, _EventService, _mapper);
        }
    }
}
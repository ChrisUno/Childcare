using AutoFixture;
using AutoMapper;
using FluentAssertions;
using MockQueryable.NSubstitute;
using NSubstitute;
using Childcare.Dal.Interfaces;
using Childcare.Dal.Models;
using Childcare.Services.Exceptions;
using Childcare.Services.Interfaces;
using Childcare.Services.Profiles;
using Childcare.Services.Services;
using Childcare.Services.Services.DTOs;

namespace Childcare.Service.Test.Services
{
    public class EventServiceTests
    {
        private readonly IChildcareDatabase _database;
        private readonly IMapper _mapper;


        public EventServiceTests()
        {
            _database = Substitute.For<IChildcareDatabase>();
            _mapper = Substitute.For<IMapper>();
        }

        [Fact]
        public void DeleteEvent_Eventexists_DeletesEvent()
        {
            // Arrange 
            const int correctId = 1;
            var singleEvent = new List<Event> { new Event { Id = correctId } };

            _database.Get<Event>().Returns(singleEvent.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            //Assert.Throws<NotFoundException>(() => service.DeleteEvent(correctId));
            var result = service.DeleteEvent(correctId);

            //Assertion
            _database.Received(1).SaveChanges();
            result.Should().BeTrue();
            _database.Received(1).Delete(Arg.Is<Event>(x => x.Id == correctId));
        }

        [Fact]
        public void GetEvent_WhenEventExists_ReturnsEvent()
        {
            // Arrange
            const int id = 0;

            var singleEvent = new Event { Id = id };
            var events = new List<Event> { singleEvent };
            var eventDTO = new List<EventDTO> { new EventDTO { Id = singleEvent.Id } };

            _database.Get<Event>().Returns(events.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            var result = service.GetEventById(id);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(eventDTO.ElementAt(0));
        }

        [Fact]
        public void GetEvents_WhenEventsExist_ReturnsEventList()
        {
            // Arrange
            var events = new List<Event>()
            { new Event { Id = 1 } };
            var eventDTOs = new List<EventDTO>()
            { new EventDTO { Id = 1 } };

            _database.Get<Event>().Returns(events.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            var result = service.GetEvents();

            // Assert
            result.Should().BeEquivalentTo(eventDTOs, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void CreateEvent_WhenValidDataPassed_AddToDatabase()
        {
            //Arrange
            var singleEvent = new Event { Description = "playtime with a/some child/ren not at home" };
            var eventDTO = new EventDTO { Description = "playtime with a/some child/ren not at home" };

            var service = RetrieveService();
            _mapper.Map<Event>(eventDTO).Returns(singleEvent);
            //Act
            var result = service.CreateEvent(eventDTO);
            //Assert
            _database.Received(1).SaveChanges();
            result.Should().BeTrue();
            _database.Received(1).Add(Arg.Is<Event>(x => x.Description == "playtime with a/some child/ren not at home"));
         }

        [Fact]
        public void UpdateEvent_WhenValidDataPassed_AddToDatabase()
        {
            //Arrange
            var singleEvent = new Event { Id = 1, Name = "Playdate as guest", Active = true };
            var eventDTO = new EventDTO { Id = 1, Name = "Playdate as guest" };
            var events = new List<Event> { singleEvent };

            var service = RetrieveService();
            _database.Get<Event>().Returns(events.AsQueryable());
            //Act
            var result = service.UpdateEvent(1, eventDTO);
            //Assert
            _database.Received(1).SaveChanges();
            result.Should().BeTrue();

}

            private IEventService RetrieveService()
             {
                return new EventService(_database, _mapper);
             }

    }
}
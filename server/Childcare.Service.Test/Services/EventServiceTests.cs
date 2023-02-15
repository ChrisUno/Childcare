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

namespace Childcare.Service.Test.Services
{
    public class EventServiceTests
    {
        private readonly IChildcareDatabase _database;
        private readonly IMapper _mapper;
        private readonly IFixture _fixture;

        public EventServiceTests()
        {
            _database = Substitute.For<IChildcareDatabase>();
            _mapper = GetMapper();
            _fixture = new Fixture();

            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));
        }

        [Fact]
        public void DeleteEvent_EventDoesNotExist_ThrowNotFoundException()
        {
            // Arrange 
            const int correctId = 1;
            const int incorrectId = 2;

            var correctEvent = _fixture.Build<Event>().With(x => x.Id, correctId).Create();
            var incorrectEvent = _fixture.Build<Event>().With(x => x.Id, incorrectId).Create();

            _database.Get<Event>().Returns(new List<Event> { incorrectEvent }.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act & Assert
             Assert.Throws<NotFoundException>(() => service.DeleteEvent(correctId));
            _database.Received(1).Get<Event>();
        }

        [Fact]
        public void GetEvent_WhenEventExists_ReturnsEvent()
        {
            // Arrange
            const int id = 1;

            var singleEvent = new Event { Id = id };
            var events = new List<Event> { singleEvent };

            _database.Get<Event>().Returns(events.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            var result = service.GetEventById(id);

            // Assert
            result.Should().BeEquivalentTo(singleEvent, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void GetEvents_WhenEventsExist_ReturnsEventList()
        {
            // Arrange
            var events = _fixture.Build<Event>().CreateMany();

            _database.Get<Event>().Returns(events.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            var result = service.GetEvents();

            // Assert
            result.Should().BeEquivalentTo(events, options => options.ExcludingMissingMembers());
        }

        private IEventService RetrieveService()
        {
            return new EventService(_database, _mapper);
        }

        private static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<EventProfile>();
            });

            return new Mapper(config);
        }
    }
}
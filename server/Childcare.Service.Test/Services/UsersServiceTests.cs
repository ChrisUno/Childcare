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
    public class UserServiceTests
    {
        private readonly IChildcareDatabase _database;
        private readonly IMapper _mapper;
        private readonly IFixture _fixture;

        public UserServiceTests()
        {
            _database = Substitute.For<IChildcareDatabase>();
            _mapper = GetMapper();
            _fixture = new Fixture();

            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));
        }

        [Fact]
        public void DeleteUser_UserDoesNotExist_ThrowNotFoundException()
        {
            // Arrange 
            const int correctId = 1;
            const int incorrectId = 2;

            var correctUser = _fixture.Build<User>().With(x => x.Id, correctId).Create();
            var incorrectUser = _fixture.Build<User>().With(x => x.Id, incorrectId).Create();

            _database.Get<User>().Returns(new List<User> { incorrectUser }.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act & Assert
            Assert.Throws<NotFoundException>(() => service.DeleteUser(correctId));
            _database.Received(1).Get<User>();
        }

        [Fact]
        public void GetUser_WhenUserExists_ReturnsUser()
        {
            // Arrange
            const int id = 1;

            var user = new User { Id = id };
            var users = new List<User> { user };

            _database.Get<User>().Returns(users.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            var result = service.GetUserById(id);

            // Assert
            result.Should().BeEquivalentTo(user, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void GetUsers_WhenUsersExist_ReturnsUserListAsync()
        {
            // Arrange
            var users = _fixture.Build<User>().CreateMany();

            _database.Get<User>().Returns(users.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            var result = service.GetUsers();

            // Assert
            result.Should().BeEquivalentTo(users, options => options.ExcludingMissingMembers());
        }

        private IUserService RetrieveService()
        {
            return new UserService(_database, _mapper);
        }

        private static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<UserProfile>();
            });

            return new Mapper(config);
        }
    }
}
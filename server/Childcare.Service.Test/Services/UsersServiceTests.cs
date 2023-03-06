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
    public class UserServiceTests
    {
        private readonly IChildcareDatabase _database;
        private readonly IMapper _mapper;


        public UserServiceTests()
        {
            _database = Substitute.For<IChildcareDatabase>();
            _mapper = GetMapper();

        }

        [Fact]
        public void DeleteUser_UserExists_DeleteUser()
        {
            // Arrange 
            const int correctId = 1;
            var users = new List<User> { new User { Id = correctId} };

            _database.Get<User>().Returns(users.AsQueryable().BuildMock());

            var service = RetrieveService();
            // Act

            var result = service.DeleteUser(correctId);

            // Assert
            _database.Received(1).SaveChanges();
            result.Should().BeTrue();
            _database.Received(1).Delete(Arg.Is<User>(x => x.Id == correctId));
        }

        [Fact]
        public void GetUser_WhenUserExists_ReturnsUser()
        {
            // Arrange
            const int id = 1;

            var user = new User { Id = id };
            var users = new List<User> { user };
            var userDTO = new List<UserDTO> { new UserDTO { Id = user.Id } };

            _database.Get<User>().Returns(users.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            var result = service.GetUserById(id);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(userDTO.ElementAt(0));
        }

        [Fact]
        public void GetUsers_WhenUsersExist_ReturnsUserListAsync()
        {
            // Arrange
            var users = new List<User> { new User { Id = 1 } };
            var usersDTOs = new List<UserDTO> { new UserDTO { Id = 1 } };

            _database.Get<User>().Returns(users.AsQueryable().BuildMock());

            var service = RetrieveService();
            // Act

            var result = service.GetUsers();

            // Assert

            result.Should().BeEquivalentTo(usersDTOs, options => options.ExcludingMissingMembers());

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
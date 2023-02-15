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
    public class AddressServiceTests
    {
        private readonly IChildcareDatabase _database;
        private readonly IMapper _mapper;
        private readonly IFixture _fixture;

        public AddressServiceTests()
        {
            _database = Substitute.For<IChildcareDatabase>();
            _mapper = GetMapper();
            _fixture = new Fixture();

            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));
        }

        [Fact]
        public async Task DeleteAddress_AddressDoesNotExist_ThrowNotFoundException()
        {
            // Arrange 
            const int correctId = 1;
            const int incorrectId = 2;

            var correctAddress = _fixture.Build<Address>().With(x => x.Id, correctId).Create();
            var incorrectAddress = _fixture.Build<Address>().With(x => x.Id, incorrectId).Create();

            _database.Get<Address>().Returns(new List<Address> { incorrectAddress }.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act & Assert
             Assert.Throws<NotFoundException>(() => service.DeleteAddress(correctId));
            _database.Received(1).Get<Address>();
        }

        [Fact]
        public void GetAddress_WhenAddressExists_ReturnsAddress()
        {
            // Arrange
            const int id = 1;

            var address = new Address { Id = id };
            var addresses = new List<Address> { address };

            _database.Get<Address>().Returns(addresses.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            var result =  service.GetAddressById(id);

            // Assert
            result.Should().BeEquivalentTo(address, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void GetAddresss_WhenAddresssExist_ReturnsAddressListAsync()
        {
            // Arrange
            var addresses = _fixture.Build<Address>().CreateMany();

            _database.Get<Address>().Returns(addresses.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            var result =  service.GetAddresses();

            // Assert
            result.Should().BeEquivalentTo(addresses, options => options.ExcludingMissingMembers());
        }

        private IAddressService RetrieveService()
        {
            return new AddressService(_database, _mapper);
        }

        private static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AddressProfile>();
            });

            return new Mapper(config);
        }
    }
}
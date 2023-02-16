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
    public class AddressServiceTests
    {
        private readonly IChildcareDatabase _database;
        private readonly IMapper _mapper;
        

        public AddressServiceTests()
        {
            _database = Substitute.For<IChildcareDatabase>();
            _mapper = Substitute.For<IMapper>();
        }

        [Fact]
        public void DeleteAddress_Addressexists_DeletesAddress()
        {
            // Arrange 
            const int correctId = 1;
            var addresses = new List<Address> { new Address { Id = correctId } };


            _database.Get<Address>().Returns(addresses.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            
            var result = service.DeleteAddress(correctId);
            
            //Assertion
            _database.Received(1).SaveChanges();
            result.Should().BeTrue();
            _database.Received(1).Delete(Arg.Is<Address>( x => x.Id == correctId));
        }

        [Fact]
        public void GetAddress_WhenAddressExists_ReturnsAddress()
        {
            // Arrange
            const int id = 1;

            var address = new Address { Id = id };
            var addresses = new List<Address> { address };
            var addressDTO = new List<AddressDTO> { new AddressDTO { Id = address.Id } };

            _database.Get<Address>().Returns(addresses.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            var result = service.GetAddressById(id);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(addressDTO.ElementAt(0));
        }

        [Fact]
        public void GetAddresses_WhenAddressesExist_ReturnsAddressList()
        {
            // Arrange
            var addresses = new List<Address>()
            { new Address { Id = 1 } };
            var addressDTOs = new List<AddressDTO>()
            { new AddressDTO { Id = 1 } };

            _database.Get<Address>().Returns(addresses.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            var result = service.GetAddresses();

            // Assert
            result.Should().BeEquivalentTo(addressDTOs, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void CreateAddress_WhenValidDataPassed_AddToDatabase()
        {
            //Arrange
            var address = new Address { AddressLine1 = "potato" };
            var addressDTO = new AddressDTO { AddressLine1 = "potato" };

            var service = RetrieveService();
            _mapper.Map<Address>(addressDTO).Returns(address);
            //Act
            var result = service.CreateAddress(addressDTO);
            //Assert
            _database.Received(1).SaveChanges();
            result.Should().BeTrue();
            _database.Received(1).Add(Arg.Is<Address>(x => x.AddressLine1 == "potato"));
        }

        [Fact]
        public void UpdateAddress_WhenValidDataPassed_AddToDatabase()
        {
            //Arrange
            var address = new Address { Id=1, AddressLine1 = "potato" };
            var addressDTO = new AddressDTO {Id=1, AddressLine1 = "chips" };
            var addresses = new List<Address> { address };

            var service = RetrieveService();
            _database.Get<Address>().Returns(addresses.AsQueryable());
            //Act
            var result = service.UpdateAddress(1,addressDTO);
            //Assert
            _database.Received(1).SaveChanges();
            result.Should().BeTrue();
            
        }

        private IAddressService RetrieveService()
        {
            return new AddressService(_database, _mapper);
        }
        
    }
}
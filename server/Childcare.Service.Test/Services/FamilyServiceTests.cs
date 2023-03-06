using AutoFixture;
using AutoMapper;
using FluentAssertions;
using MockQueryable.NSubstitute;
using NSubstitute;
using Childcare.Dal.Interfaces;
using Childcare.Dal.Models;
using Childcare.Services.Interfaces;
using Childcare.Services.Services;
using Childcare.Services.Services.DTOs;

namespace Childcare.Service.Test.Services
{
    public class FamilyServiceTests
    {
        private readonly IChildcareDatabase _database;
        private readonly IMapper _mapper;

        public FamilyServiceTests()
        {
            _database = Substitute.For<IChildcareDatabase>();
            _mapper = Substitute.For<IMapper>();
        }

        [Fact]
        public void DeleteFamily_Familyexists_DeletesFamily()
        {
            // Arrange 
            const int correctId = 1;
            var families = new List<Family> { new Family { Id = correctId } };

            _database.Get<Family>().Returns(families.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act & Assert
            // Assert.Throws<NotFoundException>(() => service.DeleteFamily(correctId));
            var result = service.DeleteFamily(correctId);

            _database.Received(1).SaveChanges();
            result.Should().BeTrue();
            _database.Received(1).Delete(Arg.Is<Family>(x => x.Id == correctId));


        }

        [Fact]
        public void GetFamily_WhenFamilyExists_ReturnsFamily()
        {
            // Arrange
            const int id = 1;

            var family = new Family { Id = id };
            var families = new List<Family> { family };
            var familyDTO = new List<FamilyDTO> { new FamilyDTO { Id = family.Id, Name = family.Name } };

            _database.Get<Family>().Returns(families.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            var result =  service.GetFamilyById(id);

            // Assert
            result.Should().BeEquivalentTo(family, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void GetFamilies_WhenFamiliesExist_ReturnsFamilyList()
        {
            // Arrange
            var familyList = new List<Family> { new Family { Id = 1, Name = "Whatever" } };
            var familyDTOs = new List<FamilyDTO> { new FamilyDTO { Id = 1, Name = "Whatever" } };

            _database.Get<Family>().Returns(familyList.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            var result = service.GetFamilies();

            // Assert
            result.Should().BeEquivalentTo(familyDTOs, options => options.ExcludingMissingMembers());
        }

        private IFamilyService RetrieveService()
        {
            return new FamilyService(_database, _mapper);
        }


    }
}
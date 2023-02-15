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
    public class FamilyServiceTests
    {
        private readonly IChildcareDatabase _database;
        private readonly IMapper _mapper;
        private readonly IFixture _fixture;

        public FamilyServiceTests()
        {
            _database = Substitute.For<IChildcareDatabase>();
            _mapper = GetMapper();
            _fixture = new Fixture();

            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));
        }

        [Fact]
        public void DeleteFamily_FamilyDoesNotExist_ThrowNotFoundException()
        {
            // Arrange 
            const int correctId = 1;
            const int incorrectId = 2;

            var correctFamily = _fixture.Build<Family>().With(x => x.Id, correctId).Create();
            var incorrectFamily = _fixture.Build<Family>().With(x => x.Id, incorrectId).Create();

            _database.Get<Family>().Returns(new List<Family> { incorrectFamily }.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act & Assert
             Assert.Throws<NotFoundException>(() => service.DeleteFamily(correctId));
            _database.Received(1).Get<Family>();
        }

        [Fact]
        public void GetFamily_WhenFamilyExists_ReturnsFamily()
        {
            // Arrange
            const int id = 1;

            var family = new Family { Id = id };
            var families = new List<Family> { family };

            _database.Get<Family>().Returns(families.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            var result =  service.GetFamilyById(id);

            // Assert
            result.Should().BeEquivalentTo(family, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void GetFamilies_WhenFamiliesExist_ReturnsFamilyListAsync()
        {
            // Arrange
            var families = _fixture.Build<Family>().CreateMany();

            _database.Get<Family>().Returns(families.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            var result = service.GetFamilies();

            // Assert
            result.Should().BeEquivalentTo(families, options => options.ExcludingMissingMembers());
        }

        private IFamilyService RetrieveService()
        {
            return new FamilyService(_database, _mapper);
        }

        private static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<FamilyProfile>();
            });

            return new Mapper(config);
        }
    }
}
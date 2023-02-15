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
    public class RelationshipTypeServiceTests
    {
        private readonly IChildcareDatabase _database;
        private readonly IMapper _mapper;
        private readonly IFixture _fixture;

        public RelationshipTypeServiceTests()
        {
            _database = Substitute.For<IChildcareDatabase>();
            _mapper = GetMapper();
            _fixture = new Fixture();

            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));
        }

        [Fact]
        public void DeleteRelationshipType_RelationshipTypeDoesNotExist_ThrowNotFoundException()
        {
            // Arrange 
            const int correctId = 1;
            const int incorrectId = 2;

            var correctRelationshipType = _fixture.Build<RelationshipType>().With(x => x.Id, correctId).Create();
            var incorrectRelationshipType = _fixture.Build<RelationshipType>().With(x => x.Id, incorrectId).Create();

            _database.Get<RelationshipType>().Returns(new List<RelationshipType> { incorrectRelationshipType }.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act & Assert
            Assert.Throws<NotFoundException>(() => service.DeleteRelationshipType(correctId));
            _database.Received(1).Get<RelationshipType>();
        }

        [Fact]
        public void GetRelationshipType_WhenRelationshipTypeExists_ReturnsRelationshipType()
        {
            // Arrange
            const int id = 1;

            var relationshipType = new RelationshipType { Id = id };
            var relationshipTypes = new List<RelationshipType> { relationshipType };

            _database.Get<RelationshipType>().Returns(relationshipTypes.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            var result = service.GetRelationshipTypeById(id);

            // Assert
            result.Should().BeEquivalentTo(relationshipType, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void GetRelationshipTypes_WhenRelationshipTypesExist_ReturnsRelationshipTypeListAsync()
        {
            // Arrange
            var relationshipTypes = _fixture.Build<RelationshipType>().CreateMany();

            _database.Get<RelationshipType>().Returns(relationshipTypes.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            var result = service.GetRelationshipTypes();

            // Assert
            result.Should().BeEquivalentTo(relationshipTypes, options => options.ExcludingMissingMembers());
        }

        private IRelationshipTypeService RetrieveService()
        {
            return new RelationshipTypeService(_database, _mapper);
        }

        private static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<RelationshipTypeProfile>();
            });

            return new Mapper(config);
        }
    }
}
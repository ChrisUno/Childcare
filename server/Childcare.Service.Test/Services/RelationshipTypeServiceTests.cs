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


        public RelationshipTypeServiceTests()
        {
            _database = Substitute.For<IChildcareDatabase>();
            _mapper = Substitute.For<IMapper>();
        }

        [Fact]
        public void DeleteRelationshipType_RelationshipTypeExists_DeletesRelationshipType()
        {
            // Arrange 
            const int correctId = 1;
            var relationshipTypes = new List<RelationshipType> { new RelationshipType { Id = correctId} };

            _database.Get<RelationshipType>().Returns(relationshipTypes.AsQueryable().BuildMock());

            var service = RetrieveService();
            // Act
            var result = service.DeleteRelationshipType(correctId);

            // Assert
            _database.Received(1).SaveChanges();
            result.Should().BeTrue();  
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
            var relationshipTypes = new List<RelationshipType>()
            { new RelationshipType { Id = 1 } };
            var relationshipTypeDTOs = new List<RelationshipType>()
            { new RelationshipType{ Id = 1 } };

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Childcare.Dal.Interfaces;
using Childcare.Dal.Models;
using Childcare.Services.Interfaces;
using Childcare.Services.Services.DTOs;


namespace Childcare.Services.Services
{
    public class RelationshipTypeService : IRelationshipTypeService
    {
        private readonly IChildcareDatabase _database;
        private readonly IMapper _mapper;

        public RelationshipTypeService(IChildcareDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public IList<RelationshipTypeDTO> GetRelationshipTypes()
        {
            var relationshipTypes = _database.Get<RelationshipType>().ToList();
            return relationshipTypes.Select(x => new RelationshipTypeDTO { Id = x.Id, Relationship = x.Relationship }).ToList();
        }

        public RelationshipTypeDTO GetRelationshipTypeById(int id)
        {
            var relationshipType = _database
                .Get<RelationshipType>()
                .SingleOrDefault(x => x.Id == id);
            return new RelationshipTypeDTO { Id = relationshipType.Id, Relationship = relationshipType.Relationship };
        }

        public bool UpdateRelationshipType(int id, RelationshipTypeDTO relationshipTypeDTO)
        {
            var relationshipType = _database
                .Get<RelationshipType>()
                .SingleOrDefault(x => x.Id == id);
            if (relationshipType != null)
            {
                relationshipType.Id = relationshipTypeDTO.Id;
                relationshipType.Relationship = relationshipTypeDTO.Relationship;

                _database.SaveChanges();
                return true;
            }
            return false;
        }

        public bool CreateRelationshipType(RelationshipTypeDTO relationshipTypeDTO)
        {
            var relationshipType = new RelationshipType
            {
                Relationship = relationshipTypeDTO.Relationship
            };
            _database.Add(relationshipType);
            _database.SaveChanges();
            return true;
        }

        public bool DeleteRelationshipType(int id)
        {
            var relationshipType = _database
                .Get<RelationshipType>()
                .SingleOrDefault(x => x.Id == id);
            if (relationshipType != null)
            {
                _database.Delete(relationshipType);
                _database.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
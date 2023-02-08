using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Childcare.Dal.Interfaces;
using Childcare.Dal.Models;
using Childcare.Services.Interfaces;
using Childcare.Services.Services.DTOs;


namespace Childcare.Services.Services
{
    public class RelationshipTypeService : IRelationshipTypeService
    {
        private readonly IDatabase _database;
        
        public RelationshipTypeService(IDatabase database)
        {
            _database = database;
        } 

        public IList<RelationshipTypeDTO> GetRelationshipTypes()
        {
            var relationshipTypes = _database.Get<RelationshipType>().ToList();
            return relationshipTypes.Select(x=> new RelationshipTypeDTO{ Id = x.Id, Relationship = x.Relationship}).ToList();
        }

        public RelationshipTypeDTO GetRelationshipTypeById(int id)
        {
            var relationshipType = _database.Get<RelationshipType>().SingleOrDefault(x=>x.Id==id);
            return new RelationshipTypeDTO {Id = relationshipType.Id, Relationship = relationshipType.Relationship };
        }

        public bool UpdateRelationshipType(int id, RelationshipTypeDTO relationshipType)
        {
            throw new NotImplementedException();
        }

        public bool CreateRelationshipType(RelationshipTypeDTO relationshipType)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRelationshipType(int id)
        {
            throw new NotImplementedException();
        }
    }
}
using Childcare.Services.Services.DTOs;
namespace Childcare.Services.Interfaces
{
    public interface IRelationshipTypeService
    {
        IList<RelationshipTypeDTO> GetRelationshipTypes();
        RelationshipTypeDTO GetRelationshipTypeById(int id);

        bool UpdateRelationshipType(int id, RelationshipTypeDTO relationshipType);

        bool CreateRelationshipType(RelationshipTypeDTO relationshipType);

        bool DeleteRelationshipType(int id);
    }
}
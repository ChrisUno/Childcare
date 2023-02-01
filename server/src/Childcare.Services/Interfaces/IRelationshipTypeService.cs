using Childcare.Services.Services.DTOs;
namespace Childcare.Services.Interfaces
{
    public interface IRelationshipTypeService
    {
        IList<RelationshipTypeDTO> GetRelationshipTypes();
        RelationshipTypeDTO GetRelationshipTypeById(int id);
    }
}
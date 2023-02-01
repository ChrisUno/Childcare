using Childcare.Services.Services.DTOs;
namespace Childcare.Services.Interfaces
{
    public interface IUserRelationshipTypeService
    {
        IList<UserRelationshipTypeDTO> GetUserRelationshipTypes();
        UserRelationshipTypeDTO GetUserRelationshipTypeById(int id);
    }
}
using Childcare.Services.Services.DTOs;
namespace Childcare.Services.Interfaces
{
    public interface IUserService
    {
        IList<UserDTO> GetUsers();
        UserDTO GetUserById(int id);
        bool UpdateUser(int id, UserDTO user);
    }
    
}
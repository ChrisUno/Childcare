using Childcare.Services.Services.DTOs;
namespace Childcare.Services.Interfaces
{
    public interface IUserEventService
    {
        IList<UserEventDTO> GetUserEvents();
        UserEventDTO GetUserEventById(int id);
    }
}
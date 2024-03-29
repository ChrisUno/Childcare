using Childcare.Services.Services.DTOs;
namespace Childcare.Services.Interfaces
{
    public interface IEventService
    {
        IList<EventDTO> GetEvents();
        EventDTO GetEventById(int id);
        bool DeleteEvent(int id);

        bool UpdateEvent(int id, EventDTO eventDto);

        bool CreateEvent(EventDTO eventDto);

        
    }
}
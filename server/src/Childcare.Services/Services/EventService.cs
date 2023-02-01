using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System .Threading.Tasks;
using Childcare.Dal.Interfaces;
using Childcare.Dal.Models;
using Childcare.Services.Interfaces;
using Childcare.Services.Services.DTOs;


namespace Childcare.Services.Services
{
    public class EventService : IEventService
    {
        private readonly IDatabase _database;
        
        public EventService(IDatabase database)
        {
            _database = database;
        } 

        public IList<EventDTO> GetEvents()
        {
            var events = _database.Get<Event>().ToList();
            return events.Select(x=> new EventDTO{ Id = x.id, Name = x.Name}).ToList();
        }

        public EventDTO GetEventById(int id)
        {
            var event = _database.Get<Event>().SingleOrDefault(x=>x.Id==id);
            return new EventDTO {Id = Event.Id, Name = Event.Name, Description = Event.Description, Address.Id };
        }

        public bool CreateEvent(EventDTO eventDTO)
        {
            var event = new Event { Id = eventDTO.Id, Name = eventDTO.Name, Description = eventDTO.Description, TimeSlot = eventDTO.TimeSlot };
            _database.Add(event);
            _database.SaveChanges();
            return true;
        }

        public bool DeleteEvent(int id)
        {
            var user = _database.Get<Event>().SingleOrDefault(x => x.Id == id);
            event.Active = false;
            _database.SaveChanges();
            return true;
        }

        public bool UpdateEvent(int id)
        {
            var user = _database.Get<Event>()
                .Where(x => x.Active == true)
                .SingleOrDefault(x => x.Id == id);

        }
    }
}
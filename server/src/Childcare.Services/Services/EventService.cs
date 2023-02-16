using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System .Threading.Tasks;
using AutoMapper;
using Childcare.Dal.Interfaces;
using Childcare.Dal.Models;
using Childcare.Services.Interfaces;
using Childcare.Services.Services.DTOs;


namespace Childcare.Services.Services
{
    public class EventService : IEventService
    {
        private readonly IChildcareDatabase _database;
        private readonly IMapper _mapper;

        public EventService(IChildcareDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        } 

        public IList<EventDTO> GetEvents()
        {
            var events = _database.Get<Event>().ToList();
            return events.Select(x=> new EventDTO{ Id = x.Id, Name = x.Name}).ToList();
        }

        public EventDTO GetEventById(int id)
        {
            var eventRetrieved = _database
                .Get<Event>()
                .SingleOrDefault(x=>x.Id==id);
            return new EventDTO { };
        }

        public bool CreateEvent(EventDTO eventDTO)
        {
            var eventToCreate = new Event {Name = eventDTO.Name, Description = eventDTO.Description, Timeslot = eventDTO.TimeSlot  };
            _database.Add(eventToCreate);
            _database.SaveChanges();
            return true;
        }

        public bool DeleteEvent(int id)
        {
            var eventDeleted = _database
                .Get<Event>()
                .SingleOrDefault(x => x.Id == id);
            if (eventDeleted != null)
            {
                _database.Delete(eventDeleted);
                _database.SaveChanges(); 
                return true;
            }
            //eventDeleted.Active = false;
            //_database.SaveChanges();
            return false;
        }

        public bool UpdateEvent(int id, EventDTO eventDto)
        {
            var singleEvent = _database
                .Get<Event>()
                .Where(x => x.Active == true)
                .SingleOrDefault(x => x.Id == id);
            if (singleEvent != null) 
            {
                singleEvent.Name= eventDto.Name;
                singleEvent.Description= eventDto.Description;
                _database.SaveChanges();
                return true;
            }
            return false;
        }

        //public bool UpdateEvent(int id, EventDTO eventDto)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
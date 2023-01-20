using System.Net;
using Microsoft.AspNetCore.Mvc;
using Childcare.Api.ViewModels;
using Childcare.Api.ViewModels.Addresses;
using Childcare.Api.ViewModels.Events;
using Childcare.Dal.Interfaces;
using Childcare.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Childcare.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsController : ControllerBase
{

    private readonly ILogger<EventsController> _logger;
    private readonly IDatabase _database;

    public EventsController(ILogger<EventsController> logger, IDatabase database)
    {
        _logger = logger;
        _database = database;
    }

    [HttpGet]
    public ActionResult<IList<EventViewModel>> GetEvents()
    {

        return _database.Get<Event>().Select(x => new EventViewModel
        
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            })
            .ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<EventDetailViewModel> GetEventById(int id)
    {
        var singleEvent = _database.Get<Event>().Include(x => x.Address).SingleOrDefault(x => x.Id == id);

        if (singleEvent == null) return NoContent();
        
        return Ok(new EventDetailViewModel()
        {
            Id = singleEvent.Id, 
            Name = singleEvent.Name,
            Description = singleEvent.Description,
            TimeSlot = singleEvent.Timeslot,
            Address = new AddressViewModel
            {
                Id=singleEvent.Address.Id,
                Name = singleEvent.Address.Name,
                AddressLine1 = singleEvent.Address.AddressLine1,
                AddressLine2 = singleEvent.Address.AddressLine2,
                Region = singleEvent.Address.Region,
                Country = singleEvent.Address.Country,
                Zipcode = singleEvent.Address.Zipcode
                
            }
        });
    }
    
    [HttpPost]
    public ActionResult CreateEvent([FromBody] CreateEventViewModel createEventViewModel)
    {

        var newEvent = new Event
        {
            Name =createEventViewModel.Name,
            Description = createEventViewModel.Description,
            Timeslot = createEventViewModel.TimeSlot,
            Address = new Address
            {
                Name = createEventViewModel.Address.Name,
                AddressLine1 = createEventViewModel.Address.AddressLine1,
                AddressLine2 = createEventViewModel.Address.AddressLine2,
                Country = createEventViewModel.Address.Country,
                Region = createEventViewModel.Address.Region,
                Zipcode = createEventViewModel.Address.Zipcode
            }

        };
        _database.Add(newEvent);
        _database.SaveChanges();
        return StatusCode((int) HttpStatusCode.Created);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateEvent(int id, [FromBody] UpdateEventViewModel updateEventViewModel)
    {
        var existingEvent = _database.Get<Event>().SingleOrDefault(x => x.Id == id);
        if (existingEvent == null) return NotFound();

        existingEvent.Name = updateEventViewModel.Name;
        existingEvent.Description = updateEventViewModel.Description;
        existingEvent.Timeslot = updateEventViewModel.Timeslot;
        
        
        _database.SaveChanges();
        
        return NoContent();
    }

    
    [HttpDelete("{id}")]
    public ActionResult DeleteEvent(int id)
    {
        var eventToDelete = _database.Get<Event>().Where(x => x.Id == id).SingleOrDefault();
        if (eventToDelete == null) return NotFound();
        
        _database.Delete(eventToDelete);

        return Ok(eventToDelete);
    }
}

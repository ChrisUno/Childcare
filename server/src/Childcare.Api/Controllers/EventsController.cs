using System.Net;
using Microsoft.AspNetCore.Mvc;
using Childcare.Api.ViewModels;
using Childcare.Api.ViewModels.Addresses;
using Childcare.Api.ViewModels.Events;
using Childcare.Dal.Interfaces;
using Childcare.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Childcare.Services.Interfaces;
using Childcare.Services.Services.DTOs;
using AutoMapper;
using Childcare.Api.Controllers.Base;

namespace Childcare.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsController : ChildcareBaseController
{

    private readonly ILogger<EventsController> _logger;
    private readonly IMapper _mapper;
    private readonly IEventService _eventService;

    public EventsController(ILogger<EventsController> logger, IMapper mapper, IEventService eventService)
    {
        _logger = logger;
        _mapper = mapper;
        _eventService = eventService;
    }

    [HttpGet]
    public ActionResult<IList<EventViewModel>> GetEvents()
    {
        var events = _eventService.GetEvents();
        return OkOrNoContent(_mapper.Map<List<EventViewModel>>(events));
    }

    [HttpGet("{id}")]
    public ActionResult<EventDetailViewModel> GetEventById(int id)
    { 
        var singleEvent = _eventService.GetEventById(id);
        if (singleEvent == null) return NoContent();
        return OkOrNotFound(_mapper.Map<EventViewModel>(singleEvent));
    }

    [HttpPost]
    public ActionResult CreateEvent([FromBody] CreateEventViewModel createEventViewModel)
    {
        _eventService.CreateEvent(_mapper.Map<EventDTO>(createEventViewModel));
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateEvent(int id, [FromBody] UpdateEventViewModel updateEventViewModel)
    {
        _eventService.UpdateEvent(id, _mapper.Map<EventDTO>(updateEventViewModel));
        return NoContent();
    }

    
    [HttpDelete("{id}")]
    public ActionResult DeleteEvent(int id)
    {
        _eventService.DeleteEvent(id);
        return StatusCode((int)HttpStatusCode.OK);
    }
}

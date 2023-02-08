using System.Net;
using Microsoft.AspNetCore.Mvc;
using Childcare.Api.ViewModels;
using Childcare.Api.ViewModels.Family;
using Childcare.Api.ViewModels.Users;
using Childcare.Dal.Interfaces;
using Childcare.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Childcare.Services.Interfaces;
using Childcare.Services.Services.DTOs;
using AutoMapper;
using Childcare.Services.Services;

namespace Childcare.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FamilyController : ControllerBase
{
    private readonly ILogger<FamilyController> _logger;
    private readonly IMapper _mapper;
    private readonly IFamilyService _familyService;


    public FamilyController(ILogger<FamilyController> logger, IMapper mapper, IFamilyService familyService)
    {
        _logger = logger;
        _mapper = mapper;
        _familyService = familyService;
    }

    [HttpGet]
    public ActionResult<IList<FamilyViewModel>> GetFamilies()
    {
        var families = _familyService.GetFamilies();
        return Ok (_mapper.Map<List<FamilyViewModel>>(families));
    }

    
    [HttpGet("{id}")]
    public ActionResult<FamilyDetailViewModel> GetFamilyById(int id)
    {
        var family = _familyService.GetFamilyById(id);
        if (family == null) return NoContent();
        return Ok(_mapper.Map<FamilyViewModel>(family));
    }

    
    

    [HttpPut("{id}")]
    public ActionResult UpdateFamily(int id, [FromBody] UpdateFamilyViewModel updateFamilyViewModel)
    {
        _familyService.UpdateFamily(id, _mapper.Map<FamilyDTO>(updateFamilyViewModel));
        return NoContent();
    }

    [HttpPost]
    public ActionResult CreateFamily([FromBody] CreateFamilyViewModel createFamilyViewModel)
    {
       _familyService.CreateFamily(_mapper.Map<FamilyDTO>(createFamilyViewModel));
        return StatusCode((int)HttpStatusCode.Created);

    }

    [HttpDelete("{id}")]
    public ActionResult DeleteFamily(int id)
    {
        _familyService.DeleteFamily(id);
        return StatusCode((int)HttpStatusCode.OK);
    }
}

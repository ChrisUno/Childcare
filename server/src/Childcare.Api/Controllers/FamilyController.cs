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

namespace Childcare.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FamilyController : ControllerBase
{
    private readonly ILogger<FamilyController> _logger;
    private readonly IDatabase _database;
    private readonly IFamilyService _familyService;


    public FamilyController(ILogger<FamilyController> logger, IDatabase database, IFamilyService familyService)
    {
        _logger = logger;
        _database = database;
        _familyService = familyService;
    }

    [HttpGet]
    public ActionResult<IList<FamilyViewModel>> GetFamilies()
    {

        return _database.Get<Family>().Select(x => new FamilyViewModel
        
        {
            Id = x.Id,
            Name = x.Name
        })
        .ToList();
    }

    
    [HttpGet("{id}")]
    public ActionResult<FamilyDetailViewModel> GetFamilyById(int id)
    {
        var family = _database.Get<Family>().Include(x => x.Users).SingleOrDefault(x => x.Id == id);

        if (family == null) return NoContent();
        
        return Ok(new FamilyDetailViewModel()
        {
            Id = family.Id, 
            Name = family.Name,
            Users = family.Users.Select(x => new UserViewModel
            {
                Id= x.Id,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToList()
        });
    }

    
    

    [HttpPut("{id}")]
    public ActionResult UpdateFamily(int id, [FromBody] UpdateFamilyViewModel updateFamilyViewModel)
    {
        var family = new FamilyDTO { Name = updateFamilyViewModel.Name };
        var existingFamily = _familyService.UpdateFamily(id, family);
        if (!existingFamily) return NotFound();

        existingFamily.Name = updateFamilyViewModel.Name;
        
        return NoContent();
    }

    [HttpPost]
    public ActionResult CreateFamily([FromBody] CreateFamilyViewModel createFamilyViewModel)
    {

        var newFamily = new Family
        {
            Name =createFamilyViewModel.Name
        };
        _database.Add(newFamily);
        _database.SaveChanges();
        return StatusCode((int) HttpStatusCode.Created);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteFamily(int id)
    {
        var FamilyToDelete = _database.Get<Family>().Where(x => x.Id == id).SingleOrDefault();
        if (FamilyToDelete == null) return NotFound();
        
        _database.Delete(FamilyToDelete);

        return Ok(FamilyToDelete);
    }
}

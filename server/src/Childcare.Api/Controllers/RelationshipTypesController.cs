using Microsoft.AspNetCore.Mvc;
using System.Net;
using Childcare.Api.ViewModels;
using Childcare.Api.ViewModels.RelationshipTypes;
using Childcare.Dal.Interfaces;
using Childcare.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Childcare.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RelationshipTypesController : ControllerBase
{

    private readonly ILogger<RelationshipTypesController> _logger;
    private readonly IDatabase _database;

    public RelationshipTypesController(ILogger<RelationshipTypesController> logger, IDatabase database)
    {
        _logger = logger;
        _database = database;
    }
    
    
    [HttpGet]
    public ActionResult<IList<RelationshipTypeViewModel>> GetRelations()
    {

        return _database.Get<RelationshipType>().Select(x => new RelationshipTypeViewModel
        
            {
                Id = x.Id,
                Relationship = x.Relationship
            })
            .ToList();
    }
    [HttpPost]
    public ActionResult CreateRelationshipType([FromBody] CreateRelationshipTypeViewModel createRelationshipTypeViewModel)
    {

        var newRelationshipType = new RelationshipType
        {
            Relationship = createRelationshipTypeViewModel.Relationship
        };
        _database.Add(newRelationshipType);
        _database.SaveChanges();
        return StatusCode((int) HttpStatusCode.Created);
    }
}
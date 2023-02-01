using Microsoft.AspNetCore.Mvc;
using System.Net;
using Childcare.Api.ViewModels;
using Childcare.Api.ViewModels.RelationshipTypes;
using Childcare.Dal.Interfaces;
using Childcare.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Childcare.Services.Interfaces;
using Childcare.Services.Services.DTOs;
using Childcare.Services.Services;

namespace Childcare.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RelationshipTypesController : ControllerBase
{

    private readonly ILogger<RelationshipTypesController> _logger;
    private readonly IDatabase _database;
    private readonly IRelationshipTypeService _relationshipTypeService;

    public RelationshipTypesController(ILogger<RelationshipTypesController> logger, IDatabase database, IRelationshipTypeService relationshipTypeService)
    {
        _logger = logger;
        _database = database;
        _relationshipTypeService = relationshipTypeService;
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
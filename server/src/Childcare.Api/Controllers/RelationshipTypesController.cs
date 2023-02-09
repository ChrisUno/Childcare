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
using AutoMapper;
using Childcare.Api.Controllers.Base;

namespace Childcare.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RelationshipTypesController : ChildcareBaseController
{

    private readonly ILogger<RelationshipTypesController> _logger;
    private readonly IMapper _mapper;
    private readonly IRelationshipTypeService _relationshipTypeService;

    public RelationshipTypesController(ILogger<RelationshipTypesController> logger, IMapper mapper, IRelationshipTypeService relationshipTypeService)
    {
        _logger = logger;
        _mapper =   mapper;
        _relationshipTypeService = relationshipTypeService;
    }
    
    
    [HttpGet]
    public ActionResult<IList<RelationshipTypeViewModel>> GetRelations()
    {
        var relations = _relationshipTypeService.GetRelationshipTypes();
        return OkOrNoContent(_mapper.Map<List<RelationshipTypeViewModel>>(relations));
    }

    [HttpPost]
    public ActionResult CreateRelationshipType([FromBody] CreateRelationshipTypeViewModel createRelationshipTypeViewModel)
    {
        _relationshipTypeService.CreateRelationshipType ( _mapper.Map<RelationshipTypeDTO>(createRelationshipTypeViewModel));
        return StatusCode((int) HttpStatusCode.Created);
    }
}
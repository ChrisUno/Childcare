using System.Net;
using Microsoft.AspNetCore.Mvc;
using Childcare.Api.ViewModels;
using Childcare.Api.ViewModels.Users;
using Childcare.Api.ViewModels.Addresses;
using Childcare.Dal.Interfaces;
using Childcare.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace Childcare.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly IDatabase _database;

    public UsersController(ILogger<UsersController> logger, IDatabase database)
    {
        _logger = logger;
        _database = database;
    }

    
    [HttpGet]
    public ActionResult<IList<UserViewModel>> GetUsers()
    {

        return _database.Get<User>().Select(x => new UserViewModel
        
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email
            })
            .ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<UserDetailViewModel> GetUserById(int id)
    {
        var user = _database.Get<User>()
            .Include(x => x.Address)
            .Include(x => x.Family)
            .Include(x => x.ChildRelationships)
                .ThenInclude(x=> x.Parent)
            .Include(x=>x.ChildRelationships).ThenInclude(x=>x.RelationshipType)
            .SingleOrDefault(x => x.Id == id);

        if (user == null) return NoContent();
        
        return Ok(new UserDetailViewModel()
        {
            Id = user.Id, 
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Family = new FamilyViewModel
            {
                Id = user.FamilyId,
                Name = user.Family.Name
            },
            Address = new AddressViewModel
            {
                Id= user.Address.Id,
                Name = user.Address.Name,
                AddressLine1 = user.Address.AddressLine1,
                AddressLine2 = user.Address.AddressLine2,
                Region = user.Address.Region,
                Country = user.Address.Country,
                Zipcode = user.Address.Zipcode
            },
            Relationship = user.ChildRelationships.Select(x => new RelationshipTypeViewModel
            {
                Id = x.Id,
                Relationship = x.RelationshipType.Relationship,
                User = new UserViewModel
                {
                    Id = x.ParentId,
                    FirstName = x.Parent.FirstName,
                    LastName = x.Parent.LastName,
                    Email = x.Parent.Email
                }
            }).ToList()
        });
    }
    
    [HttpPost]
    public ActionResult CreateUser([FromBody] CreateUserViewModel createUserViewModel)
    {

        var newUser = new User
        {
            FirstName = createUserViewModel.FirstName,
            LastName = createUserViewModel.LastName,
            Email = createUserViewModel.Email,
            Address = new Address
            {
                Name = createUserViewModel.Address.Name,
                AddressLine1 = createUserViewModel.Address.AddressLine1,
                AddressLine2 = createUserViewModel.Address.AddressLine2,
                Country = createUserViewModel.Address.Country,
                Region = createUserViewModel.Address.Region,
                Zipcode = createUserViewModel.Address.Zipcode
            },
            Family = new Family
            {
                Name = createUserViewModel.Address.Name
            }

        };
        _database.Add(newUser);
        _database.SaveChanges();
        return StatusCode((int) HttpStatusCode.Created);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateUser(int id, [FromBody] UpdateUserViewModel updateUserViewModel)
    {
        var existingUser = _database.Get<User>().SingleOrDefault(x => x.Id == id);
        if (existingUser == null) return NotFound();

        existingUser.FirstName = updateUserViewModel.FirstName;
        existingUser.LastName = updateUserViewModel.LastName;
        existingUser.Email = updateUserViewModel.Email;

        _database.SaveChanges();
        
        return NoContent();
    }


    [HttpDelete("{id}")]
    public ActionResult DeleteUser(int id)
    {
    
        var existingUser = _database.Get<User>().SingleOrDefault(x => x.Id == id);
        if (existingUser == null) return NotFound();
        existingUser.Active = false;

        _database.SaveChanges();

        return StatusCode((int) HttpStatusCode.OK);

    }
}

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Childcare.Api.ViewModels;
using Childcare.Api.ViewModels.Users;

namespace Childcare.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<IList<UserViewModel>> GetUsers([FromQuery] string? firstName, [FromQuery] string? lastName)
    {
        _logger.Log(LogLevel.Information, lastName);
        
        var data = Enumerable.Range(1, 5)
            .Select(index => new UserViewModel 
        {
            Id = index,
            FirstName = "Chris",
            LastName = "Crawford"
        })
        .ToList();

        if (!string.IsNullOrWhiteSpace(firstName))
        {
           data = data
               .Where(x => x.FirstName.StartsWith(firstName, StringComparison.InvariantCultureIgnoreCase))
               .ToList();
        }
        
        if (!string.IsNullOrWhiteSpace(lastName))
        {
            data = data
                .Where(x => x.LastName.StartsWith(lastName, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
        }
        

        return data;
    }


    [HttpGet("{id}")]
    public ActionResult<UserDetailViewModel> GetUserById(int id)
    {
     return new UserDetailViewModel 
        {
            Id = id,
            FirstName = "Chris",
            LastName = "Crawford",
            Address = new AddressViewModel {
                Id = id,
                AddressLine1 = "8 Rathmoyle park west",
                AddressLine2 = "Carrickfergus",
                Country  = "NI",
                Region = "Belfast",
                Zipcode  = "BT387NG"
            } 
            
        };
     
    }

    [HttpPost]
    public ActionResult CreateUser([FromBody] CreateUserViewModel createUserViewModel)
    {
        return StatusCode((int) HttpStatusCode.Created);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateUser(int id, [FromBody] UpdateUserViewModel updateUserViewModel)
    {
        if (id == 1) return NoContent();

        return NotFound();
    }


    [HttpDelete("{id}")]
    public ActionResult SoftDeleteUser(int id)
    {
        if (id == 1) return NoContent();

        return NotFound();
    }
}

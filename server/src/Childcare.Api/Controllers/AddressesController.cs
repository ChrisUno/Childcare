using System.Net;
using Microsoft.AspNetCore.Mvc;
using Childcare.Api.ViewModels;
using Childcare.Api.ViewModels.Addresses;
using Childcare.Api.ViewModels.Users;
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
public class AddressesController : ControllerBase
{
    private readonly ILogger<AddressesController> _logger;
    private readonly IDatabase _database;
    private readonly IAddressService _addressService;

    public AddressesController(ILogger<AddressesController> logger, IDatabase database, IAddressService addressService)
    {
        _logger = logger;
        _database = database;
        _addressService = addressService;
    }
    
    [HttpGet]
    public ActionResult<IList<AddressViewModel>> GetAddresses()
    {

        return _database.Get<Address>().Select(x => new AddressViewModel
        
            {
                Id = x.Id,
                Name = x.Name,
                AddressLine1 = x.AddressLine1,
                AddressLine2 = x.AddressLine2,
                Region = x.Region,
                Country = x.Country,
                Zipcode = x.Zipcode
            })
            .ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<AddressDetailViewModel> GetAddressById(int id)
    {
        var address=_database.Get<Address>().Include(x => x.Users).SingleOrDefault(x => x.Id == id);

        if (address == null) return NoContent();
        
        return Ok(new AddressDetailViewModel()
        {
            Id = address.Id,
            Name = address.Name,
            AddressLine1 = address.AddressLine1,
            AddressLine2 = address.AddressLine2,
            Region = address.Region,
            Country = address.Country,
            Zipcode = address.Zipcode,
            Users = address.Users.Select(x => new UserViewModel
            {
                Id= x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email
            }).ToList()
        });
    }
    
    [HttpPost]
    public ActionResult CreateAddress([FromBody] CreateAddressViewModel createAddressViewModel)
    {

        var newAddress = new Address
        {
            Name =createAddressViewModel.Name,
            AddressLine1 = createAddressViewModel.AddressLine1,
            AddressLine2 = createAddressViewModel.AddressLine2,
            Country = createAddressViewModel.Country,
            Region = createAddressViewModel.Region,
            Zipcode = createAddressViewModel.Zipcode,
            User = new User
            {
                FirstName =  createAddressViewModel.User.FirstName,
                LastName = createAddressViewModel.User.LastName,
                Email = createAddressViewModel.User.Email
            }

        };
        _database.Add(newAddress);
        _database.SaveChanges();
        return StatusCode((int) HttpStatusCode.Created);
    }
    
    [HttpPut("{id}")]
    public ActionResult UpdateAddress(int id, [FromBody] UpdateAddressViewModel updateAddressViewModel)
    {
        var existingAddress = _database.Get<Address>().SingleOrDefault(x => x.Id == id);
        if (existingAddress == null) return NotFound();

        existingAddress.Name = updateAddressViewModel.Name;
        existingAddress.AddressLine1 = updateAddressViewModel.AddressLine1;
        existingAddress.AddressLine2 = updateAddressViewModel.AddressLine2;
        existingAddress.Country = updateAddressViewModel.Country;
        existingAddress.Region = updateAddressViewModel.Region;
        existingAddress.Zipcode = updateAddressViewModel.Zipcode;
        
        _database.SaveChanges();
        
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public ActionResult DeleteAddress(int id)
    {
        var addressToDelete = _database.Get<Address>().Where(x => x.Id == id).SingleOrDefault();
        if (addressToDelete == null) return NotFound();
        
        _database.Delete(addressToDelete);

        return Ok(addressToDelete);
    }

}

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
using AutoMapper;
using Childcare.Api.Controllers.Base;

namespace Childcare.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressesController : ChildcareBaseController
{
    private readonly ILogger<AddressesController> _logger;
    private readonly IMapper _mapper;
    private readonly IAddressService _addressService;

    public AddressesController(ILogger<AddressesController> logger, IMapper mapper, IAddressService addressService)
    {
        _logger = logger;
        _mapper = mapper;
        _addressService = addressService;
    }
    
    [HttpGet]
    public ActionResult<IList<AddressViewModel>> GetAddresses()
    {
        var addresses = _addressService.GetAddresses();
        return OkOrNoContent (_mapper.Map<List<AddressViewModel>>(addresses));
    }

    [HttpGet("{id}")]
    public ActionResult<AddressDetailViewModel> GetAddressById(int id)
    {
        var address = _addressService.GetAddressById(id);
        if (address == null) return NoContent();
        return OkOrNotFound (_mapper.Map<AddressViewModel>(address));
    }
    
    [HttpPost]
    public ActionResult CreateAddress([FromBody] CreateAddressViewModel createAddressViewModel)
    {
        _mapper.Map<AddressViewModel>(createAddressViewModel);
        return StatusCode((int) HttpStatusCode.Created);
    }
    
    [HttpPut("{id}")]
    public ActionResult UpdateAddress(int id, [FromBody] UpdateAddressViewModel updateAddressViewModel)
    {
        _addressService.UpdateAddress(id, _mapper.Map<AddressDTO>(updateAddressViewModel));
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteAddress(int id)
    { 
        _addressService.DeleteAddress(id);
        return StatusCode((int)HttpStatusCode.OK);
    }

}

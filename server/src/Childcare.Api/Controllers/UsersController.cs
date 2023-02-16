using System.Net;
using Microsoft.AspNetCore.Mvc;
using Childcare.Api.ViewModels;
using Childcare.Api.ViewModels.Users;
using Childcare.Api.ViewModels.Addresses;
using Childcare.Dal.Interfaces;
using Childcare.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Childcare.Services.Interfaces;
using Childcare.Services.Services.DTOs;
using AutoMapper;
using Childcare.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;

namespace Childcare.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ChildcareBaseController
{
    private readonly ILogger<UsersController> _logger;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public UsersController(ILogger<UsersController> logger, IMapper mapper ,IUserService userService)
    {
        _logger = logger;
        _userService = userService;
        _mapper= mapper;
    }

    
    [HttpGet]
    public ActionResult<IList<UserViewModel>> GetUsers()
    {
        var users = _userService.GetUsers();
        return OkOrNoContent(_mapper.Map<List<UserViewModel>>(users));

    }

    [HttpGet("{id}")]
    public ActionResult<UserDetailViewModel> GetUserById(int id)
    { 
        var user = _userService.GetUserById(id);
        if (user == null) return NoContent();
        return OkOrNoContent(_mapper.Map<UserViewModel>(user));
    }
    
    [HttpPost]
    [AllowAnonymous]
    public ActionResult CreateUser([FromBody] CreateUserViewModel createUserViewModel)
    {
        _userService.CreateUser(_mapper.Map<UserDTO>(createUserViewModel));
        return StatusCode((int) HttpStatusCode.Created);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateUser(int id, [FromBody] UpdateUserViewModel updateUserViewModel)
    {
        _userService.UpdateUser(id, _mapper.Map<UserDTO>(updateUserViewModel));
        return NoContent();
    }


    [HttpDelete("{id}")]
    public ActionResult DeleteUser(int id)
    {
        _userService.DeleteUser(id);
        return StatusCode((int) HttpStatusCode.OK);

    }
}
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Childcare.API.Authentication;
using Childcare.API.ViewModels;
using Childcare.Services.Interfaces;
using Childcare.Services.Services.DTOs;
using Childcare.Api.Controllers.Base;

namespace Childcare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ChildcareBaseController
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _service;


        public AuthenticationController(IMapper mapper, IAuthenticationService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<AuthenticationResultViewModel> Authenticate([FromBody] AuthenticationRequestViewModel authenticationRequestViewModel)
        {
            var user =
            _service.Authenticate(authenticationRequestViewModel.Email, authenticationRequestViewModel.Password);

            if (user is null)
                return Unauthorized();

            return new AuthenticationResultViewModel
            {
                AccessToken = GenerateToken(user, 600),
                RefreshToken = GenerateToken(user, 18000)
            };
        }

        [HttpGet]
        public ActionResult<AuthenticationResultViewModel> Refresh([FromServices] IAuthorizedAccountProvider authorizedAccountProvider)
        {

            var user = authorizedAccountProvider.GetLoggedInAccount();

            if (user is null)
                return Unauthorized();

            var authenticationResult = new AuthenticationResultViewModel
            {
                AccessToken = GenerateToken(user, 600),
                RefreshToken = GenerateToken(user, 18000)
            };

            return new ActionResult<AuthenticationResultViewModel>(authenticationResult);
        }

        private string GenerateToken(UserDTO user, int expirationTimeInMinutes)
        {
            var secretKey = Encoding.UTF8.GetBytes("JWTMySonTheDayYouWereBorn");
            var securityKey = new SymmetricSecurityKey(secretKey);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var expiryTime = DateTime.UtcNow.AddMinutes(expirationTimeInMinutes);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {

                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, "User")
                }),
                Expires = expiryTime,
                SigningCredentials = credentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            var tokenString = tokenHandler.WriteToken(jwtToken);
            return tokenString;
        }
    }
}
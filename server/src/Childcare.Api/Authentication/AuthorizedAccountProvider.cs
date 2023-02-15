using Childcare.Services.Interfaces;
using Childcare.Services.Services.DTOs;
using System.Security.Claims;
using Childcare.Services.Interfaces;
using Childcare.Services.Services;

namespace Childcare.API.Authentication
{
    public class AuthorizedAccountProvider : IAuthorizedAccountProvider
    {
        private UserDTO? _family;
        private readonly IUserService _familyService;
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthorizedAccountProvider(IUserService familyService, IHttpContextAccessor contextAccessor)
        {
            _familyService = familyService;
            _contextAccessor = contextAccessor;
        }

        public async Task<UserDTO> GetLoggedInAccount()
        {
            if (_family is not null)
                return _family;

            var identifier = _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrWhiteSpace(identifier))
                return null;

            _family = _familyService.GetUserById(int.Parse(identifier));

            return _family;
        }
    }

    public interface IAuthorizedAccountProvider
    {
        Task<UserDTO> GetLoggedInAccount();
    }
}
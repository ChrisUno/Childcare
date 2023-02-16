using Childcare.Services.Interfaces;
using Childcare.Services.Services.DTOs;
using System.Security.Claims;
using Childcare.Services.Interfaces;
using Childcare.Services.Services;

namespace Childcare.API.Authentication
{
    public class AuthorizedAccountProvider : IAuthorizedAccountProvider
    {
        private UserDTO? _user;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthorizedAccountProvider(IUserService userService, IHttpContextAccessor contextAccessor)
        {
            _userService = userService;
            _contextAccessor = contextAccessor;
        }

        public UserDTO GetLoggedInAccount()
        {
            if (_user is not null)
                return _user;

            var identifier = _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrWhiteSpace(identifier))
                return null;

            _user = _userService.GetUserById(int.Parse(identifier));

            return _user;
        }
    }

    public interface IAuthorizedAccountProvider
    {
        UserDTO GetLoggedInAccount();
    }
}
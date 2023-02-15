using Childcare.Services.Services.DTOs;

namespace Childcare.Services.Interfaces
{
    public interface IAuthenticationService
    {
        UserDTO? Authenticate(string email, string password);
    }
}
using AutoMapper;
using Childcare.Dal.Models;
using Childcare.Services.Services.DTOs;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using Childcare.Dal.Interfaces;
using Childcare.Dal.Models;
using Childcare.Dal.Specifications.Users;
using Childcare.Services.Interfaces;
using BC = BCrypt.Net.BCrypt;
using Childcare.Services.Interfaces;
using Childcare.DAL.Specifications.Users;

namespace Childcare.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IChildcareDatabase _database;
        private readonly IMapper _mapper;

        public AuthenticationService(IChildcareDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public UserDTO? Authenticate(string email, string password)
        {
            var family = _database.Get<User>().Where(new UserByEmailSpec(email)).SingleOrDefault();

            if (family is null || !BC.Verify(password, family.Password))
                return null;
            return _mapper.Map<UserDTO>(family);
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Childcare.Dal.Interfaces;
using Childcare.Dal.Models;
using Childcare.Services.Exceptions;
using Childcare.Services.Interfaces;
using Childcare.Services.Services.DTOs;

namespace Childcare.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IChildcareDatabase _database;
        private readonly IMapper _mapper;

        public UserService(IChildcareDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        } 

        public IList<UserDTO> GetUsers()
        {
            var users = _database
                .Get<User>()
                .ToList();
            return users.Select(x=> new UserDTO
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email
            }).ToList();
        }

        public UserDTO GetUserById(int id)
        {
            var user = _database
                .Get<User>()
                .SingleOrDefault(x=>x.Id==id);
            return new UserDTO 
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }

        public bool CreateUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            //var newUser= new User{Id= userDTO.Id, FirstName = userDTO.FirstName,LastName = userDTO.LastName,Email = userDTO.Email};
            //_database.Add(newUser);
            _database.Add(user);
            _database.SaveChanges();
            return true;
        }
        
        public bool DeleteUser(int id)
        {
            var user = _database
                .Get<User>()
                .SingleOrDefault(x => x.Id == id);
            if (user != null)
            {
                _database.Delete(user);
                _database.SaveChanges();   
                return true;
            }
            return false;
        }

        public bool UpdateUser(int id, UserDTO user)
        {
            
            var existingUser = _database
                .Get<User>()
                .Where(x => x.Active == true)
                .SingleOrDefault(x => x.Id == id);

            if (existingUser == null) throw new NotFoundException("Account Not Found");

            if (user.Password is not null)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            }

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            _database.SaveChanges();

            return true;


        }
    }
}
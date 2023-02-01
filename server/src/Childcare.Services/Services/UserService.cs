using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Childcare.Dal.Interfaces;
using Childcare.Dal.Models;
using Childcare.Services.Interfaces;
using Childcare.Services.Services.DTOs;

namespace Childcare.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IDatabase _database;
        
        public UserService(IDatabase database)
        {
            _database = database;
        } 

        public IList<UserDTO> GetUsers()
        {
            var users = _database.Get<User>().ToList();
            return users.Select(x=> new UserDTO{ Id = x.Id, FirstName = x.FirstName}).ToList();
        }

        public UserDTO GetUserById(int id)
        {
            var user = _database.Get<User>().SingleOrDefault(x=>x.Id==id);
            return new UserDTO {Id = user.Id, FirstName = user.FirstName,LastName = user.LastName,Email = user.Email };
        }

        public bool CreateUser(UserDTO userDTO)
        {
            var user= new User{Id= userDTO.Id, FirstName = userDTO.FirstName,LastName = userDTO.LastName,Email = userDTO.Email};
            _database.Add(user);
            _database.SaveChanges();
            return true;
        }
        
        public bool DeleteUser(int id)
        {
            var user = _database.Get<User>().SingleOrDefault(x => x.Id == id);
            user.Active = false;
            _database.SaveChanges();
            return true;
        }

        public bool UpdateUser(int id, UserDTO user)
        {
            
            var existingUser = _database.Get<User>()
                .Where(x => x.Active == true)
                .SingleOrDefault(x => x.Id == id);

            if (existingUser == null) return false;

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            _database.SaveChanges();

            return true;


        }
    }
}
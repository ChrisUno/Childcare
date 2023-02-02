using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System .Threading.Tasks;
using Childcare.Dal.Interfaces;
using Childcare.Dal.Models;
using Childcare.Services.Interfaces;
using Childcare.Services.Services.DTOs;


namespace Childcare.Services.Services
{
    public class AddressService : IAddressService
    {
        private readonly IDatabase _database;
        
        public AddressService(IDatabase database)
        {
            _database = database;
        } 

        public IList<AddressDTO> GetAddresses()
        {
            var addresses = _database.Get<Address>().ToList();
            return addresses.Select(x=> new AddressDTO{ Id = x.Id, Name = x.Name}).ToList();
        }

        public AddressDTO GetAddressById(int id)
        {
            var address = _database.Get<Address>().SingleOrDefault(x=>x.Id==id);
            return new AddressDTO {Id = address.Id, Name = address.Name };
        }


    }
}
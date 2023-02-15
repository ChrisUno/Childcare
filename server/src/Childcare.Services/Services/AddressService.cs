using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System .Threading.Tasks;
using AutoMapper;
using Childcare.Dal.Interfaces;
using Childcare.Dal.Models;
using Childcare.Services.Interfaces;
using Childcare.Services.Services.DTOs;


namespace Childcare.Services.Services
{
    public class AddressService : IAddressService
    {
        private readonly IChildcareDatabase _database;
        
        public AddressService(IChildcareDatabase database, IMapper mapper)
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

        public bool UpdateAddress(int id, AddressDTO address)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAddress(int id)
        {
            throw new NotImplementedException();
        }
    }
}
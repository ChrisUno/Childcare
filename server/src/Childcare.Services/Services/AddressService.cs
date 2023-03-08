using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System .Threading.Tasks;
using System.Xml.Linq;
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
        private readonly IMapper _mapper;
        
        public AddressService(IChildcareDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        } 

        public IList<AddressDTO> GetAddresses()
        {
            var addresses = _database
                .Get<Address>()
                .ToList();
            return addresses.Select(x=> new AddressDTO
            { 
                Id = x.Id,
                Name = x.Name,
                AddressLine1 = x.AddressLine1,
                AddressLine2 = x.AddressLine2,
                Country = x.Country,
                Region = x.Region,
                Zipcode = x.Zipcode
            }).ToList();
        }
        public AddressDTO GetAddressById(int id)
        {
            var address = _database.Get<Address>().SingleOrDefault(x=>x.Id==id);
            return new AddressDTO 
            {
                Id = address.Id,
                Name = address.Name,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                Country = address.Country,
                Region = address.Region,
                Zipcode = address.Zipcode
            };
        }
        public bool UpdateAddress(int id, AddressDTO addressDTO)
        {
            var address = _database.Get<Address>()
                .SingleOrDefault(x => x.Id == id);
            if (address != null)
            {
                address.Name = addressDTO.Name;
                address.AddressLine1 = addressDTO.AddressLine1;
                address.AddressLine2 = addressDTO.AddressLine2;
                address.Country = addressDTO.Country;
                address.Zipcode = addressDTO.Zipcode;
                address.Region = addressDTO.Region;
                _database.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteAddress(int id)
        {
            var address = _database
                .Get<Address>()
                .SingleOrDefault(x => x.Id == id);
            if (address != null)
            {
                _database.Delete(address);
                _database.SaveChanges();
                return true;
            }
            return false;

        }
        public bool CreateAddress(AddressDTO addressDTO)
        {
            var address = new Address
            {
                Name = addressDTO.Name,
                AddressLine1 = addressDTO.AddressLine1,
                AddressLine2 = addressDTO.AddressLine2,
                Country = addressDTO.Country,
                Zipcode = addressDTO.Zipcode,
                Region = addressDTO.Region
            };
            _database.Add(address);
            _database.SaveChanges();
            return true;
        }
    }
}
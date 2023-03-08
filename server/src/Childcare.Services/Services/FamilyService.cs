using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Childcare.Dal.Interfaces;
using Childcare.Dal.Models;
using Childcare.Services.Interfaces;
using Childcare.Services.Services.DTOs;

namespace Childcare.Services.Services
{
    public class FamilyService : IFamilyService
    {
        private readonly IChildcareDatabase _database;
        private readonly IMapper _mapper;

        public FamilyService(IChildcareDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        } 

        public IList<FamilyDTO> GetFamilies()
        {
            var families = _database.Get<Family>().ToList();
            return families.Select(x=> new FamilyDTO
            { 
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public FamilyDTO GetFamilyById(int id)
        {
            var family = _database
                .Get<Family>()
                .SingleOrDefault(x =>x.Id==id);
            return new FamilyDTO 
            {
                Id = family.Id,
                Name = family.Name 
            };
        }

        public bool CreateFamily(FamilyDTO familyDTO)
        {
            var family = new Family
            {
                Id = familyDTO.Id,
                Name = familyDTO.Name
            };
            _database.Add(family);
            _database.SaveChanges();
            return true;
        }

        public bool DeleteFamily(int id)
        {
            var family = _database
                .Get<Family>()
                .SingleOrDefault(x => x.Id == id);
            family.Active = false;
            if (family != null)
            {
                _database.Delete(family);
                _database.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateFamily(int id, FamilyDTO family)
        {
            var existingFamily = _database.Get<Family>()
                .Where(x => x.Active == true)
                .SingleOrDefault(x => x.Id == id);

            if (existingFamily == null) return false;
            existingFamily.Name = family.Name;
            _database.SaveChanges();
            return true;

        }
    }
}
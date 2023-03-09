using Childcare.Dal.Contexts;
using Childcare.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Childcare.API.Integration.Test.Base
{
    public static class DatabaseSeed
    {
        public static void SeedDatabase(ChildcareContext database)
        {
            var address = new Address
            {
                Id = 1,
                Name = "Name Test",
                AddressLine1 = "Address Line 1 test",
                AddressLine2 = "Address Line 2 test",
                Region = "Region test",
                Country = "Country test",
                Zipcode = "Zipcode test"
                
            };

            var singleEvent = new Event
            {
                Id = 1,
                Name = "Name Test",
                Description = "Description test",
                Timeslot = DateTime.Now,
                AddressId = 1
            };

            var family = new Family
            {
                Id = 1,
                Name = "Name Test"

            };

            var user = new User
            {
                Id = 1,
                FirstName = "firstName Test",
                LastName = "LastName test",
                Email = "Email test",
                Password = " Password test",
               //FamilyId = 1,
                Active = true,
                //AddressId = 1
            };

            var relationshipType = new RelationshipType
            {
                Id = 1,
                Relationship = "Relationship Test"
            };

            database.Add(address);
            database.Add(singleEvent);
            database.Add(family);
            database.Add(user);
            database.Add(relationshipType);

            database.SaveChanges();
        }
    }
}
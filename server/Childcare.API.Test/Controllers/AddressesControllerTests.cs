using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Childcare.API.Test.Controllers
{
    internal class AddressesControllerTests
    {
        private readonly ILogger<AddressesController> _logger;
        private readonly IDatabase _database;
        private readonly IAddressService _addressService;

        public AddressesController()
        {
            _logger = logger;
            _database = database;
            _addressService = addressService;
        }
    }
}

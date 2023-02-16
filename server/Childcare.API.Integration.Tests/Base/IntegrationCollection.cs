using Childcare.Api.Integration.Test.Base;
using Childcare.API.Integration.Test.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Childcare.API.Integration.Test.Base
{
    [CollectionDefinition("Integration")]
    public class IntegrationCollection : ICollectionFixture<IntegrationClassFixture>
    {

    }
}

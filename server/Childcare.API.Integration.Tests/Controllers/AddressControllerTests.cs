using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Childcare.API.Integration.Test.Models;
using Childcare.Api.ViewModels;
using Xunit.Abstractions;
using System.Net.Http;
using Xunit;
using Childcare.Api.Integration.Test.TestUtilities;
using Childcare.Api.ViewModels.Addresses;
using Microsoft.AspNetCore.Mvc.Testing;
using Childcare.Api.Integration.Test.Base;

namespace Childcare.API.Integration.Test.Controllers
{
    [Collection("Integration")]
    public class AddressControllerTests
    {
        private readonly HttpClient _httpClient;
        private readonly ITestOutputHelper _testOutputHelper;

        public AddressControllerTests(ITestOutputHelper testOutputHelper, IntegrationClassFixture integrationFixture)
        {
            var opt = new WebApplicationFactoryClientOptions();
            opt.BaseAddress = new Uri("https://localhost");

            _testOutputHelper = testOutputHelper;
            _httpClient = integrationFixture.Host.CreateClient(opt);
        }

        [Fact]
        public async Task GetAll_WhenAddressesPresent_ReturnsOk()
        {
            var response = await _httpClient.GetAsync("/addresses/");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var value = await response.Content.ReadAsStringAsync();
            _testOutputHelper.WriteLine(value.VerifyDeSerialization<AddressViewModel[]>());
        }

        [Fact]
        public async Task Create_WhenNewAddressDetailsInvalid_ReturnsValidationErrors()
        {
            CreateAddressViewModel newAddress = new CreateAddressViewModel();

            var response = await _httpClient.PostAsJsonAsync("/addresses/", newAddress);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var value = await response.Content.ReadAsStringAsync();

            var result = value.VerifyDeSerialize<ValidationModel>();
            result.Errors.CheckIfErrorPresent("Name", "Name must be not null");

            _testOutputHelper.WriteLine(value);
        }
    }
}
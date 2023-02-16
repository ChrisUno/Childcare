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
using Childcare.Api.ViewModels.Events;

namespace Childcare.API.Integration.Test.Controllers
{
    [Collection("Integration")]
    public class EventControllerTests
    {
        private readonly HttpClient _httpClient;
        private readonly ITestOutputHelper _testOutputHelper;

        public EventControllerTests(ITestOutputHelper testOutputHelper, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async Task GetAll_WhenEventsPresent_ReturnsOk()
        {
            var response = await _httpClient.GetAsync("/events/");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var value = await response.Content.ReadAsStringAsync();
            _testOutputHelper.WriteLine(value.VerifyDeSerialization<EventViewModel[]>());
        }

        [Fact]
        public async Task Create_WhenNewEventDetailsInvalid_ReturnsValidationErrors()
        {
            CreateEventViewModel newEvent = new CreateEventViewModel();

            var response = await _httpClient.PostAsJsonAsync("/events/", newEvent);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var value = await response.Content.ReadAsStringAsync();

            var result = value.VerifyDeSerialize<ValidationModel>();
            result.Errors.CheckIfErrorPresent("Name", "Name must be not null");

            _testOutputHelper.WriteLine(value);
        }
    }
}
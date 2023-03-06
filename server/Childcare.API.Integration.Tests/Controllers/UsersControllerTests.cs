using System.Net;
using System.Threading.Tasks;
using Childcare.API.Integration.Test.Models;
using Xunit.Abstractions;
using System.Net.Http;
using Xunit;
using Childcare.Api.Integration.Test.TestUtilities;
using Childcare.Api.ViewModels.Users;
using Childcare.Api.ViewModels;
using System.Net.Http.Json;
using FluentAssertions;

namespace Childcare.API.Integration.Test.Controllers
{
    [Collection("Integration")]
    public class UserControllerTests
    {
        private readonly HttpClient _httpClient;
        private readonly ITestOutputHelper _testOutputHelper;

        public UserControllerTests(ITestOutputHelper testOutputHelper, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async Task GetAll_WhenUsersPresent_ReturnsOk()
        {
            var response = await _httpClient.GetAsync("/users/");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var value = await response.Content.ReadAsStringAsync();
            _testOutputHelper.WriteLine(value.VerifyDeSerialization<UserViewModel[]>());
        }

        [Fact]
        public async Task Create_WhenNewUserDetailsInvalid_ReturnsValidationErrors()
        {
            CreateUserViewModel newUser = new CreateUserViewModel();

            var response = await _httpClient.PostAsJsonAsync("/users/", newUser);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var value = await response.Content.ReadAsStringAsync();

            var result = value.VerifyDeSerialize<ValidationModel>();
            result.Errors.CheckIfErrorPresent("Name", "Name must be not null");

            _testOutputHelper.WriteLine(value);
        }
    }
}
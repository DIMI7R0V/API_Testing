using Final_APITesting.Framework.Models;
using FluentAssertions;
using Newtonsoft.Json;
using System.Text;

namespace Final_APITesting.Tests
{
    [TestFixture]
    public class UsersTests : TestBase
    {
        [Test]
        public async Task GetUsers()
        {
            var response = await Client.GetAsync("users");

            //Example fluentassertion
            response.StatusCode.ToString().Should().Be("OK");


            string responseData = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<UserResponse>>(responseData);

            users.Should().NotBeNull();
            users.Count().Should().Be(10);

        }
        //
        [Test]
        public async Task CreateUser()
        {
            var newUser = new
            {
                name = $"{System.Guid.NewGuid()}",
                email = $"{System.Guid.NewGuid()}@gmail.com",
                gender = "male",
                status = "active"
            };

            var jsonBody = new StringContent(JsonConvert.SerializeObject(newUser), Encoding.UTF8, "application/json");

            var response = await Client.PostAsync("users", jsonBody);

            response.StatusCode.ToString().Should().Be("Created");

            var responseData = await response.Content.ReadAsStringAsync();
            var createdUser = JsonConvert.DeserializeObject<UserResponse>(responseData);
        }
    }
}

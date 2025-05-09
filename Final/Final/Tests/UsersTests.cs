using Final.Core.Models;
using Newtonsoft.Json;

namespace Final.Tests
{
    public class UsersTests : TestBase
    {
        [Test]
        public async Task GetUsers()
        {
            var response = await Client.GetAsync("users");
            string responseData = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<UserResponse>>(responseData);

        }


    }
}

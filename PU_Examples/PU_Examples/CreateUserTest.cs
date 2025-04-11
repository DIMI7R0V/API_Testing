using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace PU_Examples
{

    [TestFixture]
    public class CreateUserTest
    {
        private readonly string _accessToken = "ae2a96fdbfbcfa30c945bc87dccfbe953107a544dfced9ae7fc22671c1c042d9"; // смени с реален token
        private HttpClient _client;
        private int _userID;

        [SetUp]
        public void Setup()
        {
            _client = new HttpClient();
            _client.BaseAddress = new System.Uri("https://gorest.co.in/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
        }

        [Test]
        public async Task CreateUser_ShouldReturn201Created()
        {
            // Метод Get all users
            // take the first user from the list
            // get user.ID

            var requestBody = new
            {
                name = "Tenali Ramakrishna",
                gender = "male",
                email = $"tenali.ramakrishna.{System.Guid.NewGuid()}@example.com", // уникален email
                status = "active"
            };

            var json = System.Text.Json.JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("public/v2/users", content);
            var responseBody = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserResponse>(responseBody);

            _userID = user.Id;

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created), $"Unexpected response: {responseBody}");
        }

        [Test]
        public async Task UpdateUser_ShoudReturn201Created()
        {
            var requestBody = new
            {
                name = "Tenali Ramakrishna",
            };

            var updateUserJson = System.Text.Json.JsonSerializer.Serialize(requestBody);
            var content = new StringContent(updateUserJson, Encoding.UTF8, "application/json"); //serializer
            var response = await _client.PostAsync($"public/v2/users/{_userID}", content);
        }
    }
}
using EntryPointWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using static EntryPointWebApi.TestProtoBuf;
using static System.Net.Mime.MediaTypeNames;

namespace EntryPointWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly TestProtoBufClient _testProtoBufClient;
        public readonly IConfiguration _configuration;

        public TestController(IHttpClientFactory httpClientFactory,
                              TestProtoBufClient testProtoBufClient,
                              IConfiguration configuration)
        {
            this._httpClientFactory = httpClientFactory;
            this._testProtoBufClient = testProtoBufClient;
            this._configuration = configuration;
        }

        [Route("rest")]
        [HttpGet]
        public async Task<IActionResult> RestSampleCaller()
        {
            var payload = new StringContent(
                                      JsonSerializer.Serialize(new
                                      {
                                          Filter = new
                                          {
                                              City = "blabla",
                                              Id = 1,
                                              Name = "blabla",
                                              Surname = "blabla"
                                          }
                                      }),
                                      Encoding.UTF8,
                                      Application.Json);

            var httpClient = this._httpClientFactory.CreateClient();

            var httpResponseMessage = await httpClient.PostAsync($"{this._configuration.GetValue<string>("Integration:RestApi")}/api/restTest", payload);

            httpResponseMessage.EnsureSuccessStatusCode();

            var content = await httpResponseMessage.Content.ReadAsStringAsync();
            var actualResult = JsonSerializer.Deserialize<RestApiResponse>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return Ok(actualResult);
        }

        [Route("grpc")]
        [HttpGet]
        public async Task<IActionResult> GrpcSampleCaller()
        {
            var response = await this._testProtoBufClient.TestAsync(new TestProtoBufRequest
            {
                Filter = new SearchFilter
                {
                    City = "blabla",
                    Id = 1,
                    Name = "blabla",
                    Surname = "blabla"
                }
            });
            return Ok(response);
        }
    }
}

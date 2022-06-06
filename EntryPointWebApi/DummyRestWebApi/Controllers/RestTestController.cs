using DummyRestWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DummyRestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestTestController : ControllerBase
    {
        public static int count = 0;

        [HttpPost]
        public async Task<RestApiResponse> Post(RestApiRequest request)
        {
            var index = ++count;
            var user1 = new User
            {
                Id = index,
                Name = $"name{index}",
                Surname = $"surname{index}",
                Age = 20,
                Addresses = new List<Address>
                        {
                            new Address
                            {
                                City = $"city{index}",
                                Region = $"region{index}"
                            }
                        }
            };
            index = ++count;
            var user2 = new User
            {
                Id = index,
                Name = $"name{index}",
                Surname = $"surname{index}",
                Age = 20,
                Addresses = new List<Address>
                        {
                            new Address
                            {
                                City = $"city{index}",
                                Region = $"region{index}"
                            }
                        }
            };
            return await Task.FromResult(new RestApiResponse
            {
                Users = new List<User>
                {
                    user1,
                    user2
                }
            });
        }
    }
}

using Grpc.Core;

namespace DummyGrpcService.Services
{
    public class DummyService : TestProtoBuf.TestProtoBufBase
    {
        public static int count = 0;

        public override async Task<TestProtoBufResponse> Test(TestProtoBufRequest request, ServerCallContext context)
        {
            var index = ++count;
            var user1 = new User
            {
                Id = index,
                Name = $"name{index}",
                Surname = $"surname{index}",
                Age = 20
            };
            user1.Adrresses.Add(new Google.Protobuf.Collections.RepeatedField<Address>
                {
                    new Address
                    {
                         City = $"city{index}",
                         Region = $"region{index}"
                    }
                });

            index = ++count;
            var user2 = new User
            {
                Id = index,
                Name = $"name{index}",
                Surname = $"surname{index}",
                Age = 20
            };
            user2.Adrresses.Add(new Google.Protobuf.Collections.RepeatedField<Address>
                {
                    new Address
                    {
                         City = $"city{index}",
                         Region = $"region{index}"
                    }
                });

            var result = new TestProtoBufResponse();
            result.Users.Add(user1);
            result.Users.Add(user2);
            return await Task.FromResult(result);
        } 
    }
}

namespace EntryPointWebApi.Models
{
    public class RestApiResponse
    {
        public List<User> Users { get; set; } = new List<User>();
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();
    } 
    public class Address
    {
        public string City { get; set; }
        public string Region { get; set; }
    }
}

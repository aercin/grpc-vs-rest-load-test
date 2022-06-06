namespace DummyRestWebApi.Models
{
    public class RestApiRequest
    {
        public SearchFilter Filter { get; set; }
    }

    public class SearchFilter
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
    }
}

namespace Quiz.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Store_type { get; set; }
        public string? Status { get; set; }
        public DateTime Created_date { get; set; }
    }
}
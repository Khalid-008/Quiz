namespace Quiz.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public int Store_id { get; set; }
        public string? Skill { get; set; }
        public DateTime Created_date { get; set; }
        public string? Status { get; set; }
    }
}

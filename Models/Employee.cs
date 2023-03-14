using System.ComponentModel.DataAnnotations;

namespace Quiz.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This Field is required")]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "This Field is required")]
        [MaxLength(50)]
        public string? Age { get; set; }
        [Required(ErrorMessage = "This Field is required")]
        [MaxLength(50)]
        public string? Skill { get; set; }
        public DateTime Created_date { get; set; }
        [Required(ErrorMessage = "This Field is required")]
        [MaxLength(50)]
        public string? Status { get; set; }
        [Required(ErrorMessage = "This Field is required")]
        public int Store_id { get; set; }
        public Store? Store { get; set; }
    }
}

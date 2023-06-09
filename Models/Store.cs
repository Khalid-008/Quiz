using System.ComponentModel.DataAnnotations;

namespace Quiz.Models
{
    public class Store
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This Field is required")]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "This Field is required")]
        [MaxLength(100)]
        public string? Address { get; set; }
        [Required(ErrorMessage = "This Field is required")]
        [MaxLength(50)]
        public string? Store_type { get; set; }
        [Required(ErrorMessage = "This Field is required")]
        [MaxLength(50)]
        public string? Status { get; set; }
        public DateTime Created_date { get; set; }
        public ICollection<Employee>? Employee { get; set; }
    }
}
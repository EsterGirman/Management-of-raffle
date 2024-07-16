using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(10)]
        [Required]
        public string Password { get; set; }       
        [MaxLength(20)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(20)]
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Role { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; }
        public string Email { get; set; }
       // public IEnumerable<Purchase> Purchases { get; set; }
    }
}

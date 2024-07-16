using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Donor
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(25)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(10)]
        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }
        [MaxLength(20)]

        public string Email { get; set; }
    }
}

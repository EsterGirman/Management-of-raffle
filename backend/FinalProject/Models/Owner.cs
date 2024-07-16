using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Owner
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [MaxLength(10)]
        [Required]
        public string Phone { get; set; }

        public string Password { get; set; }

    }
}

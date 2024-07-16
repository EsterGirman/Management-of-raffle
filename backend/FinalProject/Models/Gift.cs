using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Gift
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public string Image { get; set; }
        public int DonorId { get; set; }
        public bool IsDrawn { get; set; }
        public Category Category { get; set; }
        public Donor Donor { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Winner
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public int GiftId { get; set; }
        public Gift Gift { get; set; }
    }
}

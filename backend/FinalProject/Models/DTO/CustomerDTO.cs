using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models.DTO
{
    public class CustomerDTO
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

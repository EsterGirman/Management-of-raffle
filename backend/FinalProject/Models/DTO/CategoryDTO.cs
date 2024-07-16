using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}

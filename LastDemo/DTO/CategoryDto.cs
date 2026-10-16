using System.ComponentModel.DataAnnotations;

namespace LastDemo.DTO
{
    public class CategoryDto
    {
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace LastDemo.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required,MinLength(2),MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public List<Product>? Products { get; set; }=new List<Product>();
    }
}

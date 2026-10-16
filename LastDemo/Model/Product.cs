using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LastDemo.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required,MinLength(2),MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required,Range(0.01,1000000)]
        public decimal Price { get; set; }
        [Required,Range(0,1000000)]
        public int StockQuantity {  get; set; }
        [ForeignKey("category")]
        public int CategoryId {  get; set; }
        public Category category { get; set; }
        public List<OrderIteam>? OrderIteams { get; set; }=new List<OrderIteam>();
    }
}

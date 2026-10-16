using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LastDemo.DTO
{
    public class ProductDto
    {
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required, Range(0.01, 1000000)]
        public decimal Price { get; set; }
        [Required, Range(0, 1000000)]
        public int StockQuantity { get; set; }
   
        public int CategoryId { get; set; }
    }
}

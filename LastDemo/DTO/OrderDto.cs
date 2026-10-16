using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LastDemo.DTO
{
    public class OrderDto
    {
        public DateTime OrderDate { get; set; }
      
        public string Status { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        
        public int UserId { get; set; }
        public List< OrderItemProductDto> OrderIteams { get; set; }
    }
}

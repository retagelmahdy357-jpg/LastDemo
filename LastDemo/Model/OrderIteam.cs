using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LastDemo.Model
{
    public class OrderIteam
    {
        [Key]
        public int Id { get; set; }
        [Required,Range(1,1000)]
        public int Quantity {  get; set; }
        [Required,Range(0.01,1000000)]
        public decimal UnitPrice {  get; set; }
        [ForeignKey("order")]
        public int OrderId {  get; set; }
        public Order order { get; set; }
        [ForeignKey("product")]
        public int ProductId {  get; set; }
        public Product? product { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LastDemo.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string Status {  get; set; }
        [Required]
        public decimal TotalAmount {  get; set; }
        [ForeignKey("user")]
        public int UserId {  get; set; }
        public User? user { get; set; }
        public List<OrderIteam>? OrderIteams { get; set; }=new List<OrderIteam>(); 
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace LastDemo.Model
{
  //  Index[typeof(Nam)]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required,MinLength(3),MaxLength(100)]
        public string FullName { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Role { get; set; }
        public List<Order>? Orders { get; set; }= new List<Order>();
        public List<OrderIteam>? Iteams { get; set; } = new List<OrderIteam>();



    }
}

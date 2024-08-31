using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string? Image { get; set; }
        public string? Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int QuantityAvailable { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

    }
}

using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

    }
}

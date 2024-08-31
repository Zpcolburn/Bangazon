using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
    public class Payment
    {
        public int Id { get; set; }
        [Required]
        public int Type { get; set; }
        public int CardNumber { get; set; }
        public DateTime ExpireDate { get; set; }
        public int UserId { get; set; }
    }
}

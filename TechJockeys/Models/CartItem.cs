using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TechJockeys.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }

        [Required]
        [DisplayName("Qty")]
        public int Quantity { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [DisplayName("Price per unit")]
        public decimal Price { get; set; }

        [Required]
        public string CustomerId { get; set; }

        // FK
        [Required]
        public int ProductId { get; set; }

        // parent ref
        public Product? Product { get; set; }
    }
}

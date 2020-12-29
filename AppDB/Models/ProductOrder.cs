using System.ComponentModel.DataAnnotations;

namespace Technics.com.Models
{
    public class ProductOrder
    {
        public long Id { get; set; }

        public Order Order { get; set; }

        public long OrderId { get; set; }

        public long ProductId { get; set; }

        public Product Product { get; set; }

        [Required]
        public int Count { get; set; }

    }
}

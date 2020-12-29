using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Technics.com.Models
{
    public class Product
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int AmountInStock { get; set; }

        public List<Photo> Imgs { get; set; }

        public List<Comment> Comments { get; set; }

        [Required]
        [MaxLength(300)]
        public string ShortDescription { get; set; }

        [Required]
        [MaxLength(500)]
        public string LongDescription { get; set; }

        [Required]
        public int Price { get; set; }

        //[Default(1)]
        public long CategoryId { get; set; }

        public virtual Category Category { get; set; }

        //[Default(1)]
        public long ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public virtual List<ProductOrder> ProductsOrders { get; set; }
    }
}

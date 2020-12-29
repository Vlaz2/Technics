using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Technics.com.Models
{
    public class Order
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public DateTime OrderTime { get; set; }

        public List<ProductOrder> ProductsOrders {get;set;}

        public bool ConfirmOrder { get; set; }

        public bool Paid { get; set; }

        public bool Delivered { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        [MaxLength(50)]
        public string ToTown { get; set; }

        [Required]
        public int PostCode { get; set; }

        public long AttendantAdminId { get; set; }
    }
}

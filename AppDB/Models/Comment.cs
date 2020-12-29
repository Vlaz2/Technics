using System;
using System.ComponentModel.DataAnnotations;


namespace Technics.com.Models
{
    public class Comment
    {
        public long Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        [MaxLength(300)]
        public string Message { get; set; }

        public long ProductId { get; set; }

        public Product Product { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }
    }
}

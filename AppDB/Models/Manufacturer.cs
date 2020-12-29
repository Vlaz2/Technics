using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Technics.com.Models
{
    public class Manufacturer
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<Product> Products { get; set; }

    }
}

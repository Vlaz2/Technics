using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Technics.com.Models
{
    public class Category
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }

        public long? ParentCategoryId { get; set; }

        public Category ParentCategory { get; set; }

        public List<Product> Products { get; set; }
    }
}
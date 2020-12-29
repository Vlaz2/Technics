using System.ComponentModel.DataAnnotations;

namespace Technics.com.Models
{
    public class Photo
    {
        public long Id { get; set; }

        public long ProductId { get; set; }

        [Required]
        [MaxLength(400)]
        public string ImgUrl { get; set; }

    }
}

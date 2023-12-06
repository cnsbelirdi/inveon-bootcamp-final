using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCard.API.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Labels { get; set; }
        public string Category { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1, 1000)]
        public double Price { get; set; }
        public string Img { get; set; }

    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductService.API.Models
{
    public class ColorOption
    {
        [Key]
        [JsonIgnore]
        public int ColorOptionId { get; set; }
        public string Color { get; set; }

        public string Image { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("ProductId")]
        [JsonIgnore]
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
    }
}

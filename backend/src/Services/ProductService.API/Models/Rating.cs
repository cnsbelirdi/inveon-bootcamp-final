using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProductService.API.Models
{
    public class Rating
    {
        [Key]
        [JsonIgnore]
        public int RatingId { get; set; }
        public double Rate { get; set; }
        public int Count { get; set; }
        [JsonIgnore]
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }
    }

}

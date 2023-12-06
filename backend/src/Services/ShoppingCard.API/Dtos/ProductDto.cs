using System.ComponentModel.DataAnnotations;

namespace ShoppingCard.API.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Labels { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Img { get; set; }
    }
}

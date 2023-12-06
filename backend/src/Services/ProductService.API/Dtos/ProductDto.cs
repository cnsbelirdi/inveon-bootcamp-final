using ProductService.API.Models;
using ProductService.API.Utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.API.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Labels { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public string Hover_img { get; set; }
        public Rating Rating { get; set; }
        public ICollection<ColorOption> Colors { get; set; }
    }
}

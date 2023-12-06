using Microsoft.EntityFrameworkCore;
using ProductService.API.Models;
using ProductService.API.Utilities;

namespace ProductService.API.Context
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<ColorOption> ColorOptions { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Labels = ProductLabel.Trending,
                Category = ProductCategory.Fashion,
                Img = "product1.png",
                Hover_Img = "product10.png",
                Name = "Green Dress For Woman",
                Price = 38,
                Description = @"It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. 
The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters.",
            });
            modelBuilder.Entity<Rating>().HasData(
                new Rating
                {
                    RatingId = 1,
                    Rate = 3.9,
                    Count = 30,
                    ProductId = 1,
                }
            );
            modelBuilder.Entity<ColorOption>().HasData(
                new ColorOption
                {
                    ColorOptionId = 1,
                    Color = "green",
                    Image = "product8.png",
                    Quantity = 1,
                    ProductId = 1
                },
                new ColorOption
                {
                    ColorOptionId = 2,
                    Color = "red",
                    Image = "product9.png",
                    Quantity = 1,
                    ProductId = 1
                },
                new ColorOption
                {
                    ColorOptionId = 3,
                    Color = "blue",
                    Image = "product7.png",
                    Quantity = 1,
                    ProductId = 1
                }
            );
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Labels = ProductLabel.Discount45Percent,
                Category = ProductCategory.Fashion,
                Img = "product2.png",
                Hover_Img = "product9.png",
                Name = "T-Shirt For Men",
                Price = 72,
                Description = @"Vivamus suscipit tortor eget felis porttitor volutpat. Lorem ipsum dolor sit amet, consectetur adipiscing elit.
Proin eget tortor risus. Nulla porttitor accumsan tincidunt. Pellentesque in ipsum ProductId orci porta dapibus.",
            });
            modelBuilder.Entity<Rating>().HasData(
                new Rating
                {
                    RatingId = 2,
                    Rate = 3.3,
                    Count = 80,
                    ProductId = 2,
                }
            );
            modelBuilder.Entity<ColorOption>().HasData(
                new ColorOption
                {
                    ColorOptionId = 4,
                    Color = "green",
                    Image = "product6.png",
                    Quantity = 1,
                    ProductId = 2
                },
                new ColorOption
                {
                    ColorOptionId = 5,
                    Color = "red",
                    Image = "product10.png",
                    Quantity = 1,
                    ProductId = 2
                },
                new ColorOption
                {
                    ColorOptionId = 6,
                    Color = "blue",
                    Image = "img5",
                    Quantity = 1,
                    ProductId = 2
                }
            );
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Labels = ProductLabel.Discount50Percent,
                Category = ProductCategory.Fashion,
                Img = "product3.png",
                Hover_Img = "product7.png",
                Name = "V-Neck Dress",
                Price = 34,
                Description = @"Praesent sapien massa, convallis a pellentesque nec, egestas non nisi. Vestibulum ante ipsum primis in 
faucibus orci luctus et ultrices posuere cubilia Curae;",
            });
            modelBuilder.Entity<Rating>().HasData(
                new Rating
                {
                    RatingId = 3,
                    Rate = 4.9,
                    Count = 156,
                    ProductId = 3,
                }
            );
            modelBuilder.Entity<ColorOption>().HasData(
                new ColorOption
                {
                    ColorOptionId = 7,
                    Color = "green",
                    Image = "product6.png",
                    Quantity = 1,
                    ProductId = 3
                },
                new ColorOption
                {
                    ColorOptionId = 8,
                    Color = "red",
                    Image = "product7.png",
                    Quantity = 1,
                    ProductId = 3
                },
                new ColorOption
                {
                    ColorOptionId = 9,
                    Color = "blue",
                    Image = "product8.png",
                    Quantity = 1,
                    ProductId = 3
                }
            );
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Labels = ProductLabel.Hot,
                Category = ProductCategory.Fashion,
                Img = "product4.png",
                Hover_Img = "product6.png",
                Name = "Maxi Dress",
                Price = 43,
                Description = @"Donec velit neque, auctor sit amet aliquam vel, ullamcorper sit amet ligula. Vestibulum ac diam sit 
amet quam vehicula elementum sed sit amet dui. Quisque velit nisi, pretium ut lacinia in, elementum ProductId enim.",
            });
            modelBuilder.Entity<Rating>().HasData(
                new Rating
                {
                    RatingId = 4,
                    Rate = 1.9,
                    Count = 190,
                    ProductId = 4,
                }
            );
            modelBuilder.Entity<ColorOption>().HasData(
                new ColorOption
                {
                    ColorOptionId = 10,
                    Color = "green",
                    Image = "product3.png",
                    Quantity = 1,
                    ProductId = 4
                },
                new ColorOption
                {
                    ColorOptionId = 11,
                    Color = "red",
                    Image = "product9.png",
                    Quantity = 1,
                    ProductId = 4
                },
                new ColorOption
                {
                    ColorOptionId = 12,
                    Color = "blue",
                    Image = "product5.png",
                    Quantity = 1,
                    ProductId = 4
                }
            );
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 5,
                Labels = ProductLabel.Upcoming,
                Category = ProductCategory.Fashion,
                Img = "product5.png",
                Hover_Img = "product1.png",
                Name = "Fit-Flare Dress",
                Price = 52,
                Description = @"Donec sollicitudin molestie malesuada. Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
Vivamus suscipit tortor eget felis porttitor volutpat. Nulla quis lorem ut libero malesuada feugiat.",
            });
            modelBuilder.Entity<Rating>().HasData(
                new Rating
                {
                    RatingId = 5,
                    Rate = 3.6,
                    Count = 20,
                    ProductId = 5,
                }
            );
            modelBuilder.Entity<ColorOption>().HasData(
                new ColorOption
                {
                    ColorOptionId = 13,
                    Color = "green",
                    Image = "product10.png",
                    Quantity = 1,
                    ProductId = 5
                },
                new ColorOption
                {
                    ColorOptionId = 14,
                    Color = "red",
                    Image = "product9.png",
                    Quantity = 1,
                    ProductId = 5
                },
                new ColorOption
                {
                    ColorOptionId = 15,
                    Color = "blue",
                    Image = "product2.png",
                    Quantity = 1,
                    ProductId = 5
                }
            );
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 6,
                Labels = ProductLabel.Upcoming,
                Category = ProductCategory.Fashion,
                Img = "product6.png",
                Hover_Img = "product4.png",
                Name = "Midi Dress",
                Price = 14,
                Description = @"Nulla quis lorem ut libero malesuada feugiat. Quisque velit nisi, pretium ut lacinia in, elementum ProductId enim. 
Curabitur non nulla sit amet nisl tempus convallis quis ac lectus. Donec sollicitudin molestie malesuada",
            });
            modelBuilder.Entity<Rating>().HasData(
                new Rating
                {
                    RatingId = 6,
                    Rate = 3.9,
                    Count = 120,
                    ProductId = 6,
                }
            );
            modelBuilder.Entity<ColorOption>().HasData(
                new ColorOption
                {
                    ColorOptionId = 16,
                    Color = "green",
                    Image = "product7.png",
                    Quantity = 1,
                    ProductId = 6
                },
                new ColorOption
                {
                    ColorOptionId = 17,
                    Color = "red",
                    Image = "product8.png",
                    Quantity = 1,
                    ProductId = 6
                },
                new ColorOption
                {
                    ColorOptionId = 18,
                    Color = "blue",
                    Image = "product9.png",
                    Quantity = 1,
                    ProductId = 6
                }
            );
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 7,
                Labels = ProductLabel.Trending,
                Category = ProductCategory.Fashion,
                Img = "product7.png",
                Hover_Img = "product3.png",
                Name = "Tulip Dress",
                Price = 41,
                Description = @"Donec rutrum congue leo eget malesuada. Curabitur arcu erat, accumsan ProductId imperdiet et, porttitor at sem. 
Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque velit nisi, pretium ut lacinia in, elementum ProductId enim.",
            });
            modelBuilder.Entity<Rating>().HasData(
                new Rating
                {
                    RatingId = 7,
                    Rate = 1.9,
                    Count = 10,
                    ProductId = 7,
                }
            );
            modelBuilder.Entity<ColorOption>().HasData(
                new ColorOption
                {
                    ColorOptionId = 19,
                    Color = "green",
                    Image = "product2.png",
                    Quantity = 1,
                    ProductId = 7
                },
                new ColorOption
                {
                    ColorOptionId = 20,
                    Color = "red",
                    Image = "product8.png",
                    Quantity = 1,
                    ProductId = 7
                },
                new ColorOption
                {
                    ColorOptionId = 21,
                    Color = "blue",
                    Image = "img1",
                    Quantity = 1,
                    ProductId = 7
                }
            );
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 8,
                Labels = ProductLabel.BestSelling,
                Category = ProductCategory.Fashion,
                Img = "product8.png",
                Hover_Img = "product2.png",
                Name = "Skater Dress",
                Price = 21,
                Description = @"Nulla quis lorem ut libero malesuada feugiat. Donec sollicitudin molestie malesuada.
Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec rutrum congue leo eget malesuada.",
            });
            modelBuilder.Entity<Rating>().HasData(
                new Rating
                {
                    RatingId = 8,
                    Rate = 2.9,
                    Count = 20,
                    ProductId = 8,
                }
            );
            modelBuilder.Entity<ColorOption>().HasData(
                new ColorOption
                {
                    ColorOptionId = 22,
                    Color = "green",
                    Image = "product9.png",
                    Quantity = 1,
                    ProductId = 8
                },
                new ColorOption
                {
                    ColorOptionId = 23,
                    Color = "red",
                    Image = "product8.png",
                    Quantity = 1,
                    ProductId = 8
                },
                new ColorOption
                {
                    ColorOptionId = 24,
                    Color = "blue",
                    Image = "product10.png",
                    Quantity = 1,
                    ProductId = 8
                }
            );
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 9,
                Labels = ProductLabel.Popular,
                Category = ProductCategory.Fashion,
                Img = "product9.png",
                Hover_Img = "product1.png",
                Name = "Boho Tops for Girls",
                Price = 46,
                Description = @" Curabitur non nulla sit amet nisl tempus convallis quis ac lectus. 
Cras ultricies ligula sed magna dictum porta. Donec sollicitudin molestie malesuada.",
            });
            modelBuilder.Entity<Rating>().HasData(
                new Rating
                {
                    RatingId = 9,
                    Rate = 3.9,
                    Count = 120,
                    ProductId = 9,
                }
            );
            modelBuilder.Entity<ColorOption>().HasData(
                new ColorOption
                {
                    ColorOptionId = 25,
                    Color = "green",
                    Image = "product5.png",
                    Quantity = 1,
                    ProductId = 9
                },
                new ColorOption
                {
                    ColorOptionId = 26,
                    Color = "red",
                    Image = "product6.png",
                    Quantity = 1,
                    ProductId = 9
                },
                new ColorOption
                {
                    ColorOptionId = 27,
                    Color = "blue",
                    Image = "product7.png",
                    Quantity = 1,
                    ProductId = 9
                }
            );

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 10,
                Labels = ProductLabel.TopChoice,
                Category = ProductCategory.Fashion,
                Img = "product10.png",
                Hover_Img = "product3.png",
                Name = "Skater Dress",
                Price = 74,
                Description = @"Praesent sapien massa, convallis a pellentesque nec, egestas non nisi. Donec
rutrum congue leo eget malesuada. Sed porttitor lectus nibh. Proin eget tortor risus. Curabitur aliquet quam ProductId dui posuere blandit. ",
            });
            modelBuilder.Entity<Rating>().HasData(
                new Rating
                {
                    RatingId = 10,
                    Rate = 3.9,
                    Count = 220,
                    ProductId = 10,
                }
            );
            modelBuilder.Entity<ColorOption>().HasData(
                new ColorOption
                {
                    ColorOptionId = 28,
                    Color = "green",
                    Image = "product2.png",
                    Quantity = 1,
                    ProductId = 10
                },
                new ColorOption
                {
                    ColorOptionId = 29,
                    Color = "red",
                    Image = "product3.png",
                    Quantity = 1,
                    ProductId = 10
                },
                new ColorOption
                {
                    ColorOptionId = 30,
                    Color = "blue",
                    Image = "product4.png",
                    Quantity = 1,
                    ProductId = 10
                }
            );

        }

    }
}

using Microsoft.EntityFrameworkCore;
using Bangazon.Models;


public class BangazonDbContext : DbContext
{
    public DbSet<Category> Category { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<User> User { get; set; }

    public BangazonDbContext(DbContextOptions<BangazonDbContext> context) : base(context)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(new Category[]
        {
            new Category 
            {
                Id = 1, 
                CategoryName = "Electronics"
            },

            new Category
            {
                Id = 2,
                CategoryName = "Clothing"
            },
            new Category
            {
                Id = 3,
                CategoryName = "Household Essentials"
            }
        });

        modelBuilder.Entity<Product>().HasData(new Product[]
        {
            // Electronics
            new Product
            {
                Id = 1,
                Image = "https://m.media-amazon.com/images/I/91Hk42lTFaL.jpg",
                Name = "4K Smart TV",
                CategoryId = 1,
                UserId = 1,
                Price = 299.99m,
                Description = "Ultra HD 4K Smart TV with HDR.",
                QuantityAvailable = 15
            },
            new Product
            {
                Id = 2,
                Image = "https://media.musicarts.com/is/image/MMGS7/M07377000000000-00-720x720.jpg",
                Name = "Noise-Canceling Headphones",
                CategoryId = 1,
                UserId = 1,
                Price = 199.99m,
                Description = "Over-ear headphones with noise cancellation.",
                QuantityAvailable = 30
            },
            new Product
            {
                Id = 3,
                Image = "https://image-us.samsung.com/us/smartphones/galaxy-s24/all-gallery/01_E3_TitaniumBlack_Lockup_1600x1200.jpg?$product-details-jpg$",
                Name = "Smartphone",
                CategoryId = 1,
                UserId = 2,
                Price = 499.99m,
                Description = "Latest model smartphone with high resolution camera.",
                QuantityAvailable = 20
            },
            new Product
            {
                Id = 4,
                Image = "https://m.media-amazon.com/images/I/71HESRbyxDL.jpg",
                Name = "Gaming Console",
                CategoryId = 1,
                UserId = 2,
                Price = 399.99m,
                Description = "Next-generation gaming console with 4K support.",
                QuantityAvailable = 10
            },

            // Clothing
            new Product
            {
                Id = 5,
                Image = "https://gearmoose.com/wp-content/uploads/2019/05/filson-leather-short-cruiser-jacket.jpg",
                Name = "Leather Jacket",
                CategoryId = 2,
                UserId = 3,
                Price = 200.00m,
                Description = "Genuine leather jacket with a classic design.",
                QuantityAvailable = 5
            },
            new Product
            {
                Id = 6,
                Image = "https://cdn11.bigcommerce.com/s-lk0gwzb/images/stencil/1280x1280/products/1645/9513/athleticheather-front__83530__24374_8135__17315.1708459759.jpg?c=2",
                Name = "Cotton T-shirt",
                CategoryId = 2,
                UserId = 3,
                Price = 20.00m,
                Description = "Comfortable 100% cotton T-shirt.",
                QuantityAvailable = 50
            },
            new Product
            {
                Id = 7,
                Image = "https://i.etsystatic.com/11147089/r/il/4bc917/3294441088/il_570xN.3294441088_dx4j.jpg",
                Name = "Denim Jeans",
                CategoryId = 2,
                UserId = 4,
                Price = 40.00m,
                Description = "Stylish and durable denim jeans.",
                QuantityAvailable = 25
            },
            new Product
            {
                Id = 8,
                Image = "https://cdn.thewirecutter.com/wp-content/media/2023/09/running-shoes-2048px-5946.jpg?auto=webp&quality=75&width=1024",
                Name = "Running Shoes",
                CategoryId = 2,
                UserId = 4,
                Price = 79.99m,
                Description = "Lightweight running shoes with excellent grip.",
                QuantityAvailable = 40
            },

            // Household Essentials
            new Product
            {
                Id = 9,
                Image = "https://images.thdstatic.com/productImages/c08b33d2-32a5-449a-b0a8-25425d3729b5/svn/dawn-dish-soap-003077209398-fa_600.jpg",
                Name = "Dish Soap",
                CategoryId = 3,
                UserId = 1,
                Price = 10.50m,
                Description = "Effective dish soap for grease removal.",
                QuantityAvailable = 100
            },
            new Product
            {
                Id = 10,
                Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQkW2hEVTJ5yu4V7h1Toy3MA2lZNovOFnz3Sw&s",
                Name = "Paper Towels",
                CategoryId = 3,
                UserId = 1,
                Price = 5.00m,
                Description = "Highly absorbent paper towels.",
                QuantityAvailable = 80
            },
            new Product
            {
                Id = 11,
                Image = "https://images.thdstatic.com/productImages/d31d06e3-b0d3-4edb-a4c0-b599ec2e4de2/svn/gain-laundry-detergents-003700077196-64_600.jpg",
                Name = "Laundry Detergent",
                CategoryId = 3,
                UserId = 2,
                Price = 12.00m,
                Description = "High-efficiency laundry detergent.",
                QuantityAvailable = 60
            },
            new Product
            {
                Id = 12,
                Image = "https://images.thdstatic.com/productImages/e5c920e1-3d7c-431f-ad73-048e3070d5da/svn/simple-green-all-purpose-cleaners-2710001213033-64_1000.jpg",
                Name = "Cleaning Spray",
                CategoryId = 3,
                UserId = 2,
                Price = 7.50m,
                Description = "Multi-surface cleaning spray.",
                QuantityAvailable = 70
            }
        });

        modelBuilder.Entity<User>().HasData(new User[]
{
        new User
        {
            Id = 1,
            FirstName = "Alice",
            LastName = "Smith",
            Email = "alice.smith@example.com",
            Role = true 
        },
        new User
        {
            Id = 2,
            FirstName = "Bob",
            LastName = "Johnson",
            Email = "bob.johnson@example.com",
            Role = false 
        }
});


        modelBuilder.Entity<Order>().HasData(new Order[]
        {
            new Order
            {
                Id =1,
                OrderDate = new DateTime(2024 - 05 - 18 ),
                Total = 749.98m,
                Status = false,
                UserId = 1,
            }
        });

        modelBuilder.Entity<OrderDetails>().HasData(new OrderDetails[]
        {
            new OrderDetails
            {
                Id = 1,
                OrderId = 1,
                ProductId = 1, // 4K Smart TV
                Quantity = 1,
                Price = 299.99m
            },
            new OrderDetails
            {
                Id = 2,
                OrderId = 1,
                ProductId = 2, // Leather Jacket
                Quantity = 1,
                Price = 200.00m
            },
            new OrderDetails
            {
                Id = 3,
                OrderId = 1,
                ProductId = 3, // Cotton T-shirt
                Quantity = 2,
                Price = 40.00m
            },
            new OrderDetails
            {
                Id = 4,
                OrderId = 1,
                ProductId = 5, // Dish Soap
                Quantity = 10,
                Price = 105.00m
            },
            new OrderDetails
            {
                Id = 5,
                OrderId = 1,
                ProductId = 6, // Paper Towels
                Quantity = 5,
                Price = 50.00m
            }
        });
    }
}

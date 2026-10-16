using System.Runtime.CompilerServices;
using LastDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace LastDemo.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) { }
      
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderIteam> OrdersIteams { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AppUser>AppUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne(x => x.category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Order>().HasOne(x => x.user).WithMany(x => x.Orders).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrderIteam>().HasOne(x => x.order).WithMany(x => x.OrderIteams).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrderIteam>().HasOne(x => x.product).WithMany(x => x.OrderIteams).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                FullName = "AhmedHassan",
                Email = "Ahmed@Example.com",
                PasswordHash = "123456M",
                Role = "Customer",

            },
            new User
            {
                Id = 2,
                FullName = "Mona Ali",
                Email = "mona@Example.com",
                PasswordHash = "123456M",
                Role = "Customer",

            },
            new User
            {
                Id = 3,
                FullName = "Store Admin",
                Email = "admin@Example.com",
                PasswordHash = "123456M",
                Role = "Admin",

            }

            );



            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "Electronics",
                Description = "Devises",

            },
            new Category
            {
                Id = 2,
                Name = "Books",
                Description = "Programming Book",

            },
            new Category
            {
                Id = 3,
                Name = "Accsesorries",
                Description = "Cumputer Accsesorries",

            }


            );

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Wirless Mouse",
                Price = 450,
                StockQuantity = 25,
                CategoryId=1





            },
            new Product
            {
                Id = 2,
                Name = "HeadPhones",
                Price = 120000,
                StockQuantity = 12,
                CategoryId=2





            },
             new Product
             {
                 Id = 3,
                 Name = "C++ Fundmental",
                 Price = 350,
                 StockQuantity = 30,
                 CategoryId=3





             }



            );

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 1,
                OrderDate = new DateTime(2026, 10, 01),
                Status = "Completed",
                TotalAmount = 800,
                UserId = 1,

            },
            new Order
            {
                Id = 2,
                OrderDate = new DateTime(2026, 10, 10),
                Status = "Pending",
                TotalAmount = 120000,
                UserId=2


            },
            new Order
            {
                Id = 3,
                OrderDate = new DateTime(2026, 10, 12),
                Status = "Cancelled",
                TotalAmount = 350,
                UserId=3

            }


            );

            modelBuilder.Entity<OrderIteam>().HasData(new OrderIteam
            {
                Id = 1,
                Quantity = 1,
                UnitPrice = 450,
                OrderId=1,
                ProductId=1
            },
            new OrderIteam
            {
                Id = 2,
                Quantity = 1,
                UnitPrice = 350,
                OrderId=2,
                ProductId=2

            },
             new OrderIteam
             {
                 Id = 3,
                 Quantity = 1,
                 UnitPrice = 1200,
                 OrderId=3,
                 ProductId =3
                 
             }


            );



        }
    }
}

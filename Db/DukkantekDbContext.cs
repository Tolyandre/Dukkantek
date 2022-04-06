namespace Dukkantek.Db
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class DukkantekDbContext : DbContext
    {
        public DukkantekDbContext(DbContextOptions<DukkantekDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .Property(e => e.StatusId)
                .HasConversion<int>();

            modelBuilder
                .Entity<ProductStatus>()
                .Property(e => e.Id)
                .HasConversion<int>();

            AddInitialData(modelBuilder);
        }

        private void AddInitialData(ModelBuilder modelBuilder)
        {
            #region ProductStatus

            modelBuilder
                .Entity<ProductStatus>().HasData(
                    Enum.GetValues(typeof(ProductStatusId))
                        .Cast<ProductStatusId>()
                        .Select(x => new ProductStatus()
                        {
                            Id = x,
                            Name = x.ToString()
                        })
                    );

            #endregion

            #region Categoties

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Hobbies",
                },
                new Category
                {
                    Id = 2,
                    Name = "Computers",
                });

            #endregion

            #region Products

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Barcode = "A-0010-B",
                    Name = "Embroidery kit",
                    Description = "The art or pastime of embroidering cloth",
                    Weight = 0.5f,
                    StatusId = ProductStatusId.InStock,
                    CategoryId = 1,
                },
                new Product
                {
                    Barcode = "A-0020-B",
                    Name = "Felt-tip pens",
                    Description = "Felt pen 12 color",
                    Weight = 0.5f,
                    StatusId = ProductStatusId.InStock,
                    CategoryId = 1,
                },
                new Product
                {
                    Barcode = "0123-4567",
                    Name = "Radeon RX 6900 XT",
                    Description = "Truly immersive gaming experiences",
                    Weight = 0.25f,
                    StatusId = ProductStatusId.Damaged,
                    CategoryId = 2,
                },
                new Product
                {
                    Barcode = "ABC-1234",
                    Name = "Monitor AG274UXP",
                    Description = "4K Ultra HD Display For Brilliant Visuals",
                    Weight = 7.5f,
                    StatusId = ProductStatusId.Sold,
                    CategoryId = 2,
                });

            #endregion
        }
    }
}

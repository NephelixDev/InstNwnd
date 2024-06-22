using InstNwnd.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstNwnd.Web.Data.Context
{
    public class InstNwndContext : DbContext
    {
        public InstNwndContext(DbContextOptions<InstNwndContext> options) : base(options)
        {
        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Order_Details> Order_Details { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("Categories", "dbo");
                entity.HasKey(c => c.CategoryID);
                entity.Property(c => c.CategoryID).HasColumnName("CategoryID");
                entity.Property(c => c.CategoryName).IsRequired().HasMaxLength(15);
                entity.Property(c => c.Description).HasColumnType("ntext");
                entity.Property(c => c.Picture).HasColumnType("image");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.ToTable("Customers", "dbo");
                entity.HasKey(c => c.CustomerId);
                entity.Property(c => c.CustomerId).HasMaxLength(5);
                entity.Property(c => c.CompanyName).IsRequired().HasMaxLength(40);
                entity.Property(c => c.ContactName).HasMaxLength(30);
                entity.Property(c => c.ContactTitle).HasMaxLength(30);
                entity.Property(c => c.Address).HasMaxLength(60);
                entity.Property(c => c.City).HasMaxLength(15);
                entity.Property(c => c.Region).HasMaxLength(15);
                entity.Property(c => c.PostalCode).HasMaxLength(10);
                entity.Property(c => c.Country).HasMaxLength(15);
                entity.Property(c => c.Phone).HasMaxLength(24);
                entity.Property(c => c.Fax).HasMaxLength(24);
            });

            modelBuilder.Entity<Order_Details>(entity =>
            {
                entity.ToTable("Order Details", "dbo");
                entity.HasKey(od => new { od.OrderID, od.ProductID }); // Composite key definition
                entity.Property(od => od.UnitPrice).HasColumnType("money");
                entity.Property(od => od.Quantity).IsRequired();
                entity.Property(od => od.Discount).IsRequired();

                entity.HasOne(od => od.Order)
                      .WithMany(o => o.Order_Details)
                      .HasForeignKey(od => od.OrderID);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("Orders", "dbo");
                entity.HasKey(o => o.OrderID);
                entity.Property(o => o.OrderID).HasColumnName("OrderID");
                entity.Property(o => o.CustomerID).HasMaxLength(5);
                entity.Property(o => o.OrderDate).HasColumnType("datetime");
                entity.Property(o => o.RequiredDate).HasColumnType("datetime");
                entity.Property(o => o.ShippedDate).HasColumnType("datetime");
                entity.Property(o => o.Freight).HasColumnType("money");
                entity.Property(o => o.ShipName).HasMaxLength(40);
                entity.Property(o => o.ShipAddress).HasMaxLength(60);
                entity.Property(o => o.ShipCity).HasMaxLength(15);
                entity.Property(o => o.ShipRegion).HasMaxLength(15);
                entity.Property(o => o.ShipPostalCode).HasMaxLength(10);
                entity.Property(o => o.ShipCountry).HasMaxLength(15);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.ToTable("Products", "dbo");
                entity.HasKey(p => p.ProductID);
                entity.Property(p => p.ProductID).HasColumnName("ProductID");
                entity.Property(p => p.ProductName).IsRequired().HasMaxLength(40);
                entity.Property(p => p.QuantityPerUnit).HasMaxLength(20);
                entity.Property(p => p.UnitPrice).HasColumnType("money");
                entity.Property(p => p.UnitsInStock);
                entity.Property(p => p.UnitsOnOrder);
                entity.Property(p => p.ReorderLevel);
            });
        }
    }
}

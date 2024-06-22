using InstNwnd.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstNwnd.Web.Data.Context
{
    public class InstNwndContext : DbContext
    {
        public InstNwndContext(DbContextOptions<InstNwndContext> options) : base(options)
        {
        }

        public DbSet<Employees> Employees { get; set; }
        public DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la entidad Employees
            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeID);

                entity.Property(e => e.FirstName).HasMaxLength(20).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(20).IsRequired();
                entity.Property(e => e.Title).HasMaxLength(60);
                entity.Property(e => e.Address).HasMaxLength(60);
                entity.Property(e => e.City).HasMaxLength(15);
                entity.Property(e => e.Region).HasMaxLength(15);
                entity.Property(e => e.PostalCode).HasMaxLength(10);
                entity.Property(e => e.Country).HasMaxLength(15);

            });

            // Configuración de la entidad Orders
            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderID);

                entity.Property(e => e.OrderDate).IsRequired();
                entity.Property(e => e.RequiredDate).IsRequired(false);
                entity.Property(e => e.ShippedDate).IsRequired(false);
                entity.Property(e => e.ShipAddress).HasMaxLength(60);
                entity.Property(e => e.ShipCity).HasMaxLength(15);
                entity.Property(e => e.ShipRegion).HasMaxLength(15);
                entity.Property(e => e.ShipPostalCode).HasMaxLength(10);
                entity.Property(e => e.ShipCountry).HasMaxLength(15);

                entity.HasOne(o => o.Employee)
                      .WithMany(e => e.Orders)
                      .HasForeignKey(o => o.EmployeeID);

            });

            // Configuración adicional si es necesario
        }
    }
}

using Microsoft.EntityFrameworkCore;
using InstNwnd.Web.Data.Entities;

namespace InstNwnd.Web.Data.Context
{
    public class InstNwndContext : DbContext
    {
        public InstNwndContext(DbContextOptions<InstNwndContext> options) : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Shippers> Shippers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Shippers>(entity =>
            {
                entity.ToTable("Shippers", "dbo");
                entity.HasKey(e => e.ShipperID);
                entity.Property(e => e.ShipperID).ValueGeneratedOnAdd();

                // Configuraciones específicas de las propiedades
                entity.Property(e => e.CompanyName).IsRequired().HasMaxLength(40);
                entity.Property(e => e.Phone).HasMaxLength(24);

                // Puedes agregar más configuraciones según sea necesario
            });

            // Puedes agregar más configuraciones para otras entidades aquí
        }
    }
}

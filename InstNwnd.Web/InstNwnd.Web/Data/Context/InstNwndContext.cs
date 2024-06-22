using InstNwnd.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstNwnd.Web.Data.Context
{
    public class InstNwndContext : DbContext
    {
        public InstNwndContext(DbContextOptions<InstNwndContext> options) : base(options)
        {
            Region = Set<Region>();
            Territories = Set<Territories>();
        }

        public DbSet<Region> Region { get; set; }
        public DbSet<Territories> Territories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Region>()
                .ToTable("Region", "dbo")
                .HasKey(r => r.RegionID);

            modelBuilder.Entity<Region>()
               .Property(r => r.RegionID)
               .ValueGeneratedOnAdd();

            modelBuilder.Entity<Territories>()
                .ToTable("Territories", "dbo")
                .HasKey(t => t.TerritoryID);

            modelBuilder.Entity<Territories>()
                .HasOne<Region>()
                .WithMany()
                .HasForeignKey(t => t.RegionID);
        }
    }
}

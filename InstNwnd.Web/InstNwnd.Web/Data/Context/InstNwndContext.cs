using InstNwnd.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace InstNwnd.Web.Data.Context
{
    public class InstNwndContext : DbContext
    {
        public InstNwndContext(DbContextOptions<InstNwndContext> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Shippers> Shippers { get; set; }
    }
}

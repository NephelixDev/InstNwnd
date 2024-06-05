using Microsoft.EntityFrameworkCore;
using InstNwnd.Web.Data.Entities;

namespace InstNwnd.Web.Data.Context
{
    public class InstNwndContext : DbContext 
    {
        #region "Constructor"
        public InstNwndContext(DbContextOptions<InstNwndContext> options) : base(options)
        {
        }
        #endregion

        #region "DbSet's"
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Order_Details> Order_Details { get; set; }
        #endregion
    }
}

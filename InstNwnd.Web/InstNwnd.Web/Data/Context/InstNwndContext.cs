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
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Orders> Orders { get; set; }
        
        #endregion

    }
}

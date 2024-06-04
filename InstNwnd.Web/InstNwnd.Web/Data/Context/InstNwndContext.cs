using InstNwnd.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
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
        public DbSet<Region> Region { get; set; }
        public DbSet<Territories> Territories { get; set; }
        #endregion
    }

}


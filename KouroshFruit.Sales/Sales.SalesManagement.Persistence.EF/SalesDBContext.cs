using Framework.Persistence.EF;
using Microsoft.EntityFrameworkCore;

namespace Sales.SalesManagement.Persistence.EF
{
    public class SalesDBContext : DbContextBase
    {
        public SalesDBContext() : base("Server=192.168.10.20;Initial Catalog=KF_Sales;User ID=sa;Password=123")
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}

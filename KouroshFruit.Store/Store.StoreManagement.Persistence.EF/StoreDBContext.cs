using Framework.Persistence.EF;
using Microsoft.EntityFrameworkCore;

namespace Store.StoreManagement.Persistence.EF
{
    public class StoreDBContext : DbContextBase
    {
        public StoreDBContext() : base("Server=192.168.10.20;Initial Catalog=KF_Store;User ID=sa;Password=123")
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
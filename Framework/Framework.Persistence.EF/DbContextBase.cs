using Framework.Core.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Framework.Persistence.EF
{
    public abstract class DbContextBase : DbContext, IDbContext
    {
        protected DbContextBase(string connectionString) : base(GetOptions(connectionString))
        {
        }

        public void RejectChanges()
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
    }
}
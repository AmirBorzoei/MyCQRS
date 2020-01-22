namespace Framework.Core.Persistence
{
    public interface IDbContext
    {
        int SaveChanges();

        void RejectChanges();
    }
}

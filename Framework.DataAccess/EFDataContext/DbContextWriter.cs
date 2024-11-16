using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace Framework.DataAccess.EFDataContext
{
    public class DbContextWriter : DbContextReader, IDbContextWriter
    {
        public IEfCtxInternal EfCtx { get; set; }

        public bool IsDisposed => true;

        public DbContextWriter(IEfCtxInternal efCtx) : base(efCtx)
        {
            EfCtx = efCtx;
        }

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return EfCtx.Entry<TEntity>(entity);
        }

        public int SaveChanges()
        {
            var count = EfCtx.SaveChangesInternal();
            return count;
        }

        public void Dispose()
        {

        }
    }

    interface IDbContextWriter : IEfCtx
    {
        IEfCtxInternal EfCtx { get; set; }
        int SaveChanges();
    }

}

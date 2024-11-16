using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.DataAccess.EFDataContext
{
    public class DbContextReader : IDbContextReader
    {
        public IEfCtxInternal EfCtx { get; set; }

        public bool IsDisposed => true;

        public DbContextReader(IEfCtxInternal efCtx)
        {
            EfCtx = efCtx;
        }

       public  DbSet<TEntity> DbSet<TEntity>() where TEntity : class
        {
            return EfCtx.DbSet<TEntity>();
        }

        public void Dispose()
        {
            
        }
    }

    public interface IDbContextReader : IEfCtx
    {
        DbSet<TEntity> DbSet<TEntity>() where TEntity : class;
    }
}

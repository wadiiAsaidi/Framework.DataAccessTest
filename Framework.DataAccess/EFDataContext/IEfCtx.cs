using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.DataAccess.EFDataContext
{
    public interface IEfCtx : System.IDisposable
    {
        bool IsDisposed
        {
            get;
        }
    }
    public interface IEfCtxInternal : IEfCtx
    {
        DbSet<TEntity> DbSet<TEntity>() where TEntity : class;
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        int SaveChangesInternal();
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.DataAccess.EFDataContext
{
    public abstract class UnitOfWorkBase : IUnitOfWorkBase, IUnitOfWorkBaseInternal
    {
        public DbContextWriter _CurrentEFCtxInternal => GetCurrentEFCtxInternal();
        public DbContextWriter CurrentEFCtxInternal { get; set; }
        public DbContextWriter GetCurrentEFCtxInternal()
        {
            return CurrentEFCtxInternal;
        }
        public void SetCurrentEFCtxInternal(DbContextWriter eFCtx)
        {
            if (_CurrentEFCtxInternal == null)
            {
                CurrentEFCtxInternal = eFCtx;
            }
        }
        public void ClearCurrentEFCtxInternal()
        {
            if (_CurrentEFCtxInternal != null)
            {
                CurrentEFCtxInternal = null;
            }
        }
        public DbContextReader CreatDbContextReader(AccessType reader)
        {
            IEfCtxInternal efCtx;
            if (CurrentEFCtxInternal != null)
            {
                efCtx = CurrentEFCtxInternal.EfCtx;
                return new DbContextReader(efCtx);
            }

            efCtx = (IEfCtxInternal)InitialContext(reader);
            return new DbContextReader(efCtx);
        }
        public DbContextWriter CreatDbContextWriter(AccessType writer)
        {
            if (_CurrentEFCtxInternal != null)
            {
                return _CurrentEFCtxInternal;
            }
            else
            {
                IEfCtxInternal efCtx = (IEfCtxInternal)InitialContext(writer);
                var dbCtxWriter = new DbContextWriter(efCtx);
                SetCurrentEFCtxInternal(dbCtxWriter);
                return dbCtxWriter;
            }
        }

        public IEfCtx InitialContext(AccessType accessType)
        {
            return OnInitialize(accessType);
        }
        public abstract IEfCtx OnInitialize(AccessType accessType);

        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    ClearCurrentEFCtxInternal();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~UnitOfWorkBase()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public int Commit()
        {
            if (CurrentEFCtxInternal == null)
            {
                throw new InvalidOperationException();
            }

            var count = InternamCommit(this);
            return count;
        }

        internal int InternamCommit(IUnitOfWorkBaseInternal unitOfWorkBase)
        {
            return unitOfWorkBase.CurrentEFCtxInternal.SaveChanges();
        }
    }
}

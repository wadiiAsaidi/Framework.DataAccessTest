using System;
using System.Reflection;
using Framework.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace Framework.DataAccess.EFDataContext
{
    public abstract class BbContextBase : DbContext, IEfCtxInternal
    {

        public BbContextBase(string connectionString, ManageEFLifeCycle eFLifeCycle) : base(DatabaseProvider.Instance.AlterConnectionString(eFLifeCycle, connectionString))
        {
            InitializeDbContext();
        }

        private void InitializeDbContext()
        {
            // we can here disable stateManage in EF and we can track manualy the state of entity
        }

        public DbSet<TEntity> DbSet<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Entry(entity);
        }

        public void AddEntityMapping(TypeInfo typeInfo, ModelBuilder modelBuilder)
        {
            var isNotGenericTypeAndIsSubclassEntityMapping =
                !typeInfo.ContainsGenericParameters
                && typeInfo.IsSubclassOf(typeof(IEntityMapping));

            if (isNotGenericTypeAndIsSubclassEntityMapping)
            {
                (Activator.CreateInstance(typeInfo)
                    as IEntityMapping
                ).AddEntityMapping(modelBuilder);
            }
        }

        public virtual int SaveChangesInternal()
        {
            return this.SaveChanges();
        }
        public bool IsDisposed => disposedValue;

        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~BbContextBase()
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
    }

    public class DataBaseInitializer
    {
        public bool IsDataBaseAlreadyExist { get; set; }
        public DataBaseInitializer(bool isDataBaseAlreadyExist)
        {
            IsDataBaseAlreadyExist = isDataBaseAlreadyExist;
        }

        protected void DataBaseExist()
        {
            if (!IsDataBaseAlreadyExist)
            {
                throw new InvalidOperationException("DataBase dos't exist");
            }

        }
    }
}

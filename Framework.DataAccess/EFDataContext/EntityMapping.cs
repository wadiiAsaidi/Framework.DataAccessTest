using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Framework.DataAccess.EFDataContext
{
    

    public interface IEntityMapping
    {
        void AddEntityMapping(ModelBuilder modelBuilder);
    }
    public interface IEntityMapping<TEntity> : IEntityMapping,IEntityTypeConfiguration<TEntity> where TEntity : Framework.Entity.Entity.Entitybase
    {
    }

    public abstract class EntityTypeMappingBase<TEntity> : IEntityMapping<TEntity> where TEntity : Framework.Entity.Entity.Entitybase
    {
        public abstract void AddEntityMapping(ModelBuilder modelBuilder);
        public abstract void Configure(EntityTypeBuilder<TEntity> builder);
        public abstract void PreConfigure(EntityTypeBuilder<TEntity> builder);
    }

    public abstract class EntityMapping<TEntity> : EntityTypeMappingBase<TEntity> where TEntity : Framework.Entity.Entity.Entitybase
    {
        
        public override void AddEntityMapping(ModelBuilder modelBuilder)
        {
             modelBuilder.ApplyConfiguration(this);
        }
        
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            PreConfigure(builder);
            OnConfigure(builder);
        }
        private static IMutableEntityType EntityType { get; set; }
        public abstract void OnConfigure(EntityTypeBuilder<TEntity> builder);
        public override void PreConfigure(EntityTypeBuilder<TEntity> builder)
        {
            //Property(i => i.Id).HasColumnName("Id");
        }
    }

   
}

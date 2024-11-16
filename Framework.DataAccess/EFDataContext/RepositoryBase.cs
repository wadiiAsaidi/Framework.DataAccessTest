using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Framework.DataAccess.BuildingQuery;
using Framework.Entity.Entity;

namespace Framework.DataAccess.EFDataContext
{
    public partial class RepositoryBase<TEntity> where TEntity : Entitybase, new()
    {
        private readonly IUnitOfWorkBase _UnitOfWorkBase;
        public RepositoryBase(IUnitOfWorkBase unitOfWorkBase)
        {
            _UnitOfWorkBase = unitOfWorkBase;
        }

        public IList<TEntity> GetAll()
        {
            var data = new List<TEntity>();

            using (var context = _UnitOfWorkBase.CreatDbContextReader(AccessType.SimpleReade))
            {
                //context.DbSet<TEntity>().Include(navigationPropertyPath);
                data = context.DbSet<TEntity>().ToList();
            }

            return data;
        }

        public IList<TEntity> GetList
            (
             FilterExpression<TEntity> filterExpression,
             IncludeExpression<TEntity> IncludeExpression
            )
        
        {

            var data = new List<TEntity>();
            using (var context = _UnitOfWorkBase.CreatDbContextReader(AccessType.SimpleReade))
            {
                var entity = context.DbSet<TEntity>();
                data = entity.ToList();
                if (filterExpression.Expression != null)
                {
                    var filterEntity = entity.Where(filterExpression.Expression);
                    data = filterEntity.ToList();
                    if (IncludeExpression.Includes != null && IncludeExpression.Includes.Any())
                    {
                        foreach (var include in IncludeExpression.Includes)
                        {
                            var includeEntity = filterEntity.Include(include);
                            data = includeEntity.ToList();
                            if (IncludeExpression.ThenInclude != null)
                            {
                                var thenIncludeEntity = includeEntity.ThenInclude(IncludeExpression.ThenInclude);
                                data = thenIncludeEntity.ToList();
                            }
                        }
                    }
                }

            }
            data = data.Skip(filterExpression.Skip).Take(filterExpression.Take).ToList();
            return data;
        }

        public TEntity Add(TEntity entity)
        {
            using (var context = _UnitOfWorkBase.CreatDbContextWriter(AccessType.SimpleReade))
            {
                var newEntity = context.Entry(entity)/*.Property(navigationPropertyPath);*/;
                context.DbSet<TEntity>().Add(entity);
                //if (newEntity != null && newEntity.IsModified)
                //{

                //}
                //var entityState = newEntity.State;
            }

            return entity;
        }

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            using (var context = _UnitOfWorkBase.CreatDbContextWriter(AccessType.SimpleReade))
            {
                context.DbSet<TEntity>().AddRange(entities);
            }

            return entities;
        }
        public TEntity Update(TEntity entity)
        {
            using (var context = _UnitOfWorkBase.CreatDbContextWriter(AccessType.SimpleReade))
            {
                context.DbSet<TEntity>().Update(entity);
            }

            return entity;
        }

        public void Delete(TEntity entity)
        {
            using (var context = _UnitOfWorkBase.CreatDbContextWriter(AccessType.SimpleReade))
            {
                context.DbSet<TEntity>().Remove(entity);
            }
        }
    }
}

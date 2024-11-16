using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Framework.DataAccess.BuildingQuery
{
    public class IncludeExpression<TEntity>
    {
        public List<Expression<Func<TEntity, object>>> Includes = new List<Expression<Func<TEntity, object>>>();
        public Expression<Func<object, object>> ThenInclude { get; set; }
    }
}

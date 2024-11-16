using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Framework.DataAccess.BuildingQuery
{
    public class FilterExpression<TEntity>
    {
        public Expression<Func<TEntity, bool>> Expression { get; set; }
        public int Skip = 0;
        public int Take = 1000;
    }
}

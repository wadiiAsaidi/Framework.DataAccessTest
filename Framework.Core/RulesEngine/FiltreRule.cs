using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Framework.Core.RulesEngine
{
    internal abstract  class FiltreRule<TInput, TEntity> : Rule<TInput, Expression<Func<TEntity, bool>>>
    {
        
    }
    
    internal abstract  class FiltreRule<TEntity> : FiltreRule<TEntity, TEntity>
    {
        
    }
}

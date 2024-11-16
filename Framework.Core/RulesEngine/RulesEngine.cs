using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.RulesEngine
{
    public interface IRuleEngine
    {
        IMultipleRunResult<TOut> Run<TIn, TOut>(IRuleSet<TIn, TOut> ruleSet);
        IMultipleRunResult<TOut> Run<TIn, TOut>(IRuleSet<TIn, TOut> ruleSet, TIn traget, Action<IRunResult<TOut>> evaluatedCallbackAction = null);
        IEnumerable<IMultipleRunResult<TOut>> Run<TIn, TOut>(IRuleSet<TIn, TOut> ruleSet, IEnumerable<TIn> target);
    }
    public class RuleEngine : IRuleEngine
    {
        public IMultipleRunResult<TOut> Run<TIn, TOut>(IRuleSet<TIn, TOut> ruleSet)
        {
            return Run(ruleSet, default(TIn));
        }

        public IMultipleRunResult<TOut> Run<TIn, TOut>(IRuleSet<TIn, TOut> ruleSet, TIn traget, Action<IRunResult<TOut>> evaluatedCallbackAction = null)
        {
            return (IMultipleRunResult<TOut>)ruleSet.Run(traget, evaluatedCallbackAction);
        }

        public IEnumerable<IMultipleRunResult<TOut>> Run<TIn, TOut>(IRuleSet<TIn, TOut> ruleSet, IEnumerable<TIn> target)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.RulesEngine
{

    public interface IRule
    {
    }
    public abstract class Rule<TIn, TOut> : Activity<TIn, TOut>
    {

        public override sealed IRunResult<TOut> Run(TIn target, Action<IRunResult<TOut>> evaluatedCallbackAction = null)
        {
            var isMatched = this.IsMatched(target);
            Exception exception = null;
            var result = default(TOut);
            try
            {
                if (!isMatched.HasValue || isMatched.Value)
                    result = OnRun(target);

            }
            catch (Exception ex)
            {
                exception = ex;
            }

            return new SingleResult<TOut>()
            {
                IsMatched = isMatched.HasValue ? isMatched.Value : bool.Parse(result.ToString()),
                Rule = this,
                Result = result,
            };
        }


    }
}

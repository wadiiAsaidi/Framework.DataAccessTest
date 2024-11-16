using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.RulesEngine
{
    public interface IRuleRunDefinition<TIn, TOut>
    {
        IActivity<TIn, TOut> Rule { get; set; }
        bool Break { get; set; }
        bool BreakOnMatched { get; set; }
    }

    public class RuleRunDefinition<TIn, TOut> : IRuleRunDefinition<TIn, TOut>
    {
        public RuleRunDefinition()
        {
            BreakOnMatched = true;
        }
        public IActivity<TIn, TOut> Rule { get; set; }
        public bool Break { get; set; }
        public bool BreakOnMatched { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.RulesEngine
{
    public interface IActivity<in TIn, out TOut> : IActivity
    {
        public IRunResult<TOut> Run(TIn input, Action<IRunResult<TOut>> evaluatedCallbackAction = null);
        public TOut OnRun(TIn input);
    }
    
    public interface IActivity
    {
        public string Titel { get; set; }
        public string Discription { get; set; }
    }
    
    public abstract class Activity<TIn, TOut> : IActivity<TIn, TOut>
    {
        public string Titel { get; set; }
        public string Discription { get; set; }

        public virtual bool? IsMatched(TIn target)
        {
            return null;
        }
        public abstract IRunResult<TOut> Run(TIn input, Action<IRunResult<TOut>> evaluatedCallbackAction = null);
        public abstract TOut OnRun(TIn input);

    }
}

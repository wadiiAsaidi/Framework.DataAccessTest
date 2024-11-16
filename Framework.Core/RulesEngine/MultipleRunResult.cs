using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Core.RulesEngine
{
    public interface IMultipleRunResult<out TOut> : IRunResult<TOut>
    {
        public IEnumerable<IRunResult<TOut>> SingleRunResults { get; }
    }
    public class MultipleRunResult<TOut> : IMultipleRunResult<TOut>
    {
        public IActivity Rule { get; set; }

        public bool IsMatched
        {
            get { return this.SingleRunResults.Any(u => u.IsMatched); }
        }

        public TOut Result { get; internal set; }

        public IEnumerable<IRunResult<TOut>> SingleRunResults { get; internal set; }
    }
}

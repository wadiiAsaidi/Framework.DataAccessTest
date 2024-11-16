using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.RulesEngine
{
    public interface IRunResult<out TOut>
    {
        public IActivity Rule { get; }
        public bool IsMatched { get; }
        public TOut Result { get; }
    }
}

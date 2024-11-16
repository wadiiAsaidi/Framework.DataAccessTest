using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.RulesEngine
{
    public interface ISingleResult<out T> : IRunResult<T>
    {

    }
    
    public class SingleResult<T> : ISingleResult<T>
    {
        public IActivity Rule { get; set; }
        public bool IsMatched { get; set; }
        public T Result { get; set; }
    }
}

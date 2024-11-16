using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.ObservatorPattern
{
    public interface IObserver<T>
    {
        public void OnNext();
        public void OnError(Exception ex);
        public void OnCompleted();
    }


    public abstract class Observer<T> : IObserver<T>
    {
        public abstract void OnCompleted();
        public abstract void OnError(Exception ex);
        public abstract void OnNext();

    }
}

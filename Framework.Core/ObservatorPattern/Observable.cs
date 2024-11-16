using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.ObservatorPattern
{
    public interface IObservable<T>
    {
        void Notify(IObservable<T> value);
        void OnConfigure();
    }

    public abstract class Observable<T> : IObservable<T>
    {
        public List<IObserver<T>> Observers { get; set; }
        public Observable()
        {
            Configure();
        }
        public void Configure()
        {
            this.OnConfigure();
        }
        public abstract void OnConfigure();

        public Observable<T> Register(IObserver<T> Observer)
        {
            Observers.Add(Observer);
            Reset(this, Observer);
            return this;
        }
        public Observable<T> Reset(Observable<T> observable, IObserver<T> observer)
        {
            new Unsubscriber<T>(observable.Observers, observer);
            return this;
        }
        public void Notify(IObservable<T> value) 
        { 
        
        }

        object this[int index] 
        {
            get 
            {  
                return this[index]; 
            }
            set 
            { 
                this[index] = value; 
            }
        }

    }

    public class Unsubscriber<T> : IDisposable
    {
        private List<IObserver<T>> _observers;
        private IObserver<T> _observer;

        public Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observer != null && _observers.Contains(_observer))
            {
                _observers.Remove(_observer);
            }
        }
    }
}

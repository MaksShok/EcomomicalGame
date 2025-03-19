using System;
using R3;

namespace Game.Scripts.UI.MVVM
{
    public abstract class ViewModel : IViewModel, IDisposable
    {
        public Observable<ViewModel> ClosedRequest => _closedRequest;
        private Subject<ViewModel> _closedRequest = new();

        public abstract string PrefabName { get; } 
        
        public void CloseRequest()
        {
            _closedRequest.OnNext(this);
        }

        public virtual void Dispose() { }
    }
}
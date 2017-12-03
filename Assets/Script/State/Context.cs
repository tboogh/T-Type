using System;

namespace Assets.Script.State
{
    public class StateEventArgs : EventArgs
    {
        public StateEventArgs(IState state)
        {
            State = state;
        }

        public IState State { get; private set; }
    }
    
    public class Context : IContext
    {
        public IState CurrentState { get; private set; }
        public IContext Parent { get; private set; }
        public event EventHandler<StateEventArgs> StateChanging;
        public event EventHandler<StateEventArgs> StateChanged;

        private bool _disposedValue; // To detect redundant calls

        public Context(IContext parentContext = null)
        {
            Parent = parentContext;
        }

        public void SetState(IState state)
        {
            ChangeState(state);
        }

        private void ChangeState(IState state)
        {
            OnStateChanging(state);
            Disable(CurrentState);
            DisposeState(CurrentState);
            SetCurrentState(state);
            Enable(CurrentState);
            OnStateChanged(state);
        }

        protected void SetCurrentState(IState state)
        {
            CurrentState = state;
        }

        protected void DisposeState(IState state)
        {
            if (state != null) 
                state.Dispose();
        }

        protected void Enable(IState state)
        {
            var enableAware = state as IEnableAware;
            if (enableAware != null)
                enableAware.OnEnable();
        }

        protected void Disable(IState state)
        {
            var disableAware = state as IDisableAware;
            if (disableAware != null)
                disableAware.OnDisable();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    if (CurrentState != null) 
                        CurrentState.Dispose();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void OnStateChanged(IState state)
        {
            if (StateChanged != null) 
                StateChanged.Invoke(this, new StateEventArgs(state));
        }

        protected virtual void OnStateChanging(IState state)
        {
            if (StateChanging != null) 
                StateChanging.Invoke(this, new StateEventArgs(state));
        }
    }
}
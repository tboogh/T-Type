using System;

namespace Assets.Script.State
{
    public interface IContext : IDisposable
    {
        void SetState(IState state);
        IState CurrentState { get; }

        IContext Parent { get; }
    }
}

using System;

namespace Assets.Script.State
{
    public interface IState : IDisposable
    {
        IContext Context { get; }
    }
}
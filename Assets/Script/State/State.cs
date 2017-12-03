namespace Assets.Script.State
{
    public abstract class State : IState
    {
        private bool _disposedValue = false; // To detect redundant calls
        public IContext Context { get; private set; }


        protected State(IContext context)
        {
            Context = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
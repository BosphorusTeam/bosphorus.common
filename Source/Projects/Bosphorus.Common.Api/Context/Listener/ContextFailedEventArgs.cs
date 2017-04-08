namespace Bosphorus.Common.Api.Context.Listener
{
    public class ContextFailedEventArgs<TContext>: ContextEventArgs<TContext> 
    {

        public ContextFailedEventArgs(TContext context, System.Exception exception)
            : base(context)
        {
            this.Exception = exception;
            Handled = false;
        }

        public System.Exception Exception { get; }

        public bool Handled { get; set; }
    }
}

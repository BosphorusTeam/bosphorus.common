using System;

namespace Bosphorus.Common.Api.Context.Listener
{
    //TODO: LogicalCallContext kavramına bak, uyarlamaya çalış.
    //Windows button arkasında bile çalışıyormuş.
    //http://stackoverflow.com/questions/4147500/how-to-limit-the-scope-of-a-logical-call-context
    //http://stackoverflow.com/questions/1951924/executioncontext-of-threads
    //http://weblogs.asp.net/dixin/understanding-c-sharp-async-await-3-runtime-context
    public interface IContextListener<TContext>
        where TContext: IContext
    {
        event EventHandler<ContextEventArgs<TContext>> ContextStarted;
        event EventHandler<ContextFailedEventArgs<TContext>> ContextFailed;
        event EventHandler<ContextEventArgs<TContext>> ContextSuccessful;
        event EventHandler<ContextEventArgs<TContext>> ContextFinished;

    }
}
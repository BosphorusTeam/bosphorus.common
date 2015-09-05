using System;

namespace Bosphorus.Common.Core.CoC.Acceptance
{
    public interface ICriteria<out TInspectorContext>
    {
        TInspectorContext Context { get; }

        bool Result { get; }
        ICriteria<TInspectorContext> Expect(Func<TInspectorContext, bool> evaluation);

    }
}
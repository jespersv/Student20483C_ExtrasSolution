using System;

namespace Extra
{
    public static class FunctionExtensions
    {
        public static TResult Map<TSource, TResult>(this TSource @this, Func<TSource, TResult> fn)
            => fn(@this);
    }
}
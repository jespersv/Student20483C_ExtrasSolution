using System;
using System.Collections.Generic;

namespace Extra
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> RemoveSequenceDuplicate<T>(this IEnumerable<T> values) where T : Enum
        {
            int previous = -1;
            foreach (var value in values)
            {
                var intVal = (int)(object)value;
                if (previous == -1)
                {
                    yield return value;
                    previous = intVal;
                    continue;
                }
                if (previous == intVal)
                    continue;
                yield return value;
                previous = intVal;
            }
        }
    }
}
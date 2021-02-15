using System.Collections.Generic;

namespace Extra
{
    public static class SectionFactory
    {
        public static IEnumerable<Section> ToSections(this int[] values)
        {
            for (int i = 1; i < values.Length - 1; i++) yield return new Section(values[i - 1], values[i], values[i + 1]);
        }
    }
}
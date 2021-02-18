using System.Collections.Generic;

namespace Extra
{
    public static class SectionFactory
    {
        public static IEnumerable<Section> ToSections(this int[] values)
        {
            for (int i = 1; i < values.Length - 1; i++) yield return new Section(values[i - 1], values[i], values[i + 1]);
        }

        //lazy version
        public static IEnumerable<Section> ToSections(this IEnumerable<int> values)
        {
            int? f = null, m = null, l = null;
            foreach (var value in values)
            {
                if (SetValueIfNull(ref f, value)) continue;
                if (SetValueIfNull(ref m, value)) continue;
                SetValueIfNull(ref l, value);

                f = m;
                m = l;
                l = value;
                yield return new Section(f.Value, m.Value, l.Value);
            }

            bool SetValueIfNull(ref int? s, int v)
            {
                if (s.HasValue) return false;
                s = v;
                return true;
            }
        }
    }
}
using System.Collections.Generic;

namespace Extra
{
    internal class Loop
    {
        private readonly List<string> values;

        public Loop()
        {
            values = new List<string>();
            index = 0;
            LastIndex = -1;
        }

        public string Current { get; private set; }
        private int index;
        public int LastIndex { get; private set; }

        internal void Add(string v)
        {
            if (string.IsNullOrEmpty(Current))
            {
                Current = v;
            }

            values.Add(v);
            LastIndex++;
        }

        internal void Next()
        {
            index = index >= values.Count-1 ? 0 : index + 1;
            Current = values[index];
        }

        internal void Previous()
        {
            index = index == 0 ? values.Count-1 : index - 1;
            Current = values[index];
        }
    }
}
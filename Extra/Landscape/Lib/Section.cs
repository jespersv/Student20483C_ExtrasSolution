namespace Extra
{
    public struct Section
    {
        public int Prev { get; }
        public int Curr { get; }
        public int Next { get; }

        public Section(int prev, int curr, int next)
        {
            Prev = prev;
            Curr = curr;
            Next = next;
        }

        public override string ToString()
        {
            return $"{Prev} {Curr} {Next}";
        }
    }
}
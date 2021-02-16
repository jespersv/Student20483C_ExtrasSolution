using System.Collections.Generic;
using System.Linq;

namespace Extra
{
    public static class VectorFactory
    {
        public static IEnumerable<Vector> ToVectors(this IEnumerable<Section> sections) => sections.Select(ToVector);

        public static Vector ToVector(this Section s)
        {
            if (s.Prev < s.Curr) //up,top
            {
                if (s.Curr > s.Next)
                    return Vector.Top;
                return Vector.Up;
            }
            if (s.Prev > s.Curr) //down,bottom
            {
                if (s.Next > s.Curr) return Vector.Bottom;
                return Vector.Down;
            }
            // prev == s.curr, up/down/plateau
            if (s.Curr == s.Next) return Vector.Plateau;
            if (s.Curr > s.Next) return Vector.Down;
            return Vector.Up;
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace Extra
{
    public static class VectorEvaluator
    {
        public static string Eval2(List<Vector> vectors)
        {
            var guess = ResultConsts.Neither;
            for (int i = 0; i < vectors.Count; i++)
            {
                var vector = vectors[i];
                if (i == 0)
                {
                    if (vector == Vector.Up || vector == Vector.Top) guess = ResultConsts.Mountain;
                    if (vector == Vector.Down || vector == Vector.Bottom) guess = ResultConsts.Valley;
                    var hasNext = i < vectors.Count - 1;
                    if (hasNext) continue;
                    if (vector == Vector.Up || vector == Vector.Down) return ResultConsts.Neither;
                    continue;
                }
                var previous = vectors[i - 1];
                if (previous == Vector.Up && vector != Vector.Top) return ResultConsts.Neither;
                if (previous == Vector.Down && vector != Vector.Bottom) return ResultConsts.Neither;
                if (previous == Vector.Top && vector != Vector.Down) return ResultConsts.Neither;
                if (previous == Vector.Bottom && vector != Vector.Up) return ResultConsts.Neither;
            }

            return guess;
        }

        public static string Eval(List<Vector> vectors)
        {
            if (vectors.Count(p => p == Vector.Top) > 1) return ResultConsts.Neither;
            if (vectors.Count(p => p == Vector.Bottom) > 1) return ResultConsts.Neither;

            if (vectors.Count == 1)
            {
                if (vectors.First() == Vector.Top) return ResultConsts.Mountain;
                if (vectors.First() == Vector.Bottom) return ResultConsts.Valley;
                return ResultConsts.Neither;
            }
            if (vectors.Count == 3)
            {
                if (vectors[0] == Vector.Up && vectors[1] == Vector.Top && vectors[2] == Vector.Down)
                    return ResultConsts.Mountain;
                if (vectors[0] == Vector.Down && vectors[1] == Vector.Bottom && vectors[2] == Vector.Up)
                    return ResultConsts.Valley;
                return ResultConsts.Neither; // should technically not be possible
            }
            if (vectors.Count == 2)
            {
                if (vectors[0] == Vector.Top && vectors[1] == Vector.Down) return ResultConsts.Mountain;
                if (vectors[0] == Vector.Up && vectors[1] == Vector.Top) return ResultConsts.Mountain;
                if (vectors[0] == Vector.Down && vectors[1] == Vector.Bottom) return ResultConsts.Valley;
                if (vectors[0] == Vector.Bottom && vectors[1] == Vector.Up) return ResultConsts.Valley;
            }
            return ResultConsts.Neither;
        }
    }
}
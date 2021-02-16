using System.Collections.Generic;
using System.Linq;

namespace Extra
{
    public static class VectorEvaluator
    {
        public static string Eval(List<Vector> vectors)
        {
            if (vectors.Count == 1)
            {
                if (vectors.First() == Vector.Top) return ResultConsts.Mountain;
                if (vectors.First() == Vector.Bottom) return ResultConsts.Valley;
                return ResultConsts.Neither;
            }

            //this part can be done with vectors.Count(predicate) >1. but this is more fun
            var totals = vectors
                .GroupBy(p => p)
                .ToDictionary(p => p.Key, p => p.Count());
            if (totals.ContainsKey(Vector.Top) && totals[Vector.Top] > 1) return ResultConsts.Neither;
            if (totals.ContainsKey(Vector.Bottom) && totals[Vector.Bottom] > 1) return ResultConsts.Neither;
            if (vectors.Distinct().Count() == 1) return ResultConsts.Neither;

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
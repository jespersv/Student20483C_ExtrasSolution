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

            var totals = vectors
                .GroupBy(p => p)
                .ToDictionary(p => p.Key, p => p.Count());
            if (totals.ContainsKey(Vector.Top) && totals[Vector.Top] > 1) return ResultConsts.Neither;
            if (totals.ContainsKey(Vector.Bottom) && totals[Vector.Bottom] > 1) return ResultConsts.Neither;
            if (vectors.Distinct().Count() == 1) return ResultConsts.Neither;

            var prunedVectors = vectors.RemoveSequenceDuplicate().ToArray();
            if (prunedVectors.Length == 3)
            {
                if (prunedVectors[0] == Vector.Up && prunedVectors[1] == Vector.Top && prunedVectors[2] == Vector.Down)
                    return ResultConsts.Mountain;
                if (prunedVectors[0] == Vector.Down && prunedVectors[1] == Vector.Bottom && prunedVectors[2] == Vector.Up)
                    return ResultConsts.Valley;
                return ResultConsts.Neither; // should technically not be possible
            }
            if (prunedVectors.Length == 2)
            {
                if (prunedVectors[0] == Vector.Top && prunedVectors[1] == Vector.Down) return ResultConsts.Mountain;
                if (prunedVectors[0] == Vector.Up && prunedVectors[1] == Vector.Top) return ResultConsts.Mountain;
                if (prunedVectors[0] == Vector.Down && prunedVectors[1] == Vector.Bottom) return ResultConsts.Valley;
                if (prunedVectors[0] == Vector.Bottom && prunedVectors[1] == Vector.Up) return ResultConsts.Valley;
            }
            return ResultConsts.Neither;
        }
    }
}
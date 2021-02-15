using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Extra
{
    [TestClass]
    public class LandscapeTypeTest
    {
        [TestCase(new[] { 3, 4, 5, 4, 3 }, ResultConsts.Mountain)]
        [TestCase(new[] { 1, 3, 5, 4, 3, 2 }, ResultConsts.Mountain)]
        [TestCase(new[] { -1, 0, -1 }, ResultConsts.Mountain)]
        [TestCase(new[] { -1, -1, 0, -1, -1 }, ResultConsts.Mountain)]
        [TestCase(new[] { 10, 9, 8, 7, 2, 3, 4, 5 }, ResultConsts.Valley)]
        [TestCase(new[] { 350, 100, 200, 400, 700 }, ResultConsts.Valley)]
        [TestCase(new[] { 9, 7, 3, 1, 2, 4 }, ResultConsts.Valley)]
        [TestCase(new[] { 9, 8, 9 }, ResultConsts.Valley)]
        [TestCase(new[] { 3, 2, 2, 1, 2 }, ResultConsts.Valley)]
        [TestCase(new[] { 9, 0, 0, 9, 0, 0 }, ResultConsts.Neither)] // två toppar
        [TestCase(new[] { 0, -1, -1, 0, -1, -1 }, ResultConsts.Neither)] // två toppar
        [TestCase(new[] { 1, 2, 3, 2, 4, 1 }, ResultConsts.Neither)] // två toppar
        [TestCase(new[] { 5, 4, 3, 2, 1 }, ResultConsts.Neither)]    // kant
        [TestCase(new[] { 9, 8, 9, 8 }, ResultConsts.Neither)]

        //cases i've added
        [TestCase(new int[0], ResultConsts.Neither)]
        [TestCase(new[] { 0 }, ResultConsts.Neither)]
        [TestCase(new[] { 0, 1 }, ResultConsts.Neither)]
        [TestCase(new[] { 1, 0 }, ResultConsts.Neither)]
        [TestCase(new[] { 0, 0, 0 }, ResultConsts.Neither)]

        public void Test_LandscapeType(int[] arr, string expected)
        {
            Assert.AreEqual(expected, LandscapeType(arr));
        }

        private string LandscapeType(int[] arr)
        {
            return arr
                .ToSections()
                .ToVectors()
                .Where(v => v != Vector.Plateau)
                .ToList()
                .Map(VectorEvaluator.Eval);
        }
    }

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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
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
                .RemoveSequenceDuplicate()
                .ToList()
                .Map(VectorEvaluator.Eval);
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Collections;
using System.Linq;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using CollectionAssert = Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert;

namespace Extra
{
    [TestClass]
    public class IntegerToArrayTest
    {
        [TestCase()]
        public void array_to_integer()
        {
            Assert.AreEqual(
                123,
                ArrayToInteger(new int[] { 1, 2, 3 }));

            Assert.AreEqual(
                12,
                ArrayToInteger(new int[] { 0, 1, 2 }));

            Assert.AreEqual(
                11223,
                ArrayToInteger(new int[] { 01, 12, 23 }));
        }

        private int ArrayToInteger(int[] vs)
        {
            if (vs is null) return default;
            return vs
                .Select(p => $"{p}")
                .Aggregate((s, s1) => $"{s}{s1}")
                .ToInt();
        }

        [TestCase]
        public void integer_to_array()
        {
            CollectionAssert.AreEqual(
                new[] { 1, 1, 2, 1, 1, 2, 3, 0 },
                IntegerToArray(11211230)
            );

            CollectionAssert.AreEqual(
                new[] { 5 },
                IntegerToArray(5)
            );

            CollectionAssert.AreEqual(
                new[] { 1, 3, 0, 0, 1, 1, 2, 0 },
                IntegerToArray(13001120)
            );
            CollectionAssert.AreEqual(
                new[] { 1, 0, 0, 0 },
                IntegerToArray(1000)
            );
        }

        private ICollection IntegerToArray(int v) =>
            v
                .ToString()
                .ToCharArray()
                .Select(p => $"{p}")
                .Select(int.Parse)
                .ToList();
    }

    public static class IntExt
    {
        public static int ToInt(this string t) => int.Parse(t);
    }
}
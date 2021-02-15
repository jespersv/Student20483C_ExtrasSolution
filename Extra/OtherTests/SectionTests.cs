using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Linq;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Extra
{
    [TestClass]
    public class SectionTests
    {
        [TestCase(new[] { 1, 1, 1 }, Vector.Plateau)]
        [TestCase(new[] { 1, 0, 1 }, Vector.Bottom)]
        [TestCase(new[] { 1, 0, 0 }, Vector.Down)]
        [TestCase(new[] { 1, 1, 0 }, Vector.Down)]
        [TestCase(new[] { 0, 1, 1 }, Vector.Up)]
        [TestCase(new[] { 0, 0, 1 }, Vector.Up)]
        [TestCase(new[] { 0, 1, 0 }, Vector.Top)]
        public void SectionTest(int[] sV, Vector expected)
        {
            var plat = new Section(sV[0], sV[1], sV[2]);
            Assert.AreEqual(expected, plat.ToVector());
        }
    }
    [TestClass]
    public class SectionFactoryTests
    {
        [TestCase(new[] { 1,1,1 }, 1)]
        [TestCase(new[] { 1,1,1,1 }, 2)]
        [TestCase(new[] { 1,1,1,1,1 }, 3)]
        [TestCase(new[] { 1,1,1,1,1,1 }, 4)] //etc length-2
        public void SectionTest(int[] s, int expected)
        {
            var sections= s.ToSections();
            Assert.AreEqual(expected, sections.Count());
            Assert.AreEqual(s.Length-2, sections.Count());
        }
    }
}
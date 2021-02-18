using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Extra
{
    [TestClass]
    public class LoopTest
    {
        [TestCase()]
        public void three_elements()
        {
            var loop = new Loop();
            loop.Add("Jaws");
            loop.Add("Psycho");
            loop.Add("Casablanca");

            string s;

            s = loop.Current;
            Assert.AreEqual("Jaws", s);

            loop.Next();
            s = loop.Current;
            Assert.AreEqual("Psycho", s);

            loop.Next();
            s = loop.Current;
            Assert.AreEqual("Casablanca", s);

            loop.Next();
            s = loop.Current;
            Assert.AreEqual("Jaws", s);

            loop.Next();
            s = loop.Current;
            Assert.AreEqual("Psycho", s);

            loop.Previous();
            s = loop.Current;
            Assert.AreEqual("Jaws", s);

            loop.Previous();
            s = loop.Current;
            Assert.AreEqual("Casablanca", s);
        }

        [TestCase]
        public void four_elements()
        {
            var loop = new Loop();
            loop.Add("Jaws");
            loop.Add("Psycho");
            loop.Add("Casablanca");
            loop.Add("Taxi Driver");

            string s;

            s = loop.Current;
            Assert.AreEqual("Jaws", s);

            loop.Next();
            s = loop.Current;
            Assert.AreEqual("Psycho", s);

            loop.Next();
            s = loop.Current;
            Assert.AreEqual("Casablanca", s);

            loop.Next();
            s = loop.Current;
            Assert.AreEqual("Taxi Driver", s);

            loop.Next();
            s = loop.Current;
            Assert.AreEqual("Jaws", s);

            loop.Next();
            s = loop.Current;
            Assert.AreEqual("Psycho", s);
        }

        [TestCase]
        public void lastindex()
        {
            var loop = new Loop();

            loop.Add("A");
            Assert.AreEqual(0, loop.LastIndex);

            loop.Add("A");
            Assert.AreEqual(1, loop.LastIndex);

            loop.Add("A");
            Assert.AreEqual(2, loop.LastIndex);

            loop.Add("A");
            Assert.AreEqual(3, loop.LastIndex);
        }

        [TestCase]
        public void previous()
        {
            var loop = new Loop();
            loop.Add("Apocalypse Now");
            loop.Add("E.T");
            loop.Add("Pulp Fiction");

            string s;

            s = loop.Current;
            Assert.AreEqual("Apocalypse Now", s);

            loop.Previous();
            s = loop.Current;
            Assert.AreEqual("Pulp Fiction", s);

            loop.Previous();
            s = loop.Current;
            Assert.AreEqual("E.T", s);

            loop.Previous();
            s = loop.Current;
            Assert.AreEqual("Apocalypse Now", s);

            loop.Previous();
            s = loop.Current;
            Assert.AreEqual("Pulp Fiction", s);
        }
    }
}
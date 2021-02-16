using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Extra
{
    [TestClass]
    public class AdjustCaseTest
    {
        [TestCase("rhino", "cAt", "rHino")]
        [TestCase("cat", "RHino", "CAt")]
        [TestCase("rhino", "aAaaA", "rHinO")]
        [TestCase("RHINO", "aAaaA", "rHinO")]
        [TestCase("RHINO", "aAaaAaAaAaA", "rHinO")]   // längre template
        [TestCase("RHINOoOoO", "aAaaA", "rHinOoOoO")] // längre ord
        public void adjust_case(string word, string template, string expected)
        {
            Assert.AreEqual(expected, AdjustCase(word, template));
        }

        private string AdjustCase(string word, string template)
        {
            //todo sloppy
            var cut = word.Length <= template.Length ? word.Length : template.Length;
            var start = word.Substring(0, cut);
            var rest = word.Substring(cut);
            var newStart = new char[cut];
            for (int i = 0; i < start.Length; i++)
            {
                var w = start[i];
                var t = template[i];
                if (char.IsUpper(w) && char.IsLower(t)) w = char.ToLower(w);
                else if (char.IsLower(w) && char.IsUpper(t)) w = char.ToUpper(w);
                newStart[i] = w;
            }

            return $"{new string(newStart)}{rest}";
        }
    }
}
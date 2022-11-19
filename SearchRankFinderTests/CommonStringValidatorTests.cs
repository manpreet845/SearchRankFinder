using NUnit.Framework;
using SearchRankFinder.Core.Helpers;

namespace SearchRankFinderTests
{
    public class CommonStringValidatorTests
    {
        [TestCase("", true)]
        [TestCase(null, true)]
        [TestCase("not null or empty", false)]
        public void IsNullOrEmptyTests(string value, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, value.IsNullOrEmpty());
        }

        [TestCase("", false)]
        [TestCase(null, false)]
        [TestCase("https://www.google.com/", true)]
        [TestCase("http://www.google.com/search", true)]
        [TestCase("https://www.youtube.com/", true)]
        public void IsValidUrlTests(string value, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, value.IsValidUrl());
        }
    }
}
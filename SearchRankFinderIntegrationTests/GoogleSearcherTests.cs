using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using SearchRankFinder.Core.Configuration;
using SearchRankFinder.Core.Logging;
using SearchRankFinder.Core.Search;

namespace SearchRankFinderIntegrationTests
{
    public class GoogleSearcherTests
    {
        IConfigSettings configSettings;
        ILogger logger;
        ISearcher googleSearcher;

        [SetUp]
        public void Setup()
        {
            configSettings = Substitute.For<IConfigSettings>();
            configSettings.GetHtmlRankLinkReference().Returns("<a class=\"cz3goc\"");
            configSettings.GetSearchEngineResultLimit().Returns(10);
            configSettings.GetSearchEngineUrl().Returns("http://www.google.com/search");
            logger = Substitute.For<ILogger>();

            googleSearcher = new GoogleSearcher(configSettings, logger);
        }

        // Simple Integration Test to test ISearcher
        // this test is not ideal as search rankings may change over time
        // however for the purpose of this demo it will fetch real results and return rankings 
        [TestCase("google", "https://www.google.com", "1, 2")]
        [TestCase("conveyancing software", "https://www.smokeball.com.au", "1")]
        public async Task GetSearchRankingsTest(string keywords, string urlToInspect, string expectedResult)
        {
            var result = await googleSearcher.GetSearchRankingsAsync(keywords, urlToInspect);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
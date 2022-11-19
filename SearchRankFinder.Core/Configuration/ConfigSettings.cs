namespace SearchRankFinder.Core.Configuration
{
    public class ConfigSettings : IConfigSettings
    {
        // Google search url we can use as a base append the search criteria
        private const string SearchEngineUrl = "http://www.google.com/search";

        // Limit of search results
        private const int SearchEngineResultLimit = 100;

        // Common html that all rankings links begin with
        private const string LinkReference = "<a class=\"cz3goc\"";

        public string GetSearchEngineUrl()
        {
            return SearchEngineUrl;
        }

        public int GetSearchEngineResultLimit()
        {
            return SearchEngineResultLimit;
        }

        public string GetHtmlRankLinkReference()
        {
            return LinkReference;
        }
    }
}

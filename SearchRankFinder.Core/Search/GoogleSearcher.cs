using HtmlAgilityPack;
using SearchRankFinder.Core.Configuration;
using SearchRankFinder.Core.Helpers;
using SearchRankFinder.Core.Logging;

namespace SearchRankFinder.Core.Search;

public class GoogleSearcher : ISearcher
{
    private readonly IConfigSettings configSettings;
    private readonly ILogger logger;

    public GoogleSearcher(IConfigSettings configSettings, ILogger logger)
    {
        this.configSettings = configSettings;
        this.logger = logger;
    }

    public async Task<string> GetSearchRankingsAsync(string keywords, string urlToInspect)
    {
        try
        {
            var rankingLinks = await GetRankingLinks(keywords);

            var result = new List<int>();
            for (var i = 0; i < rankingLinks.Count; i++)
            {
                if (rankingLinks[i].Contains(urlToInspect))
                {
                    // List indexes are zero based so we need to add 1 
                    result.Add(i + 1);
                }
            }

            return result.Any()
                ? string.Join(", ", result)
                : "0";
        }
        catch (Exception e)
        {
            logger.Log("Internal error, something went wrong while searching rankings", LogLevel.Error, e);
            return "Sorry and error has occurred, please try again";
        }
    }

    private async Task<IReadOnlyList<string>> GetRankingLinks(string keywords)
    {
        var web = new HtmlWeb();
        var queryParameters = new List<(string key, string value)>
        {
            ("q", keywords),
            ("num", configSettings.GetSearchEngineResultLimit().ToString())
        };

        var searchUrl = UrlBuilder.AddQueriesToUrl(configSettings.GetSearchEngineUrl(), queryParameters);
        var doc = await web.LoadFromWebAsync(searchUrl);

        return doc.DocumentNode
            // Get all possible links on the page
            .SelectNodes("//a")
            // Filter out links that are not rankings
            .Where(node => node.OuterHtml.StartsWith(configSettings.GetHtmlRankLinkReference()))
            // We only need the url from the search result
            .Select(node => node.Attributes["href"].Value)
            .ToList();
    }
}
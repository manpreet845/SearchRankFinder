namespace SearchRankFinder.Core.Search;

public interface ISearcher
{
    /// <summary>
    /// The function will use the provided keywords and return a string of all listed rankings for the provided URL.
    /// 
    /// Example of results
    ///     "1, 10, 33";
    /// 
    /// Example of provided URL without any ranking
    ///     "0";
    /// </summary>
    Task<string> GetSearchRankingsAsync(string keywords, string urlToInspect);
}
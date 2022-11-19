namespace SearchRankFinder.Core.Configuration;

public interface IConfigSettings
{
    string GetSearchEngineUrl();
    int GetSearchEngineResultLimit();
    string GetHtmlRankLinkReference();

}
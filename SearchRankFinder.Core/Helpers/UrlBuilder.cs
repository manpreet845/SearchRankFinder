namespace SearchRankFinder.Core.Helpers;

public static class UrlBuilder
{
    public static string AddQueriesToUrl(string baseUrl, IReadOnlyList<(string key, string value)> queryParameters)
    {
        if (!baseUrl.IsValidUrl())
        {
            throw new ArgumentException("Invalid base url for adding query parameters", "baseUrl");
        }

        // If there are no query parameters we can just return the given host
        if (!queryParameters.Any())
        {
            return baseUrl;
        }

        var query = string.Join('&', queryParameters.Select(tuple => $"{tuple.key}={tuple.value}"));

        return $"{baseUrl}?{query}";
    }
}
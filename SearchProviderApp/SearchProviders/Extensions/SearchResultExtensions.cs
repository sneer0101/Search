using SearchProviderApp.SearchProviders.Models;

namespace SearchProviderApp.SearchProviders.Extensions;

internal static class SearchResultExtensions
{
    internal static IEnumerable<SearchResult> ToModel(this IEnumerable<SearchResult>[] searchResultSets) => searchResultSets.SelectMany(searchResultSet => searchResultSet).ToList();
}

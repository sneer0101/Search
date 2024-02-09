using SearchProviderApp.SearchProviders.Interfaces;
using SearchProviderApp.SearchProviders.Models;

namespace SearchProviderApp.SearchProviders;

internal class LegacyFormSearchRepository : ISearchProvider
{
    public string Source => "Legacy Forms";

    public async Task<IEnumerable<SearchResult>> GetSearchResults(string searchTerm)
    {
        var searchResults = Results
            .Where(o => o.Contains(searchTerm))
            .Select(e => new SearchResult
            {
                SourceName = this.Source,
                ResultText = e
            });

        return await Task.FromResult(searchResults);
    }

    private static IEnumerable<string> Results => new List<string> {
      "Test 1",
      "Test 2",
      "Test 3"
    };
}

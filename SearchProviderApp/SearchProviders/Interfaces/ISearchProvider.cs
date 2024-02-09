using SearchProviderApp.SearchProviders.Models;

namespace SearchProviderApp.SearchProviders.Interfaces;

internal interface ISearchProvider
{
    string Source { get; }

    Task<IEnumerable<SearchResult>> GetSearchResults(string searchTerm);
}

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SearchProviderApp.SearchProviders;
using SearchProviderApp.SearchProviders.Extensions;
using SearchProviderApp.SearchProviders.Interfaces;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddTransient<ISearchProvider, LegacyFormSearchRepository>();
builder.Services.AddTransient<ISearchProvider, PdfSearchRepository>();

using IHost host = builder.Build();

using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;

var searchProviders = provider.GetServices<ISearchProvider>()!;

var searchTasks = searchProviders.Select(o => o.GetSearchResults("1"));

var results = await Task.WhenAll(searchTasks);

var searchResultModel = results.ToModel();

Console.ReadLine();

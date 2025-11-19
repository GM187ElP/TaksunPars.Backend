using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TaksunPars.UI.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri("http://localhost:5023") });

builder.RootComponents.Add<Routes>("body");

await builder.Build().RunAsync();
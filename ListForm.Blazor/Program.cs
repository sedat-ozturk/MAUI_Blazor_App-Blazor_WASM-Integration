using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using ListForm.Blazor;
using ListForm.Blazor.Services;
using ListForm.Domain.Interfaces;
using ListForm.Domain.Repository;
using ListForm.Shared.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<IPlatformService, PlatformService>();

builder.Services.AddBlazorise(options => { options.Immediate = true; }).AddBootstrapProviders().AddFontAwesomeIcons();

await builder.Build().RunAsync();

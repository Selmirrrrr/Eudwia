using System.Globalization;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using MosqueLife.Client.Providers;
using MosqueLife.Client.Theme;
using MudBlazor;

namespace MosqueLife.Client;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");

        builder.Services.AddHttpClient("MosqueLife.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

        builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("MosqueLife.ServerAPI"));

        builder.Services.AddMudServices();

        builder.Services.AddOptions();
        builder.Services.AddAuthorizationCore();
        builder.Services.AddBlazoredLocalStorage();
        builder.Services.AddScoped<TokenAuthenticationStateProvider>();
        builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<TokenAuthenticationStateProvider>());
        builder.Services.AddSingleton<MudTheme, MudBlazorAdminDashboard>();

        var culture = new CultureInfo("fr-CH");
        culture.NumberFormat.NumberDecimalSeparator = ".";
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;

        await builder.Build().RunAsync();
    }
}
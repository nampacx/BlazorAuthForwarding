using AzureStaticWebApps.Blazor.Authentication;
using BlazorApp1;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services
            .AddTransient<HttpClient, HttpClient>(sp =>
            {
                var config = sp.GetRequiredService<IConfiguration>();
                var localhost = config.GetValue<string>("LocalhostBaseAddress");
                return new HttpClient { BaseAddress = new Uri(localhost ?? builder.HostEnvironment.BaseAddress) };
            });

        builder.Services.AddMsalAuthentication(options =>
        {
            builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
            options.ProviderOptions.DefaultAccessTokenScopes.Add("https://sql.azuresynapse-dogfood.net/user_impersonation");
        });

        await builder.Build().RunAsync();
    }
}
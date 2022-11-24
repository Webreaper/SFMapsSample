using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SFMapsSample.Client;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Internal;
using Syncfusion.Licensing;

namespace SFMapsSample.Client;

public class Program
{
    public static async Task Main(string[] args)
    {
        SyncfusionLicenseProvider.RegisterLicense(
            "NzU4MTU3QDMyMzAyZTMzMmUzMEEyTEJYL0I4R2RrOHdhUzJPdmh6bDJ5ZHo5bnNzNTRkYmZVRHBiMG5vdXc9");

        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        await builder.Build().RunAsync();
    }
}


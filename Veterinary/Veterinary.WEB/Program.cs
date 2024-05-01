using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Veterinary.WEB.Repositories;
using CurrieTechnologies.Razor.SweetAlert2;

namespace Veterinary.WEB
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:7000") });
            builder.Services.AddSweetAlert2();
            builder.Services.AddScoped<IRepository, Repository>();
            await builder.Build().RunAsync();
        }
    }
}

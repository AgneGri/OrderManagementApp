using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace OrderApp.Client
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);

			builder.Services.AddScoped(http => new HttpClient
			{
				BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
			});

			await builder.Build().RunAsync();
		}
	}
}
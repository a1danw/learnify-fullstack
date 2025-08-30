using System;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
public class Program
{
    public static async Task Main(string[] args)
    {
        // build the host
        var host = CreateHostBuilder(args).Build();

        // Create a scope for service resolution and dispose after its done
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<Program>>();

        try
        {
            // Database migration
            var context = services.GetRequiredService<StoreContext>();
            await context.Database.MigrateAsync(); // resolves pending migrations and creates db if it doesn't exist
            await StoreContextSeed.SeedAsync(context, logger);
        }
        catch(Exception ex)
        {
            // Logging any exceptions during migration
            logger.LogError(ex, "Something wrong happened during migration");
        }

        // Run the application
        await host.RunAsync();
    }
        // CreateHostBuilder method to set up the host - localhost:5000
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) // Default host configuration
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>(); // Configure the web host with Startup class
            });
    }
}
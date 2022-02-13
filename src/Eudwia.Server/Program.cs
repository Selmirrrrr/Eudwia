using Microsoft.EntityFrameworkCore;
using Eudwia.Server.Data.Contexts;

namespace Eudwia.Server;

public class Program
{
    public static async Task Main(string[] args)
    {
        var webHost = CreateHostBuilder(args).Build();

        // Create a new scope
        using var scope = webHost.Services.CreateScope();

        // Get the DbContext instance
        var myDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        //Do the migration asynchronously
        await myDbContext.Database.MigrateAsync();


        // Run the WebHost, and start accepting requests
        // There's an async overload, so we may as well use it
        await webHost.RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}

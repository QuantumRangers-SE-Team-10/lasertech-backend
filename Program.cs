using lasertech_backend.Model;
using Microsoft.EntityFrameworkCore;


class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder();

        var connectionString = builder.Configuration.GetConnectionString("GameContext");
        builder.Services.AddDbContext<GameContext>(options =>
            options.UseNpgsql(connectionString)
            );


        GameConnectionLoop();

        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.Run();

 

    }

    private async static void GameConnectionLoop()
    {

        int udpPort = 7500; // Example port

        var udpListenerService = new UdpListenerService(udpPort);
        await Task.Run(() => udpListenerService.StartListening()); // Run the UDP listener in a background task

    }
}





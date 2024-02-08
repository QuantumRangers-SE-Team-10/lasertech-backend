using lasertech_backend.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = "Host=localhost;Port=5432;Database=LaserTech;Username=postgres;Password=1234";
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseNpgsql(connectionString)
);



int udpPort = 7500; // Example port

var udpListenerService = new UdpListenerService(udpPort);
Task.Run(() => udpListenerService.StartListening()); // Run the UDP listener in a background task


var app = builder.Build();
app.MapGet("/", () => "Hello World!");

app.Run();
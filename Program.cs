using lasertech_backend.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

var connectionString = builder.Configuration.GetConnectionString("GameContext");
builder.Services.AddDbContext<GameContext>(options => options.UseNpgsql(connectionString));

int udpPort = 7500;

var udpListenerService = new UdpListenerService(udpPort);
var app = builder.Build();
var udp = Task.Run(() => udpListenerService.StartListening());

app.MapGet("/", () => "Hello World!");

app.Run();



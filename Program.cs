using lasertech_backend.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();
var connectionString = builder.Configuration.GetConnectionString("GameContext");
var env = builder.Environment;

builder.Services.AddControllers();
builder.Services.AddDbContext<GameContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

int udpPort = 7500;

var udpListenerService = new UdpListenerService(udpPort);
var udpCancellationToken = new CancellationTokenSource().Token;
var app = builder.Build();
Task.Run(() => udpListenerService.StartListening(udpCancellationToken), udpCancellationToken);

if (env.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
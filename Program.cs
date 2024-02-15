using lasertech_backend.Controllers;
using lasertech_backend.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();
var env = builder.Environment;

var connectionString = builder.Configuration.GetConnectionString("GameContext");
builder.Services.AddDbContext<GameContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

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
    app.UseCors("AllowAll");
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
using lasertech_backend.Controllers;
using lasertech_backend.Interface;
using lasertech_backend.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();
var env = builder.Environment;
var connectionString = builder.Configuration.GetConnectionString("GameContext");
builder.Services.AddDbContext<GameContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

int udpListenPort = 7501;
int udpBroadcastPort = udpListenPort - 1;
builder.Services.AddSingleton<GameUdpService>(new GameUdpService(udpListenPort, udpBroadcastPort));

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

var app = builder.Build();

if (env.IsDevelopment() || !env.IsDevelopment())
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
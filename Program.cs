var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

int udpPort = 7500; // Example port

var udpListenerService = new UdpListenerService(udpPort);
Task.Run(() => udpListenerService.StartListening()); // Run the UDP listener in a background task

app.MapGet("/", () => "Hello World!");

app.Run();
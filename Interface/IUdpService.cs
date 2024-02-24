namespace lasertech_backend.Interface;

public interface IUdpService
{
    Task StartListening(CancellationToken token);
    Task StartBroadcast(CancellationToken token);
}
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class UdpService
{
    private readonly UdpClient udpClient;
    private readonly int listenPort;
    private readonly int transmitPort;
    private List<string> equipmentIDs;

    public UdpService(int listenPort, int transmitPort)
    {
        this.listenPort = listenPort;
        this.transmitPort = transmitPort;
        this.udpClient = new UdpClient(listenPort);
        this.equipmentIDs = new List<string>();
    }

    public async Task StartListening(CancellationToken token)
    {
        Console.WriteLine("Listening...");
        while (!token.IsCancellationRequested)
        {
            var receivedResult = await udpClient.ReceiveAsync();
            string receivedMessage = Encoding.ASCII.GetString(receivedResult.Buffer);
            Console.WriteLine($"Received: {receivedMessage}");
            this.equipmentIDs.Add(receivedMessage);
        }
    }
    public async Task StartBroadcast(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            if (equipmentIDs.Count < 1) continue;
            foreach (var equipmentID in this.equipmentIDs)
            {
                byte[] bytes = Encoding.ASCII.GetBytes(equipmentID);
                await udpClient.SendAsync(bytes, bytes.Length, "127.0.0.1",transmitPort);
            }
            await Task.Delay(1000);
        }
    }
}

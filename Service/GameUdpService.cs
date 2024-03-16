using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using lasertech_backend.Interface;

public class GameUdpService : IUdpService
{
    private readonly UdpClient udpClient;
    private readonly int listenPort;
    private readonly int transmitPort;
    private List<string> equipmentIDs;

    public GameUdpService(int listenPort, int transmitPort)
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
        }
    }

    public async Task StartBroadcast(CancellationToken token)
    {
        Console.WriteLine("Broadcast started...");
        while (!token.IsCancellationRequested)
        {
            await Task.Delay(2000);
            if (equipmentIDs.Count < 1) continue;
            Console.WriteLine("Broadcasting equpmenent ID...");
            foreach (var equipmentID in this.equipmentIDs)
            {
                byte[] bytes = Encoding.ASCII.GetBytes(equipmentID);
                await udpClient.SendAsync(bytes, bytes.Length, "192.168.1.255", transmitPort);
            }
        }
    }

    public void AddEquipmentID(int equipmentID)
    {
        this.equipmentIDs.Add(equipmentID.ToString());
    }
}
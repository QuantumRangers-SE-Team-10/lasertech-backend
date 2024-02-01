using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class UdpListenerService
{
    private readonly UdpClient udpClient;
    private readonly int listenPort;

    public UdpListenerService(int port)
    {
        this.listenPort = port;
        this.udpClient = new UdpClient(listenPort);
    }

    public async Task StartListening()
    {
        while (true)
        {
            var receivedResult = await udpClient.ReceiveAsync();
            string receivedMessage = Encoding.ASCII.GetString(receivedResult.Buffer);
            Console.WriteLine($"Received: {receivedMessage}");

            // Here, you can add code to process the received message
            // For example, you might want to send a response or trigger an action within your application
        }
    }
}

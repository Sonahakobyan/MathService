using System;
using System.Net;
using System.Text;
using DataTransferLayer;

namespace MathClient
{
    public class ClientApp
    {
        // 192.168.1.3
        static void Main(string[] args)
        {
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8001);
            
            IClient client = new TCPClient(iPEndPoint);

            while (true)
            {
                string request = Console.ReadLine();
                client.Send(request);

                string response = client.Receive();
                Console.WriteLine(response);
            }
        }
    }
}

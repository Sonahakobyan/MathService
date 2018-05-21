using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DataTransferLayer
{
    public class TCPClient : IClient
    {

        public readonly TcpClient Client;
       // private NetworkStream stream;
        public TCPClient(IPEndPoint iPEndPoint)
        {
            this.Client = new TcpClient();
            this.Client.Connect(iPEndPoint);
           // this.stream = this.Client.GetStream();

        }
        string IClient.Receive()
        {
            //get the incoming data through a network stream
            NetworkStream stream = this.Client.GetStream();
            byte[] bytesToRead = new byte[this.Client.ReceiveBufferSize];
            int bytesRead = stream.Read(bytesToRead, 0, this.Client.ReceiveBufferSize);

            return Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
        }
        void IClient.Send(string request)
        {
            // get the client straem
            NetworkStream stream = this.Client.GetStream();

            // send the text
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(request);
            stream.Write(bytesToSend, 0, bytesToSend.Length);
        }
    }
}

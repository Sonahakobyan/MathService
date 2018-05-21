using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DataTransferLayer
{
    public class TCPServer : IServer
    {
        public readonly  TcpListener Listener;
  
        public TCPServer(IPEndPoint iPEndPoint)
        {
            this.Listener = new TcpListener(iPEndPoint);
            this.Listener.Start();
        }
        string IServer.Receive(object obj)
        {
            TcpClient client = obj as TcpClient;

            //get the incoming data through a network stream
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];

            //read incoming stream
            int bytesRead = stream.Read(buffer, 0, client.ReceiveBufferSize);

            //convert the data received into a string
            return Encoding.ASCII.GetString(buffer, 0, bytesRead);

        }
        void IServer.Send(object obj, string textToSend)
        {
            TcpClient client = obj as TcpClient;

            //get the stream from the clinet
            NetworkStream stream = client.GetStream();

            //send the text
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);
            stream.Write(bytesToSend, 0, bytesToSend.Length);
        }
        object IServer.AcceptClient()
        {
            return this.Listener.AcceptTcpClient();
        }
    }
}

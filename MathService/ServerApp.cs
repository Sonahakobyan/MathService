using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using DataTransferLayer;

namespace MathService
{
    class ServerApp
    {
        public static void Manage(object obj)
        {
            Tuple<object, object> tuple = obj as Tuple<object, object>;
            IServer service = tuple.Item1 as IServer;
            object client = tuple.Item2;

            while (true)
            {
                string request = service.Receive(client);

                double result = MathService.Calculate(request);

                service.Send(client, result.ToString());
            }
        }
        static void Main(string[] args)
        {
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 8001);
            IServer service = new TCPServer(iPEndPoint);

            while (true)
            {
                object client = service.AcceptClient();
                ThreadPool.QueueUserWorkItem(Manage, new Tuple<object, object>(service, client));
            }
        }
    }
}

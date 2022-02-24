using NetMQ;
using NetMQ.Sockets;
using System;
using System.Threading;

namespace FirstSubscriber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var client = new RequestSocket())
            {
                client.Bind("tcp://localhost:5555");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Sending Hello");
                    client.SendFrame("Hello");
                    var message = client.ReceiveFrameString();  
                    Console.WriteLine("Received {0}", message);
                }
            }
         }
    }
}

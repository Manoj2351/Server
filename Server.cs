using System;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Server
    {
        public static TcpListener listener;

        public static void Start()
        {
            listener = new TcpListener(System.Net.IPAddress.Any,8888);
            listener.Start();

            listener.BeginAcceptTcpClient(TCPConnectCallback,null);
            Console.WriteLine("Starting to accept TCP clients");

        }

        public static void TCPConnectCallback(IAsyncResult _result)
        {
            TcpClient client = listener.EndAcceptTcpClient(_result);    
            //FIXME Storing it like this stores it temorarily and accesable only within the func 
            //its advisable to maintain a list or a dict for saving all the clients and 
            //TODO maybe even open a thread for every client (more research on that later)

            Console.WriteLine($"Incoming connetion from {client.Client.RemoteEndPoint} has been accepted");
            listener.BeginAcceptTcpClient(TCPConnectCallback,null);
        }
    }
}
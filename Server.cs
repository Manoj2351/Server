using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Server
    {
        public static TcpListener listener;
        public static Dictionary<int,TcpClient> Clients = new Dictionary<int, TcpClient>();
        private int MaxPlayers = 3;

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
            //TODO maybe even open a thread for every client (more research on that later)
            for (int i = 1; i <= 10; i++)
            {
                if (Clients[i] ==  null)
                {
                    
                }
            }
            
            Console.WriteLine($"Incoming connection from {client.Client.RemoteEndPoint} has been accepted");
            listener.BeginAcceptTcpClient(TCPConnectCallback,null);
        }

        public void InitializeData()
        {
            
        }
    }
}
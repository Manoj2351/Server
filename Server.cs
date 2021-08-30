using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Server
    {
        public static TcpListener listener;
        public static Dictionary<int,Client> Clients = new Dictionary<int, Client>();
        public static int MaxPlayers = 3;

        public static void Start()
        {
            InitializeData();
            listener = new TcpListener(System.Net.IPAddress.Any,8888);
            listener.Start();

            listener.BeginAcceptTcpClient(TCPConnectCallback,null);
            Console.WriteLine("Starting to accept TCP clients");

        }

        public static void TCPConnectCallback(IAsyncResult _result)
        {
            TcpClient client = listener.EndAcceptTcpClient(_result);
            //TODO maybe even open a thread for every client (more research on that later)
            for (int i = 1; i <= MaxPlayers; i++)
            {
                if (Clients[i] ==  null)
                {
                    Clients[i].Tcp.Connect(client);
                    Clients[i].Tcp.SendPacket(new Packet("Welcome to server UwU"));
                    SendInput();
                }
            }
            
            
            
            Console.WriteLine($"Incoming connection from {client.Client.RemoteEndPoint} has been accepted");
            listener.BeginAcceptTcpClient(TCPConnectCallback,null);
        }

        static void InitializeData()
        {
            for (int i = 1; i <= MaxPlayers; i++)
            {
                Clients.Add(i,new Client(i));
            }
        }

        public static void SendInput()
        {
            try
            {
                Clients[1].Tcp.SendPacket(new Packet(Console.ReadLine()));
            }
            catch
            {

            }
            finally
            {
                SendInput();
            }
            
            
        }
    }
}
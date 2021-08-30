using System;
using System.Net.Sockets;


namespace Server
{
    public class Client
    {
        public int id;
        public TCP Tcp;

        public Client(int _id)
        {
            id = _id;   
        }

        public class TCP
        {
            public TcpClient Socket;
            public NetworkStream NetworkStream;
            public void Connect(TcpClient _tcpClient)
            {
                Socket = _tcpClient;
                Socket.SendBufferSize = 4096;
                Socket.ReceiveBufferSize = 4096;
                NetworkStream = Socket.GetStream();
            }

            public void SendPacket(Packet _packet)
            {
                try
                {
                    NetworkStream.Write(_packet.ConvertToArray(),0,_packet.Length());
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error sending data to {Socket.Client.RemoteEndPoint}");
                    Console.WriteLine($"Error : {e}");
                }
                
            }
        }



    }
}
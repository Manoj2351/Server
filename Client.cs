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
                    byte[] _dataToSend = Serializer.Serialize(_packet);
                    NetworkStream.Write(_dataToSend,0,_dataToSend.Length);
                    Console.WriteLine("Sent Packet");
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
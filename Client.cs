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
            public void Connect(TcpClient _tcpClient)
            {
                Socket = _tcpClient;
            }
        }



    }
}
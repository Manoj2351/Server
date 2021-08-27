using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Server
{
    public class Packet
    {
        public byte[] Message;

        public Packet(string _Message)
        {
            Message = Encoding.UTF8.GetBytes(_Message);
        }

        public Packet (byte[] _Message)
        {
            Message = _Message;
        }

        public string ConvertToString()
        {
            return Encoding.UTF8.GetString(Message);
        }


        /*TODO for now I dont have opika to implement stuff but here is a small note
        1) Add a serialization class which can take care of all the serialisation and vice versa
        2)Ig u can use the inbuilt Stream.sendbytes() func for sending and recieve bytes for recieving try 
        Experimenting

        Code snippet from stack overflow
        https://stackoverflow.com/questions/15012549/send-typed-objects-through-tcp-or-sockets
        */

    }
}

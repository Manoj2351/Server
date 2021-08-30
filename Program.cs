using System;

namespace Server
{
    class Program
    {
        public static string Input;
        static void Main(string[] args)
        {
            Console.WriteLine("Server started");
            Server.Start();
            Server.SendInput();
        }

        
    }
}

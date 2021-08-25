using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server started");
            Server.Start();
            string input = Console.ReadLine();
            if(input == "/Client")
            {
                ShowClient();    
            }
        }

        public static void ShowClient()
        {
            for (int i = 1; i <= 3;i++)
            {
                Console.WriteLine(Server.Clients[i]);
            }
            Console.ReadLine();
            
        }
    }
}

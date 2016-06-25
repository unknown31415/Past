using Past.Network.Login;
using Past.Utils;
using System;

namespace Past
{
    class Program
    {
       
        static void Main(string[] args)
        {
            ConsoleUtils.InitializeConsole();
            LoginServer.Start();
            while (true)
            {
                Console.Read();
            }
        }
    }
}

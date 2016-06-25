using Past.Utils;
using System;
using System.Collections.Generic;

namespace Past.Network.Login
{
    public class LoginServer
    {
        private static Server Login { get; set; }
        public static List<LoginClient> Clients = new List<LoginClient>();

        public static void Start()
        {
            Login = new Server("127.0.0.1", 443);
            Login.OnServerStarted += Login_OnServerStarted;
            Login.OnServerAcceptedSocket += Login_OnServerAcceptedSocket;
            Login.OnServerFailedToStart += Login_OnServerFailedToStart;
            Login.Start();
        }

        private static void Login_OnServerFailedToStart(Exception ex)
        {
            ConsoleUtils.Write(ConsoleUtils.type.ERROR, ex.ToString());
        }

        private static void Login_OnServerStarted()
        {
            ConsoleUtils.Write(ConsoleUtils.type.INFO, "LoginServer waiting for new connection ...");
        }

        private static void Login_OnServerAcceptedSocket(Client socket)
        {
            ConsoleUtils.Write(ConsoleUtils.type.INFO, "New client trying to connect to LoginServer ...");
            Clients.Add(new LoginClient(socket));
        }
    }
}

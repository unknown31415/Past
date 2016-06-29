using Past.Protocol;
using Past.Protocol.IO;
using Past.Protocol.Messages;
using Past.Utils;
using System;

namespace Past.Network.Login
{
    public class LoginClient
    {
        private Client Login { get; set; }

        public LoginClient(Client client)
        {
            Login = client;
            Login_OnClientSocketConnected();
            Login.OnClientSocketClosed += Login_OnClientSocketClosed;
            Login.OnClientReceivedData += Login_OnClientReceivedData;
        }

        private void Login_OnClientSocketConnected()
        {
            Send(new ProtocolRequired(1165, 1165));
            Send(new HelloConnectMessage(Utils.Functions.RandomString(32, true)));
        }

        private void Login_OnClientSocketClosed()
        {
            LoginServer.Clients.Remove(this);
            Login.Close();
            ConsoleUtils.Write(ConsoleUtils.type.INFO, "Client disconnected from LoginServer ...");
        }

        private void Login_OnClientReceivedData(byte[] data)
        {
            ConsoleUtils.Write(ConsoleUtils.type.RECEIV, "{0} ...", Functions.ByteArrayToString(data));
        }

        public void Send(NetworkMessage message)
        {
            try
            {
                using (BigEndianWriter writer = new BigEndianWriter())
                {
                    message.Pack(writer);
                    Login.Send(writer.Data);
                }
                ConsoleUtils.Write(ConsoleUtils.type.SEND, "{0} to client {1}:{2} ...", message.ToString(), Login.Ip, Login.Port);
            }
            catch (Exception ex)
            {
                ConsoleUtils.Write(ConsoleUtils.type.ERROR, ex.ToString());
            }
        }
    }
}

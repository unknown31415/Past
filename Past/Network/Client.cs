using System;
using System.Net;
using System.Net.Sockets;

namespace Past.Network
{
    public class Client
    {
        private Socket Socket { get; set; }
        public byte[] Buffer { get; private set; }
        public string Ip { get; private set; }
        public string Port { get; private set; }
        private readonly object Object = new object();
        public event ClientSocketConnected OnClientSocketConnected;
        public event ClientSocketClosed OnClientSocketClosed;
        public event ClientReceivedData OnClientReceivedData;
        public event ClientFailedToConnect OnClientFailedToConnect;

        public Client(Socket socket)
        {
            Socket = socket;
            Buffer = new byte[1024];
            Ip = ((IPEndPoint)(Socket.RemoteEndPoint)).Address.ToString();
            Port = ((IPEndPoint)(Socket.RemoteEndPoint)).Port.ToString();
            BeginReceive();
        }

        public void ConnectTo(string address, int port)
        {
            try
            {
                Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Socket.BeginConnect(IPAddress.Parse(address), port, new AsyncCallback(ConnectCallBack), Socket);
            }
            catch (Exception ex)
            {
                ClientFailToConnect(ex);
            }
        }

        public void Close()
        {
            lock (Object)
            {
                try
                {
                    Socket.Close();
                }
                catch
                {
                }
            }
        }

        private void ConnectCallBack(IAsyncResult ar)
        {
            try
            {
                if (Socket.Connected)
                {
                    ClientSocketConnect();
                    BeginReceive();
                }
                else
                {
                    ClientFailToConnect(new Exception("Failed"));
                }
            }
            catch (Exception)
            {
            }
        }

        public void BeginReceive()
        {
            try
            {
                Socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), Socket);
            }
            catch
            {
            }
        }

        private void ReceiveCallBack(IAsyncResult ar)
        {
            lock (Object)
            {
                try
                {
                    int num = Socket.EndReceive(ar);
                    if (num > 0)
                    {
                        byte[] data = new byte[num];
                        for (int i = 0; i <= (num - 1); i++)
                        {
                            data[i] = Buffer[i];
                        }
                        ClientReceiveData(data);
                        Buffer = new byte[1024];
                        BeginReceive();
                    }
                    else
                    {
                        ClientSocketClose();
                    }
                }
                catch (Exception)
                {
                    ClientSocketClose();
                }
            }
        }

        public void Send(byte[] data)
        {
            lock (Object)
            {
                try
                {
                    Socket.Send(data);
                }
                catch (Exception)
                {
                }
            }
        }

        private void ClientReceiveData(byte[] data)
        {
            if (OnClientReceivedData != null)
                OnClientReceivedData(data);
        }

        private void ClientSocketClose()
        {
            if (OnClientSocketClosed != null)
                OnClientSocketClosed();
        }

        private void ClientFailToConnect(Exception ex)
        {
            if (OnClientFailedToConnect != null)
                OnClientFailedToConnect(ex);
        }

        private void ClientSocketConnect()
        {
            if (OnClientSocketConnected != null)
                OnClientSocketConnected();
        }

        public delegate void ClientReceivedData(byte[] data);

        public delegate void ClientFailedToConnect(Exception ex);

        public delegate void ClientSocketConnected();

        public delegate void ClientSocketClosed();
    }
}

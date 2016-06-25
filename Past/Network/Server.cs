using Past.Utils;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Past.Network
{
    public class Server
    {
        private Socket Socket { get; set; }
        public string Address { get; private set; }
        public int Port { get; private set; }
        public bool IsRunning { get; private set; }
        public event Action OnServerStopped;
        public event Action OnServerStarted;
        public event ServerFailedToStart OnServerFailedToStart;
        public event ServerAcceptedSocket OnServerAcceptedSocket;
        private readonly object Object = new object();

        public Server(string address, int port)
        {
            Address = address;
            Port = port;
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            if (!IsRunning)
            {
                try
                {
                    IsRunning = true;
                    Socket.Bind(new IPEndPoint(IPAddress.Parse(Address), Port));
                    Socket.Listen(100);
                    new Thread(new ThreadStart(this.AcceptThread)).Start();
                    ServerStart();
                }
                catch (Exception ex)
                {
                    ServerFailToStart(ex);
                }
            }
            else
                ConsoleUtils.Write(ConsoleUtils.type.ERROR, "Server is already running on {0}:{1} ...", Address, Port);
        }

        public void Stop()
        {
            if (IsRunning)
            {
                IsRunning = false;
                Socket.Shutdown(SocketShutdown.Both);
                ServerStop();
            }
            else
                ConsoleUtils.Write(ConsoleUtils.type.ERROR, "Can't close the server is not running ...");
        }

        private void AcceptThread()
        {
            lock (Object)
            {
                try
                {
                    Socket.BeginAccept(new AsyncCallback(this.AcceptCallBack), Socket);
                }
                catch (Exception)
                {
                    this.AcceptThread();
                }
            }
        }

        private void AcceptCallBack(IAsyncResult ar)
        {
            lock (Object)
            {
                try
                {
                    Client socket = new Client(Socket.EndAccept(ar));
                    ServerAcceptSocket(socket);
                    AcceptThread();
                }
                catch (Exception)
                {
                    AcceptThread();
                }
            }
        }

        private void ServerStart()
        {
            if (OnServerStarted != null)
                OnServerStarted();
        }

        private void ServerStop()
        {
            if (OnServerStopped != null)
                OnServerStopped();
        }

        private void ServerFailToStart(Exception ex)
        {
            if (OnServerFailedToStart != null)
                OnServerFailedToStart(ex);
        }

        private void ServerAcceptSocket(Client socket)
        {
            if (OnServerAcceptedSocket != null)
                OnServerAcceptedSocket(socket);
        }

        public delegate void ServerFailedToStart(Exception ex);

        public delegate void ServerAcceptedSocket(Client socket);
    }
}

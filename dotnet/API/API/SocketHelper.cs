using Quobject.SocketIoClientDotNet.Client;

namespace API
{
    public static class SocketHelper
    {
        private static readonly Socket SharedSocket;

        static SocketHelper()
        {
            SharedSocket = SetupSharedSocket();
        }

        public static Socket GetSocket()
        {
            return SharedSocket;
        }

        private static Socket SetupSharedSocket()
        {
            return IO.Socket("http://localhost:3000");
        }
    }
}
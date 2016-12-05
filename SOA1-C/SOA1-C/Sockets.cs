using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
namespace SOA1_C
{
    class Sockets
    {
        private string _sIP;
        private int _port;
        private IPAddress _IP;
        public bool runSocket;
        public string sIP
        {
            get
            {
                return _sIP;
            }
            set
            {
                _sIP = value;
            }
        }

        public int port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
            }
        }
        public void startSocket()
        {
            runSocket = true;


            while (runSocket)
            {
                try
                {
                    IPAddress ipAd = IPAddress.Parse("10.113.21.163");
                    port = 2693;
                    // use local m/c IP address, and 
                    // use the same in the client

                    /* Initializes the Listener */
                    TcpListener myList = new TcpListener(ipAd, _port);

                    /* Start Listeneting at the specified port */
                    myList.Start();
                    Socket s = myList.AcceptSocket();
                    byte[] b = new byte[1000];
                    int k = s.Receive(b);
                    for (int i = 0; i < k; i++)
                        Console.Write(Convert.ToChar(b[i]));

                    ASCIIEncoding asen = new ASCIIEncoding();
                    s.Send(asen.GetBytes("The string was recieved by the server."));
                    s.Close();
                    myList.Stop();
                }
                catch (Exception e)
                {
                    Logger.Log("Error..... " + e.StackTrace);
                    Console.WriteLine("Error..... " + e.StackTrace);

                }
            }
        }

    }
}

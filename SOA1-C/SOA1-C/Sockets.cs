////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	sockets.cs
//
// summary:	Implements the sockets class
// 
//  TEAM : WES , JEN, Niels , Alex
////////////////////////////////////////////////////////////////////////////////////////////////////

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
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A sockets. </summary>
    ///
    ///  
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class Sockets
    {
        /// <summary>   The IP. </summary>
        private string _sIP;
        /// <summary>   The port. </summary>
        private int _port;
        /// <summary>   The IP. </summary>
        private IPAddress _IP;
        /// <summary>   True to run socket. </summary>
        public bool runSocket;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the IP. </summary>
        ///
        /// <value> The s IP. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the port. </summary>
        ///
        /// <value> The port. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Starts a socket. </summary>
        ///
        ///  
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

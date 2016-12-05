using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Configuration;
namespace SOA_pt
{
    class Sockets
    {
        private string _sIP;
        private int _port;

        public bool runSocket;
        HL7Builder stringBuilder = new HL7Builder();
        public DRCstruct DRCs = new DRCstruct();
        public INFstruct INFs = new INFstruct();
        public SOAstruct SOAs = new SOAstruct();
        public SRVstruct SRVs = new SRVstruct();
        public ARGstruct ARGs = new ARGstruct();
        public MCHstruct MCHs = new MCHstruct();
        public RSPstruct RSPs = new RSPstruct();
        public PUBstruct PUBs = new PUBstruct();
        service srvtemp = new service();
        SOATalker SOAtalker = new SOATalker();
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
        public void startSocket(string teamID)
        {
            runSocket = true;


            while (runSocket)
            {
                try
                {
                    IPAddress ipAd = IPAddress.Parse("10.113.21.163");
                    port = 50002;
                    // use local m/c IP address, and 
                    // use the same in the client
                    string[] words = { "", "", "", "", "", "", "", };
                    /* Initializes the Listener */
                    TcpListener myList = new TcpListener(ipAd, _port);

                    /* Start Listeneting at the specified port */
                    myList.Start();
                    Socket s = myList.AcceptSocket();
                    byte[] b = new byte[1000];
                    int k = s.Receive(b);

                    string message = "";
                    for (int i = 0; i < k; i++)
                    {
                        message += Convert.ToChar(b[i]);
                    }
                    stringBuilder.breakingUpString(message);
                    if (!(SOAtalker.queryTeam(ConfigurationManager.AppSettings["teamName"], teamID, ConfigurationManager.AppSettings["serviceName"])))
                    {
                        PUBs.allGood = "NOT-OK";
                        PUBs.errorCode = SOAtalker.tempSOA.errorCode;
                        PUBs.errorMessage = SOAtalker.tempSOA.errorMessage;
                        words[0] = stringBuilder.PUBBuilder(PUBs);
                    }
                    else
                    {

                        if (srvtemp.setProvince(stringBuilder.argList[0].value))
                        {


                            if (srvtemp.setValue(stringBuilder.argList[1].value))

                            {
                                PUBs.allGood = "OK";
                                PUBs.numSegments = "6";
                                words[0] = stringBuilder.PUBBuilder(PUBs);

                                RSPs.position = "1";
                                RSPs.name = "subtotal";
                                RSPs.DataType = "DOUBLE";
                                RSPs.value = srvtemp.getSubTotal().ToString();
                                words[1] = stringBuilder.RSPBuilder(RSPs);

                                RSPs.position = "2";
                                RSPs.name = "PST";
                                RSPs.DataType = "DOUBLE";
                                RSPs.value = srvtemp.getPST().ToString();
                                words[2] = stringBuilder.RSPBuilder(RSPs);

                                RSPs.position = "3";
                                RSPs.name = "GST";
                                RSPs.DataType = "DOUBLE";
                                RSPs.value = srvtemp.getGST().ToString();
                                words[3] = stringBuilder.RSPBuilder(RSPs);

                                RSPs.position = "4";
                                RSPs.name = "HST";
                                RSPs.DataType = "DOUBLE";
                                RSPs.value = srvtemp.getHST().ToString();
                                words[4] = stringBuilder.RSPBuilder(RSPs);

                                RSPs.position = "5";
                                RSPs.name = "Total";
                                RSPs.DataType = "DOUBLE";
                                RSPs.value = srvtemp.getTotal().ToString();
                                words[5] = stringBuilder.RSPBuilder(RSPs);
                            }
                            else
                            {
                                PUBs.allGood = "NOT-OK";
                                PUBs.errorCode = "69";
                                PUBs.errorMessage = "Bad Value could  not work with";
                                words[0] = stringBuilder.PUBBuilder(PUBs);
                            }
                        }
                        else
                        {
                            PUBs.allGood = "NOT-OK";
                            PUBs.errorCode = "70";
                            PUBs.errorMessage = "Bad province could  not work with";
                            words[0] = stringBuilder.PUBBuilder(PUBs);
                        }
                    }
                    string allWords = "";
                    int BOMunicode = 11;
                    int EOSunicode = 13;
                    int EOMunicode = 28;
                    char BOM = (char)BOMunicode;
                    char EOS = (char)EOSunicode;
                    char EOM = (char)EOMunicode;


                    allWords += BOM;
                    foreach (string st in words)
                    {
                        if (st == "")
                        {
                            break;
                        }
                        allWords += st;
                        allWords += EOS;
                    }
                    allWords += EOM;
                    allWords += EOS;



                    ASCIIEncoding asen = new ASCIIEncoding();
                    s.Send(asen.GetBytes(allWords));
                    s.Close();
                    myList.Stop();

                }
                catch (Exception e)
                {

                    Console.WriteLine("Error..... " + e.StackTrace);

                }
            }
        }

    }
}

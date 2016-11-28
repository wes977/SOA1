using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace SOA_pt
{
    class SOATalker
    {
        private string _IP = "localhost";
        private int _Port = 3128;

        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }
        public int port
        {
            get { return _Port; }
            set { _Port = value; }
        }

        public string  talkToSOA(string[] words)
        {
            string returner = "";
            string allWords = "";
            int BOMunicode = 11;
            int EOSunicode = 13;
            int EOMunicode = 28;
            char BOM = (char)BOMunicode;
            char EOS = (char)EOSunicode;
            char EOM = (char)EOMunicode;

            try
            {

                TcpClient tcpclnt = new TcpClient();
                tcpclnt.Connect(_IP, _Port);

                allWords += BOM;
                foreach (string s in  words)
                {
                    if (s =="")
                    {
                        break;
                    }
                    allWords += s;
                    allWords += EOS;
                }
                allWords += EOM;
                allWords += EOS;

                
                Stream stm = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(allWords); // Sending it all to bytes so I can send that shit 

                stm.Write(ba, 0, ba.Length);

                byte[] bb = new byte[100];
                int k = stm.Read(bb, 0, 100);

                for (int i = 0; i < k; i++)
                {
                    returner += Convert.ToChar(bb[i]);
                }                
                tcpclnt.Close();
            }

            catch (Exception e)
            {
               returner +=  string.Format("Error..... " + e.StackTrace);
            }
            return returner;

        }
        public void SOAtalking(string[] things)
        {
            DRCstruct DRCtemp = new DRCstruct();
            INFstruct INFtemp = new INFstruct();
            SOAstruct SOAtemp = new SOAstruct();
            SRVstruct SRVtemp = new SRVstruct();
            ARGstruct ARGtemp = new ARGstruct();
            MCHstruct MCHtemp = new MCHstruct();
            RSPstruct RSPtemp = new RSPstruct();
            PUBstruct PUBtemp = new PUBstruct();

            HL7Builder tempHL = new HL7Builder();
            SOATalker temp = new SOATalker();

            switch (tempHL.HLStringDebuilder(temp.talkToSOA(things)))
            {
                case commandType.DRC:

                    break;
                case commandType.INF:

                    break;
                case commandType.SOA:
                    Console.WriteLine(tempHL.SOAs.allGood);
                    Console.WriteLine(tempHL.SOAs.errorCode);
                    Console.WriteLine(tempHL.SOAs.errorMessage);
                    Console.WriteLine(tempHL.SOAs.numSegments);
                    break;
                case commandType.SRV:

                    break;
                case commandType.ARG:

                    break;
                case commandType.MCH:

                    break;
                case commandType.RSP:

                    break;
                case commandType.PUB:

                    break;
            }
        }



    }
}

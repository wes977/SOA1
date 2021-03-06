﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	soatalker.cs
//
// summary:	Implements the soatalker class
// 
//  TEAM : WES , JEN, Niels , Alex
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace SOA1_C
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A soa talker. </summary>
    ///
    ///  
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class SOATalker
    {
        /// <summary>   The IP. </summary>
        private string _IP = "";
        /// <summary>   The port. </summary>
        private int _Port = 3128;
        /// <summary>   Message describing the error. </summary>
        public string errorMsg;
        /// <summary>   The temporary hl. </summary>
        public HL7Builder tempHL = new HL7Builder();
        /// <summary>   The pu bs. </summary>
        public PUBstruct PUBs = new PUBstruct();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the IP. </summary>
        ///
        /// <value> The IP. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the port. </summary>
        ///
        /// <value> The port. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int port
        {
            get { return _Port; }
            set { _Port = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Talk to soa. </summary>
        ///
        ///  
        ///
        /// <param name="words">    The words. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string talkToSOA(string[] words)
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
                foreach (string s in words)
                {
                    if (s == "")
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
                byte[] ba = asen.GetBytes(allWords); // Sending it all to bytes so I can send that shit adsf

                stm.Write(ba, 0, ba.Length);

                byte[] bb = new byte[1000];
                int k = stm.Read(bb, 0, 1000);

                for (int i = 0; i < k; i++)
                {
                    returner += Convert.ToChar(bb[i]);
                }
                tcpclnt.Close();
                Logger.Log("Response \r\n ");
            }

            catch (Exception e)
            {
                //returner += string.Format("Error..... " + e.StackTrace);
                errorMsg = string.Format("Error..... " + e.StackTrace);
                returner = "";
                Logger.Log("Error..... " + e.StackTrace);
            }
            return returner;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   So atalking. </summary>
        ///
        ///  
        ///
        /// <param name="things">   The things. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool SOAtalking(string[] things)
        {
            bool returner = false;
            DRCstruct DRCtemp = new DRCstruct();
            INFstruct INFtemp = new INFstruct();
            SOAstruct SOAtemp = new SOAstruct();
            SRVstruct SRVtemp = new SRVstruct();
            ARGstruct ARGtemp = new ARGstruct();
            MCHstruct MCHtemp = new MCHstruct();
            RSPstruct RSPtemp = new RSPstruct();
            PUBstruct PUBtemp = new PUBstruct();


            switch (tempHL.breakingUpString(talkToSOA(things)))
            {

                case commandType.SOA:
                    PUBs.allGood = tempHL.PUBs.allGood;
                    PUBs.errorCode = tempHL.PUBs.errorCode;
                    PUBs.errorMessage = tempHL.PUBs.errorMessage;
                    returner = true;
                    break;
                case commandType.PUB:
                    PUBs.allGood = tempHL.PUBs.allGood;
                    PUBs.errorCode = tempHL.PUBs.errorCode;
                    PUBs.errorMessage = tempHL.PUBs.errorMessage;
                    returner = true;
                    break;
                default:
                    returner = false;
                    break;

            }
            return returner;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Registers the team described by newName. </summary>
        ///
        ///  
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool regTeam()
        {

            Logger.Log("Registering a Team to the Registry ");
            DRCstruct DRCtemp = new DRCstruct();
            INFstruct INFtemp = new INFstruct();
            HL7Builder tempHL = new HL7Builder();

            string[] tempWords =
            {
                "","","","","","","","","",""
            };


            // Registerig the team fromt he service and all that 
            INFtemp.teamName = "WestNet";
            tempWords[0] = tempHL.DRCBuilder(DRCtemp, registryCommands.REG);
            tempWords[1] = tempHL.INFBuilder(INFtemp);
            SOAtalking(tempWords);
            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Registers the team described by newName. </summary>
        ///
        ///  
        ///
        /// <param name="newName">  Name of the new. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool regTeam(string newName)
        {
            DRCstruct DRCtemp = new DRCstruct();
            INFstruct INFtemp = new INFstruct();
            HL7Builder tempHL = new HL7Builder();
            Logger.Log("Registering a Team to the Registry ");
            string[] tempWords =
            {
                "","","","","","","","","",""
            };


            // Registerig the team fromt he service and all that 
            INFtemp.teamName = newName;
            tempWords[0] = tempHL.DRCBuilder(DRCtemp, registryCommands.REG);
            tempWords[1] = tempHL.INFBuilder(INFtemp);
            SOAtalking(tempWords);
            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Determines if we can unreg team. </summary>
        ///
        ///  
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool unregTeam()
        {
            DRCstruct DRCtemp = new DRCstruct();
            HL7Builder tempHL = new HL7Builder();
            Logger.Log("Unregistrying a team ");
            string[] tempWords =
            {
                ""
            };


            // Registerig the team fromt he service and all that 
            DRCtemp.teamName = "WestNet";
            DRCtemp.teamID = "1189";
            tempWords[0] = tempHL.DRCBuilder(DRCtemp, registryCommands.UNREG);

            SOAtalking(tempWords);
            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Queries a team. </summary>
        ///
        ///  
        ///
        /// <param name="teamName">     Name of the team. </param>
        /// <param name="teamID">       Identifier for the team. </param>
        /// <param name="serviceTag">   The service tag. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool queryTeam(string teamName, string teamID, string serviceTag)
        {
            Logger.Log("Querying a team ");
            DRCstruct DRCtemp = new DRCstruct();
            INFstruct INFtemp = new INFstruct();
            HL7Builder tempHL = new HL7Builder();

            string[] tempWords =
            {
                "","","","","","","","","",""
            };


            // Registerig the team fromt he service and all that 
            DRCtemp.teamName = "WestNet";
            DRCtemp.teamID = "1186";
            INFtemp.teamName = teamName;
            INFtemp.teamID = teamID;
            INFtemp.serviceTag = serviceTag;
            tempWords[0] = tempHL.DRCBuilder(DRCtemp, registryCommands.QUERY);
            tempWords[1] = tempHL.INFBuilder(INFtemp);
            SOAtalking(tempWords);
            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Queries a service. </summary>
        ///
        ///  
        ///
        /// <param name="serviceTag">   The service tag. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool queryService(string serviceTag)
        {
            DRCstruct DRCtemp = new DRCstruct();
            SRVstruct SRVtemp = new SRVstruct();
            HL7Builder tempHL = new HL7Builder();
            Logger.Log("Querying a service ");
            string[] tempWords =
            {
                "","","","","","","","","",""
            };


            // Registerig the team fromt he service and all that 
            DRCtemp.teamName = "WestNet";
            DRCtemp.teamID = "1189";

            SRVtemp.teamName = serviceTag;


            tempWords[0] = tempHL.DRCBuilder(DRCtemp, registryCommands.QUERY_SERVICE);
            tempWords[1] = tempHL.SRVBuilder(SRVtemp);
            SOAtalking(tempWords);
            return true;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Queries a service. </summary>
        ///
        ///  
        ///
        /// <param name="serviceTag">   The service tag. </param>
        /// <param name="teamName">     Name of the team. </param>
        /// <param name="teamID">       Identifier for the team. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool queryService(string serviceTag, string teamName, string teamID)
        {
            DRCstruct DRCtemp = new DRCstruct();
            SRVstruct SRVtemp = new SRVstruct();
            HL7Builder tempHL = new HL7Builder();
            Logger.Log("Querying a service ");
            string[] tempWords =
            {
                "","","","","","","","","",""
            };


            // Registerig the team fromt he service and all that 
            DRCtemp.teamName = teamName;
            DRCtemp.teamID = teamID;
            SRVtemp.teamName = serviceTag;


            tempWords[0] = tempHL.DRCBuilder(DRCtemp, registryCommands.QUERY_SERVICE);
            tempWords[1] = tempHL.SRVBuilder(SRVtemp);
            SOAtalking(tempWords);
            return true;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the service operation. </summary>
        ///
        ///  
        ///
        /// <param name="teamID">       Identifier for the team. </param>
        /// <param name="teamName">     Name of the team. </param>
        /// <param name="serviceName">  Name of the service. </param>
        /// <param name="numArgs">      Number of arguments. </param>
        /// <param name="args">         The arguments. </param>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string execService(string teamID, string teamName, string serviceName, string numArgs, ARGstruct[] args)
        {
            Logger.Log("Executing a service ");
            DRCstruct DRCtemp = new DRCstruct();
            SRVstruct SRVtemp = new SRVstruct();
            HL7Builder tempHL = new HL7Builder();
            string returner = "";
            string[] tempWords =
            {
                "","","","","","","","","",""
            };


            // Registerig the team fromt he service and all that 
            DRCtemp.teamName = teamName;
            DRCtemp.teamID = teamID;

            SRVtemp.serviceName = serviceName;
            SRVtemp.numARGS = numArgs;
            tempWords[0] = tempHL.DRCBuilder(DRCtemp, registryCommands.EXEC_SERVICE);
            tempWords[1] = tempHL.SRVBuilder(SRVtemp);
            int counter = 2;
            foreach (ARGstruct a in args)
            {
                tempWords[counter] = tempHL.ARGBuilder(a);
                counter++;
            }


            SOAtalking(tempWords);
            if (PUBs.allGood == "NOT-OK")
            {

                returner += "ERROR code(" + PUBs.errorCode + ")  " + PUBs.errorMessage + "!";
            }


            return returner;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Determines if we can publish service. </summary>
        ///
        ///  
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool publishService()
        {
            Logger.Log("Publiching a service ");
            bool returner = false;
            string[] tempWords =
            {
                "","","","","","","","","",""
            };


            HL7Builder tempHL = new HL7Builder();
            DRCstruct DRCtemp = new DRCstruct();
            SRVstruct SRVtemp = new SRVstruct();
            ARGstruct ARGtemp = new ARGstruct();
            MCHstruct MCHtemp = new MCHstruct();
            RSPstruct RSPtemp = new RSPstruct();


            //publiching the thing and all that
            DRCtemp.teamName = "WestNet";
            DRCtemp.teamID = "1186";
            tempWords[0] = tempHL.DRCBuilder(DRCtemp, registryCommands.PUB_SERVICE);

            // All the service information 
            SRVtemp.teamName = "GIORP-TOTAL";
            SRVtemp.serviceName = "giorpTotaller";
            SRVtemp.securityLevel = "1";
            SRVtemp.numARGS = "2";
            SRVtemp.numResponses = "5";
            SRVtemp.description = "This totals the purchase and all that jazz";
            tempWords[1] = tempHL.SRVBuilder(SRVtemp);
            // ARGS
            ARGtemp.argPosition = "1";
            ARGtemp.argName = "province";
            ARGtemp.argDataType = "string";
            ARGtemp.argManOpt = "mandatory";
            tempWords[2] = tempHL.ARGBuilder(ARGtemp);

            ARGtemp.argPosition = "2";
            ARGtemp.argName = "value";
            ARGtemp.argDataType = "double";
            ARGtemp.argManOpt = "mandatory";
            tempWords[3] = tempHL.ARGBuilder(ARGtemp);

            // RSP
            RSPtemp.position = "1";
            RSPtemp.name = "subTotal";
            RSPtemp.DataType = "double";
            RSPtemp.value = "";
            tempWords[4] = tempHL.RSPBuilder(RSPtemp);

            RSPtemp.position = "2";
            RSPtemp.name = "PST";
            RSPtemp.DataType = "double";
            RSPtemp.value = "";
            tempWords[5] = tempHL.RSPBuilder(RSPtemp);

            RSPtemp.position = "3";
            RSPtemp.name = "HST";
            RSPtemp.DataType = "double";
            RSPtemp.value = "";
            tempWords[6] = tempHL.RSPBuilder(RSPtemp);

            RSPtemp.position = "4";
            RSPtemp.name = "GST";
            RSPtemp.DataType = "double";
            RSPtemp.value = "";
            tempWords[7] = tempHL.RSPBuilder(RSPtemp);

            RSPtemp.position = "5";
            RSPtemp.name = "Total";
            RSPtemp.DataType = "double";
            RSPtemp.value = "";
            tempWords[8] = tempHL.RSPBuilder(RSPtemp);

            // MCH
            MCHtemp.IP = "10.113.21.163";
            MCHtemp.port = "2693";
            tempWords[9] = tempHL.MCHBuilder(MCHtemp);

            // Sending it  asdf
            return SOAtalking(tempWords);
        }



    }
}

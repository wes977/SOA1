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
using System.Configuration;
namespace SOA_pt
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A soa talker. </summary>
    ///
    ///  
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class SOATalker
    {
        /// <summary>   The IP. </summary>
        private string _IP = ConfigurationManager.AppSettings["SOAIP"];
        /// <summary>   The port. </summary>
        private int _Port = Int32.Parse(ConfigurationManager.AppSettings["SOAPort"]);

        /// <summary>   Identifier for the team. </summary>
        public string teamID;
        /// <summary>   The temporary soa. </summary>
        public SOAstruct tempSOA;

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
                Logger.Log("Response \r\n " + returner);
                tcpclnt.Close();
            }

            catch (Exception e)
            {
                returner += string.Format("Error..... " + e.StackTrace);
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


            HL7Builder tempHL = new HL7Builder();
            SOATalker temp = new SOATalker();

            switch (tempHL.HLStringDebuilder(temp.talkToSOA(things)))
            {

                case commandType.SOA:
                    Console.WriteLine("Status:" +tempHL.SOAs.allGood);
                    Console.WriteLine("Team ID / Error code:"+tempHL.SOAs.errorCode);
                    Console.WriteLine("Error Message:"+tempHL.SOAs.errorMessage);
                    Console.WriteLine("Num Segments:"+tempHL.SOAs.numSegments);

                    tempSOA = tempHL.SOAs;
                    if (tempHL.SOAs.errorCode != "")
                    {
                        if (Int32.Parse(tempHL.SOAs.errorCode) > 0)
                        {
                            teamID = tempHL.SOAs.errorCode;
                        }
                    }
                    //tName = tempHL.SOAs.errorMessage;
                    tempHL.SOAerrorChecker();
                    tempHL.PUBerrorChecker();
                    
                    break;
                default:
                    
                    break;

            }

            if (tempHL.SOAs.allGood == "OK")
            {
                returner = true;
            }
            else
            {
                returner = false;
            }
            return returner;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Registers the team described by teamName. </summary>
        ///
        ///  
        ///
        /// <param name="teamName"> Name of the team. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool regTeam(string teamName)
        {
            DRCstruct DRCtemp = new DRCstruct();
            INFstruct INFtemp = new INFstruct();
            HL7Builder tempHL = new HL7Builder();

            string[] tempWords =
            {
                "","","","","","","","","",""
            };


            // Registerig the team fromt he service and all that 
            INFtemp.teamName = teamName;
            tempWords[0] = tempHL.DRCBuilder(DRCtemp, registryCommands.REG);
            tempWords[1] = tempHL.INFBuilder(INFtemp);
            SOAtalking(tempWords);
            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Unreg team. </summary>
        ///
        ///  
        ///
        /// <param name="tName">    The name. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool unregTeam(string tName)
        {
            DRCstruct DRCtemp = new DRCstruct();
            HL7Builder tempHL = new HL7Builder();

            string[] tempWords =
            {
                ""
            };


            // Registerig the team fromt he service and all that 
            DRCtemp.teamName = tName;
            DRCtemp.teamID = teamID;
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

        public bool queryTeam(string teamName , string teamID,string serviceTag)
        {
            DRCstruct DRCtemp = new DRCstruct();
            INFstruct INFtemp = new INFstruct();
            HL7Builder tempHL = new HL7Builder();
            
            string[] tempWords =
            {
                "","","","","","","","","",""
            };
            Logger.Log(">> QUERYING TEAM");

            // Registerig the team fromt he service and all that 
            DRCtemp.teamName = teamName;
            DRCtemp.teamID = teamID;
            INFtemp.teamName = teamName;
            INFtemp.teamID = teamID;
            INFtemp.serviceTag = serviceTag;
            tempWords[0] = tempHL.DRCBuilder(DRCtemp, registryCommands.QUERY);
            tempWords[1] = tempHL.INFBuilder(INFtemp);
            SOAtalking(tempWords);
            if (SOAtalking(tempWords))
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Queries a service. </summary>
        ///
        ///  
        ///
        /// <param name="serviceTag">   The service tag. </param>
        /// <param name="tName">        The name. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool queryService(string serviceTag,string tName)
        {
            DRCstruct DRCtemp = new DRCstruct();
            SRVstruct SRVtemp = new SRVstruct();
            HL7Builder tempHL = new HL7Builder();

            string[] tempWords =
            {
                "","","","","","","","","",""
            };


            // Registerig the team fromt he service and all that 
            DRCtemp.teamName = tName;
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
        /// <param name="serviceName">  Name of the service. </param>
        /// <param name="numArgs">      Number of arguments. </param>
        /// <param name="args">         The arguments. </param>
        /// <param name="tName">        The name. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool execService(string serviceName , string numArgs , ARGstruct[] args,string tName)
        {
            DRCstruct DRCtemp = new DRCstruct();
            SRVstruct SRVtemp = new SRVstruct();
            HL7Builder tempHL = new HL7Builder();

            string[] tempWords =
            {
                "","","","","","","","","",""
            };


            // Registerig the team fromt he service and all that 
            DRCtemp.teamName = tName;
            DRCtemp.teamID = teamID;

            SRVtemp.serviceName = serviceName;
            SRVtemp.numARGS = numArgs;
            tempWords[0] = tempHL.DRCBuilder(DRCtemp, registryCommands.EXEC_SERVICE);
            tempWords[1] = tempHL.SRVBuilder(SRVtemp);
            int counter = 0;
            foreach (ARGstruct a in args)
            {
                tempWords[counter] = tempHL.ARGBuilder(a);
                counter++;
            }


            SOAtalking(tempWords);
            return true;
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
            DRCtemp.teamName = ConfigurationManager.AppSettings["teamName"];
            DRCtemp.teamID = teamID;
            tempWords[0] = tempHL.DRCBuilder(DRCtemp, registryCommands.PUB_SERVICE);

            // All the service information 
            SRVtemp.teamName = ConfigurationManager.AppSettings["ServiceName"];
            SRVtemp.serviceName = ConfigurationManager.AppSettings["ServiceTagName"];
            SRVtemp.securityLevel = ConfigurationManager.AppSettings["SecLevel"];
            SRVtemp.numARGS = ConfigurationManager.AppSettings["NumArgs"];
            SRVtemp.numResponses = ConfigurationManager.AppSettings["NumResp"];
            SRVtemp.description = ConfigurationManager.AppSettings["ServiceDesc"]; 
            tempWords[1] = tempHL.SRVBuilder(SRVtemp);
            // ARGS
            ARGtemp.argPosition = ConfigurationManager.AppSettings["arg1Position"];
            ARGtemp.argName = ConfigurationManager.AppSettings["arg1Name"];
            ARGtemp.argDataType = ConfigurationManager.AppSettings["arg1DataType"];
            ARGtemp.argManOpt = ConfigurationManager.AppSettings["arg1ManOpt"];
            tempWords[2] = tempHL.ARGBuilder(ARGtemp);

            ARGtemp.argPosition = ConfigurationManager.AppSettings["arg2Position"];
            ARGtemp.argName = ConfigurationManager.AppSettings["arg2Name"];
            ARGtemp.argDataType = ConfigurationManager.AppSettings["arg2DataType"];
            ARGtemp.argManOpt = ConfigurationManager.AppSettings["arg2ManOpt"];
            tempWords[3] = tempHL.ARGBuilder(ARGtemp);

            // RSP
            RSPtemp.position = ConfigurationManager.AppSettings["rsp1Position"];
            RSPtemp.name = ConfigurationManager.AppSettings["rsp1Name"];
            RSPtemp.DataType = ConfigurationManager.AppSettings["rsp1DataType"];
            RSPtemp.value = ConfigurationManager.AppSettings["rsp1value"];
            tempWords[4] = tempHL.RSPBuilder(RSPtemp);

            RSPtemp.position = ConfigurationManager.AppSettings["rsp2Position"];
            RSPtemp.name = ConfigurationManager.AppSettings["rsp2Name"];
            RSPtemp.DataType = ConfigurationManager.AppSettings["rsp2DataType"];
            RSPtemp.value = ConfigurationManager.AppSettings["rsp2value"];
            tempWords[5] = tempHL.RSPBuilder(RSPtemp);

            RSPtemp.position = ConfigurationManager.AppSettings["rsp3Position"];
            RSPtemp.name = ConfigurationManager.AppSettings["rsp3Name"];
            RSPtemp.DataType = ConfigurationManager.AppSettings["rsp3DataType"];
            RSPtemp.value = ConfigurationManager.AppSettings["rsp3value"];
            tempWords[6] = tempHL.RSPBuilder(RSPtemp);

            RSPtemp.position = ConfigurationManager.AppSettings["rsp4Position"];
            RSPtemp.name = ConfigurationManager.AppSettings["rsp4Name"];
            RSPtemp.DataType = ConfigurationManager.AppSettings["rsp4DataType"];
            RSPtemp.value = ConfigurationManager.AppSettings["rsp4value"];
            tempWords[7] = tempHL.RSPBuilder(RSPtemp);

            RSPtemp.position = ConfigurationManager.AppSettings["rsp5Position"];
            RSPtemp.name = ConfigurationManager.AppSettings["rsp5Name"];
            RSPtemp.DataType = ConfigurationManager.AppSettings["rsp5DataType"];
            RSPtemp.value = ConfigurationManager.AppSettings["rsp5value"];
            tempWords[8] = tempHL.RSPBuilder(RSPtemp);

            // MCH
            MCHtemp.IP = ConfigurationManager.AppSettings["IPm"];
            MCHtemp.port = ConfigurationManager.AppSettings["Portm"];
            tempWords[9] = tempHL.MCHBuilder(MCHtemp);

            // Sending it  asdf
            return SOAtalking(tempWords);
        }



    }
}

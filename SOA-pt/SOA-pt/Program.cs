using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace SOA_pt
{
    class Program
    {

        static void Main(string[] args)
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

            string[] tempWords =
            {
                "","","","","","","","","",""
            };


            // Registerig the team fromt he service and all that 
            INFtemp.teamName = "WestNet";
            tempWords[0] = tempHL.DRCBuilder(DRCtemp, registryCommands.REG);
            tempWords[1] = tempHL.INFBuilder(INFtemp);
            temp.SOAtalking(tempWords);
   

            // Publishing the service 

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
            MCHtemp.IP = "10.113.21.147";
            MCHtemp.port = "50002";
            tempWords[9] = tempHL.MCHBuilder(MCHtemp);

            // Sending it  asdf
            temp.SOAtalking(tempWords);

            Console.ReadLine();
        }


    }
}

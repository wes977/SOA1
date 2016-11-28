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
            SRVtemp.teamName = "PT";
            SRVtemp.serviceName = "PT-SERVICE";
            SRVtemp.securityLevel = "1";
            SRVtemp.numARGS = "2";
            SRVtemp.numResponses = "5";
            SRVtemp.description = "This totals the purchase and all that jazz";
            tempWords[1] = tempHL.SRVBuilder(SRVtemp);
            // ARGS
            ARGtemp.argPosition = "1";
            ARGtemp.argName = "";
            ARGtemp.argDataType = "";
            ARGtemp.argManOpt = "";
            tempWords[2] = tempHL.ARGBuilder(ARGtemp);

            ARGtemp.argPosition = "2";
            ARGtemp.argName = "";
            ARGtemp.argDataType = "";
            ARGtemp.argManOpt = "";
            tempWords[3] = tempHL.ARGBuilder(ARGtemp);

            // RSP


            // MCH

            tempWords[1] = tempHL.INFBuilder(INFtemp);
            temp.SOAtalking(tempWords);

            Console.ReadLine();
        }


    }
}

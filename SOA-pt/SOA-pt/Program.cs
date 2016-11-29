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

            temp.publishService();



            Console.ReadLine();
        }


    }
}

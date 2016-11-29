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

            SOATalker temp = new SOATalker();
            Sockets listener = new Sockets();


            // Registering the Team and all that jazz 
            temp.regTeam();
            // Publishing the service and all that 
            temp.publishService();
         //   listener.startSocket();
            //temp.queryService("GIORP-TOTAL");
            //temp.queryTeam("WestNet", "1186", "GIORP-TOTAL");
            Console.ReadLine();
        }


    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Configuration;

namespace SOA_pt
{
    class Program
    {

        static void Main(string[] args)
        {

            SOATalker temp = new SOATalker();
            Sockets listener = new Sockets();
            
            string configvalue1 = ConfigurationManager.AppSettings["countoffiles"];
            temp.IP = ConfigurationManager.AppSettings["IP"];
            temp.port = Int32.Parse( ConfigurationManager.AppSettings["Port"]);
            string tName = ConfigurationManager.AppSettings["teamName"];
            // Registering the Team and all that jazz 
            temp.regTeam(tName);

            // Publishing the service and all that 
            temp.publishService();

            listener.startSocket(temp.teamID);
            //temp.queryService("GIORP-TOTAL");
            //temp.queryTeam("WestNet", "1186", "GIORP-TOTAL");
            Console.ReadLine();
        }


    }
}

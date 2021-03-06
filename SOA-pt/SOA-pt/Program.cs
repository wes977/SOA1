﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	program.cs
//
// summary:	Implements the program class
// 
//  TEAM : WES , JEN, Niels , Alex
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Configuration;

namespace SOA_pt
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A program. </summary>
    ///
    ///  
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class Program
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Main entry-point for this application. </summary>
        ///
        ///  
        ///
        /// <param name="args"> An array of command-line argument strings. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        static void Main(string[] args)
        {
            Logger.startLogger();
            SOATalker temp = new SOATalker();
            Sockets listener = new Sockets();
            
            string configvalue1 = ConfigurationManager.AppSettings["countoffiles"];
            temp.IP = ConfigurationManager.AppSettings["IP"];
            temp.port = Int32.Parse( ConfigurationManager.AppSettings["Port"]);
            string tName = ConfigurationManager.AppSettings["teamName"];
            // Registering the Team and all that jazz 

            Logger.Log("Reg Team");
            temp.regTeam(tName);

            // Publishing the service and all that 
            Logger.Log("Puiblish Service");
            temp.publishService();
            Logger.Log("Starting Listening and all that ");
            listener.startSocket(temp.teamID);
            //temp.queryService("GIORP-TOTAL");
            //temp.queryTeam("WestNet", "1186", "GIORP-TOTAL");
            Console.ReadLine();
        }


    }
}

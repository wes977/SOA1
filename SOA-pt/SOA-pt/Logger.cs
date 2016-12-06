////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Logger.cs
//
// summary:	Implements the logger class
// 
//  TEAM : WES , JEN, Niels , Alex
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
namespace SOA_pt
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A logger. </summary>
    ///
    /// 
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class Logger
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Logs. </summary>
        ///
        /// 
        ///
        /// <param name="action">   The action. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void Log(string action)
        {
            string path = @"C:\Users\wthompson2143\Desktop\ServiceLogger.txt";
            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(DateTime.Now + " : " + action);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Starts a logger. </summary>
        ///
        /// 
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void startLogger()
        {

            string action = "\r\nTEAM :" + ConfigurationManager.AppSettings["teamName"] + " (Wes Thompson , Alex Martin , Niels Nindeboom , Jen Klimova) \r\n" +
                "Tag - Name : " + ConfigurationManager.AppSettings["ServiceTagName"] +"\r\n"+
            "service - Name : " + ConfigurationManager.AppSettings["ServiceName"] + "\r\n";



            string path = @"C:\Users\wthompson2143\Desktop\ServiceLogger.txt";
            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(DateTime.Now + " : " + action);
            }
        }
    }
}

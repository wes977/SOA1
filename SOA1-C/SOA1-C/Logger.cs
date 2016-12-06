////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	logger.cs
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
namespace SOA1_C
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
            string path = @"C:\Users\wthompson2143\Desktop\ClientLogger.txt";
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

            string action = "USER APP LOG \r\n Team WestNet (Wes Thompson , Alex Martin Niels Lindeboom , Jen Klimova)";
            string path = @"C:\Users\wthompson2143\Desktop\ClientLogger.txt";
            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(DateTime.Now + " : " + action);
            }
        }
    }
}

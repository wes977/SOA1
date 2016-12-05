using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SOA_pt
{
    class Logger
    {

        public static void Log(string action)
        {
            string path = @"C:\Users\wthompson2143\Desktop\ServiceLogger.txt";
            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(DateTime.Now + " : " + action);
            }
        }
    }
}

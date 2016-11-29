using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOA1_C
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Show first form and start the message loop
            (new Form1()).Show();
            Application.Run(); // needed, otherwise app closes immediately
            //Application.Run(new Form1());
        }
    }
}

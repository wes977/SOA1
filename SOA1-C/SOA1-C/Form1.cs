using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOA1_C
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            Logger.startLogger();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void srvc1btn_Click(object sender, EventArgs e)
        {

            Logger.Log("Client Started!");
            (new SNbtn()).Show();
            this.Hide();
        }
    }
}

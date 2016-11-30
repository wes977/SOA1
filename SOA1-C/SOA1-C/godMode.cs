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
    public partial class SNbtn : Form
    {

        private List<DataMembers> lInputDataMembers = new List<DataMembers>();
        private List<DataMembers> lOutputDataMembers = new List<DataMembers>();
        List<Panel> ls = new List<Panel>();
        HL7Builder temp = new HL7Builder();
        SOATalker talker = new SOATalker();
        SOATalker servicetalker = new SOATalker();
        List<TextBox> rspTBs = new List<TextBox>();
        List<TextBox> argTBs = new List<TextBox>();
        public SNbtn()
        {
            InitializeComponent();
            int i = 0;
            talker.regTeam();
            talker.queryService("GIORP-TOTAL");
            foreach (ARGstruct arg in talker.tempHL.argList)
            {
                Panel pan = new Panel();
                pan.Name = "panel" + i;
                ls.Add(pan);
                Label l = new Label();
                TextBox tb = new TextBox();
                tb.Location = new Point(10, 25);
                tb.Size = new Size(70, 20);
                l.Text = arg.argName;
                tb.Text = arg.argDataType;
                pan.Location = new Point(12, i * 50 + 250);
                pan.Size = new Size(200, 50);
                pan.Controls.Add(l);
                pan.Controls.Add(tb);
                this.Controls.Add(pan);
                argTBs.Add(tb);
                i++;
            }
            fillInputAndOutput();
        }

        private void fillInputAndOutput()
        {

            int j = 0;
            srvDescLBl.Text = talker.tempHL.SRVs.description;
            servicetalker.IP = talker.tempHL.MCHs.IP;
            servicetalker.port = Convert.ToInt32(talker.tempHL.MCHs.port);


            foreach (RSPstruct rsp in servicetalker.tempHL.rspList)
            {
                Panel pan = new Panel();
                pan.Name = "panelOut" + j;
                ls.Add(pan);
                Label l = new Label();
                TextBox tb = new TextBox();
                tb.Location = new Point(10, 25);
                tb.Size = new Size(70, 20);
                l.Text = rsp.name;
                tb.Text = rsp.value;
                pan.Location = new Point(610, j * 50 + 250);
                pan.Size = new Size(200, 50);
                pan.Controls.Add(l);
                pan.Controls.Add(tb);
                this.Controls.Add(pan);
                rspTBs.Add(tb);

                j++;
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void regTeambtn_Click(object sender, EventArgs e)
        {

        }

        private void execbtl_Click(object sender, EventArgs e)
        {

            string[] inputs = { "","",""};
            int Count = 0;
            ARGstruct[] aARGs;
            
            //servicetalker.tempHL.rspList.Clear();
            foreach(TextBox tb in argTBs)
            {
               inputs[Count] = tb.Text ;
                Count++;
            }
            aARGs = talker.tempHL.argList.ToArray();
            aARGs[0].value = inputs[0];
            aARGs[1].value = inputs[1];
            servicetalker.execService(talker.tempHL.SRVs.serviceName, talker.tempHL.SRVs.numARGS, aARGs);
            //argTBs.Clear();
            
            fillInputAndOutput();
            int c = 0;
            foreach (TextBox textB in rspTBs)
            {
                textB.Text = servicetalker.tempHL.rspList[c].value;
                c++;
                if (c == 5)
                {
                    break;
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            talker.IP = IPtb.Text;
            talker.port = Convert.ToInt32(portTB.Text);
        }
    }
}

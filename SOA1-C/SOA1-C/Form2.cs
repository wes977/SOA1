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
    public partial class Form2 : Form
    {
        private List<DataMembers> lInputDataMembers = new List<DataMembers>();
        private List<DataMembers> lOutputDataMembers = new List<DataMembers>();
        List<Panel> ls = new List<Panel>();
        HL7Builder temp = new HL7Builder();
        SOATalker talker = new SOATalker();
        public Form2()
        {
            InitializeComponent();
            this.FormClosed +=
               new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);

            DataMembers temp1 = new DataMembers();
            temp1.paraName = "Meow";
            temp1.paraType = "string";

            DataMembers temp2 = new DataMembers();
            temp2.paraName = "Woof";
            temp2.paraType = "Int";

            DataMembers temp3 = new DataMembers();
            temp3.paraName = "Cat";
            temp3.paraType = "string";
            temp3.paraType = "SeeMore";

            DataMembers temp4 = new DataMembers();
            temp4.paraName = "Dog";
            temp4.paraType = "String";
            temp4.paraValue = "Rolly";


            lInputDataMembers.Add(temp1);
            lInputDataMembers.Add(temp2);
            lInputDataMembers.Add(temp1);
            lInputDataMembers.Add(temp2);
            lInputDataMembers.Add(temp1);
            lInputDataMembers.Add(temp2);

            lOutputDataMembers.Add(temp3);
            lOutputDataMembers.Add(temp4);
           // talker.regTeam();
            //talker.queryService("GIORP-TOTAL");
            //temp.HLStringDebuilder("SOA|OK|||3|");
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int i = 0;
            int j = 0;
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
                pan.Location = new Point(10, i * 50 + 100);
                pan.Size = new Size(180, 50);
                pan.Controls.Add(l);
                pan.Controls.Add(tb);
                this.Controls.Add(pan);
                i++;
            }
            foreach (RSPstruct rsp in talker.tempHL.rspList)
            {
                Panel pan = new Panel();
                pan.Name = "panelOut" + j;
                ls.Add(pan);
                Label l = new Label();
                TextBox tb = new TextBox();
                tb.Location = new Point(10, 25);
                tb.Size = new Size(70, 20);
                l.Text = rsp.name;
                tb.Text = rsp.DataType;
                pan.Location = new Point(200, j * 50 + 100);
                pan.Size = new Size(200, 50);
                pan.Controls.Add(l);
                pan.Controls.Add(tb);
                this.Controls.Add(pan);
                j++;
            }

        }

        private void serviceDesc_Click(object sender, EventArgs e)
        {

        }

        private void exeBTN_Click(object sender, EventArgs e)
        {

        }
    }
}

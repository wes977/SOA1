////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	godmode.cs
//
// summary:	Implements the godmode class
// 
//  TEAM : WES , JEN, Niels , Alex
////////////////////////////////////////////////////////////////////////////////////////////////////

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
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A nbtn. </summary>
    ///
    ///  
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class SNbtn : Form
    {

        /// <summary>   The input data members. </summary>
        private List<DataMembers> lInputDataMembers = new List<DataMembers>();
        /// <summary>   The output data members. </summary>
        private List<DataMembers> lOutputDataMembers = new List<DataMembers>();
        /// <summary>   The ls. </summary>
        List<Panel> ls = new List<Panel>();
        /// <summary>   The temporary. </summary>
        HL7Builder temp = new HL7Builder();
        /// <summary>   The talker. </summary>
        SOATalker talker = new SOATalker();
        /// <summary>   The servicetalker. </summary>
        SOATalker servicetalker = new SOATalker();
        /// <summary>   The rsp t bs. </summary>
        List<TextBox> rspTBs = new List<TextBox>();
        /// <summary>   The argument bs. </summary>
        List<TextBox> argTBs = new List<TextBox>();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        ///  
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SNbtn()
        {
            InitializeComponent();
            int i = 0;
            //talker.regTeam();
           // talker.queryService("GIORP-TOTAL");
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Fill input and output. </summary>
        ///
        ///  
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by label5 for click events. </summary>
        ///
        ///  
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void label5_Click(object sender, EventArgs e)
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by regTeambtn for click events. </summary>
        ///
        ///  
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void regTeambtn_Click(object sender, EventArgs e)
        {
            talker.IP = IPtb.Text;
            talker.port = Int32.Parse(portTB.Text);
            talker.regTeam(teamNameTB.Text);
            teamIDtb.Text = talker.tempHL.SOAs.errorCode;
            if ( "" == talker.tempHL.SOAerrorChecker())
            {
                if (talker.errorMsg != "")
                {
                    Errorlbl.Text = talker.errorMsg;
                }
              
            }
            else
            {
                Errorlbl.Text = talker.tempHL.SOAerrorChecker();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by execbtl for click events. </summary>
        ///
        ///  
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

            string errorMes = servicetalker.execService(teamIDtb.Text,teamNameTB.Text,talker.tempHL.SRVs.serviceName, talker.tempHL.SRVs.numARGS, aARGs);
            if (errorMes == "")
            {
                Errorlbl.Text = errorMes;
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
            else
            {
                Errorlbl.Text = errorMes;
                int q = 0;
                foreach (TextBox textB in rspTBs)
                {
                    textB.Text = "ERROR";
                    q++;
                    if (q == 5)
                    {
                        break;
                    }
                }
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by button2 for click events. </summary>
        ///
        ///  
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void button2_Click(object sender, EventArgs e)
        {
            talker.IP = IPtb.Text;
            talker.port = Convert.ToInt32(portTB.Text);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by querybtn for click events. </summary>
        ///
        ///  
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void querybtn_Click(object sender, EventArgs e)
        {
            talker.queryService(serviceNameTB.Text,teamNameTB.Text,talker.tempHL.teamCode);
            argTBs.Clear();
            string IDK = talker.tempHL.MCHs.IP;
            int i = 0;
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
            
            if ("" == talker.tempHL.SOAerrorChecker())
            {
                if (talker.errorMsg != "")
                {
                    Errorlbl.Text = talker.errorMsg;
                }

            }
            else
            {
                Errorlbl.Text = talker.tempHL.SOAerrorChecker();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by serviceNameTB for text changed events. </summary>
        ///
        ///  
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void serviceNameTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void Errorlbl_Click(object sender, EventArgs e)
        {

        }
    }
}

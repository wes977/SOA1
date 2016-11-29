namespace SOA1_C
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.exeBTN = new System.Windows.Forms.Button();
            this.teamNamelbl = new System.Windows.Forms.Label();
            this.serviceNamelbl = new System.Windows.Forms.Label();
            this.serviceDesc = new System.Windows.Forms.Label();
            this.inputLB = new System.Windows.Forms.Label();
            this.OutputLB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exeBTN
            // 
            this.exeBTN.Location = new System.Drawing.Point(12, 478);
            this.exeBTN.Name = "exeBTN";
            this.exeBTN.Size = new System.Drawing.Size(75, 23);
            this.exeBTN.TabIndex = 0;
            this.exeBTN.Text = "Execute";
            this.exeBTN.UseVisualStyleBackColor = true;
            this.exeBTN.Click += new System.EventHandler(this.exeBTN_Click);
            // 
            // teamNamelbl
            // 
            this.teamNamelbl.AutoSize = true;
            this.teamNamelbl.Location = new System.Drawing.Point(9, 9);
            this.teamNamelbl.Name = "teamNamelbl";
            this.teamNamelbl.Size = new System.Drawing.Size(68, 13);
            this.teamNamelbl.TabIndex = 1;
            this.teamNamelbl.Text = "Team Name:";
            // 
            // serviceNamelbl
            // 
            this.serviceNamelbl.AutoSize = true;
            this.serviceNamelbl.Location = new System.Drawing.Point(9, 32);
            this.serviceNamelbl.Name = "serviceNamelbl";
            this.serviceNamelbl.Size = new System.Drawing.Size(77, 13);
            this.serviceNamelbl.TabIndex = 2;
            this.serviceNamelbl.Text = "Service Name:";
            // 
            // serviceDesc
            // 
            this.serviceDesc.AutoSize = true;
            this.serviceDesc.Location = new System.Drawing.Point(9, 57);
            this.serviceDesc.Name = "serviceDesc";
            this.serviceDesc.Size = new System.Drawing.Size(102, 13);
            this.serviceDesc.TabIndex = 3;
            this.serviceDesc.Text = "Service Description:";
            this.serviceDesc.Click += new System.EventHandler(this.serviceDesc_Click);
            // 
            // inputLB
            // 
            this.inputLB.AutoSize = true;
            this.inputLB.Location = new System.Drawing.Point(34, 82);
            this.inputLB.Name = "inputLB";
            this.inputLB.Size = new System.Drawing.Size(31, 13);
            this.inputLB.TabIndex = 4;
            this.inputLB.Text = "Input";
            // 
            // OutputLB
            // 
            this.OutputLB.AutoSize = true;
            this.OutputLB.Location = new System.Drawing.Point(243, 82);
            this.OutputLB.Name = "OutputLB";
            this.OutputLB.Size = new System.Drawing.Size(39, 13);
            this.OutputLB.TabIndex = 5;
            this.OutputLB.Text = "Output";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 513);
            this.Controls.Add(this.OutputLB);
            this.Controls.Add(this.inputLB);
            this.Controls.Add(this.serviceDesc);
            this.Controls.Add(this.serviceNamelbl);
            this.Controls.Add(this.teamNamelbl);
            this.Controls.Add(this.exeBTN);
            this.Name = "Form2";
            this.Text = "Service";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exeBTN;
        private System.Windows.Forms.Label teamNamelbl;
        private System.Windows.Forms.Label serviceNamelbl;
        private System.Windows.Forms.Label serviceDesc;
        private System.Windows.Forms.Label inputLB;
        private System.Windows.Forms.Label OutputLB;
    }
}


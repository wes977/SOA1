﻿namespace SOA1_C
{
    partial class SOA1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SOA1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.IPtb = new System.Windows.Forms.TextBox();
            this.serviceNameTB = new System.Windows.Forms.TextBox();
            this.teamNameTB = new System.Windows.Forms.TextBox();
            this.portTB = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.westNetLogo = new System.Windows.Forms.PictureBox();
            this.regTeambtn = new System.Windows.Forms.Button();
            this.querybtn = new System.Windows.Forms.Button();
            this.execbtl = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.westNetLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(309, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 33);
            this.label3.TabIndex = 2;
            this.label3.Text = "Team Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 33);
            this.label4.TabIndex = 3;
            this.label4.Text = "Service name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(200, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 33);
            this.label5.TabIndex = 4;
            this.label5.Text = "Input";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(840, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 33);
            this.label6.TabIndex = 5;
            this.label6.Text = "Output";
            // 
            // IPtb
            // 
            this.IPtb.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPtb.Location = new System.Drawing.Point(71, 6);
            this.IPtb.Name = "IPtb";
            this.IPtb.Size = new System.Drawing.Size(232, 40);
            this.IPtb.TabIndex = 6;
            this.IPtb.Text = "192.168.111.111";
            // 
            // serviceNameTB
            // 
            this.serviceNameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serviceNameTB.Location = new System.Drawing.Point(233, 86);
            this.serviceNameTB.Name = "serviceNameTB";
            this.serviceNameTB.Size = new System.Drawing.Size(284, 40);
            this.serviceNameTB.TabIndex = 7;
            this.serviceNameTB.Text = "CAR-LOAN";
            // 
            // teamNameTB
            // 
            this.teamNameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamNameTB.Location = new System.Drawing.Point(233, 46);
            this.teamNameTB.Name = "teamNameTB";
            this.teamNameTB.Size = new System.Drawing.Size(284, 40);
            this.teamNameTB.TabIndex = 8;
            this.teamNameTB.Text = "West-Net";
            // 
            // portTB
            // 
            this.portTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portTB.Location = new System.Drawing.Point(396, 6);
            this.portTB.Name = "portTB";
            this.portTB.Size = new System.Drawing.Size(121, 40);
            this.portTB.TabIndex = 9;
            this.portTB.Text = "3128";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 167);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(584, 524);
            this.listBox1.TabIndex = 10;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(602, 167);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(584, 524);
            this.listBox2.TabIndex = 11;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // westNetLogo
            // 
            this.westNetLogo.ImageLocation = "C:\\Users\\wthompson2143\\Desktop\\SOA1-C (2)\\SOA1-C\\SOA1-C\\SOA1-C\\WestNet.PNG";
            this.westNetLogo.Location = new System.Drawing.Point(1040, 9);
            this.westNetLogo.Name = "westNetLogo";
            this.westNetLogo.Size = new System.Drawing.Size(146, 113);
            this.westNetLogo.TabIndex = 12;
            this.westNetLogo.TabStop = false;
            // 
            // regTeambtn
            // 
            this.regTeambtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regTeambtn.Location = new System.Drawing.Point(523, 46);
            this.regTeambtn.Name = "regTeambtn";
            this.regTeambtn.Size = new System.Drawing.Size(253, 40);
            this.regTeambtn.TabIndex = 13;
            this.regTeambtn.Text = "Register Team";
            this.regTeambtn.UseVisualStyleBackColor = true;
            // 
            // querybtn
            // 
            this.querybtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.querybtn.Location = new System.Drawing.Point(523, 89);
            this.querybtn.Name = "querybtn";
            this.querybtn.Size = new System.Drawing.Size(253, 42);
            this.querybtn.TabIndex = 14;
            this.querybtn.Text = "Query";
            this.querybtn.UseVisualStyleBackColor = true;
            // 
            // execbtl
            // 
            this.execbtl.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.execbtl.Location = new System.Drawing.Point(343, 693);
            this.execbtl.Name = "execbtl";
            this.execbtl.Size = new System.Drawing.Size(253, 42);
            this.execbtl.TabIndex = 15;
            this.execbtl.Text = "Execute";
            this.execbtl.UseVisualStyleBackColor = true;
            // 
            // SOA1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(1198, 747);
            this.Controls.Add(this.execbtl);
            this.Controls.Add(this.querybtn);
            this.Controls.Add(this.regTeambtn);
            this.Controls.Add(this.westNetLogo);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.portTB);
            this.Controls.Add(this.teamNameTB);
            this.Controls.Add(this.serviceNameTB);
            this.Controls.Add(this.IPtb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SOA1";
            this.Text = "godMode";
            ((System.ComponentModel.ISupportInitialize)(this.westNetLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox IPtb;
        private System.Windows.Forms.TextBox serviceNameTB;
        private System.Windows.Forms.TextBox teamNameTB;
        private System.Windows.Forms.TextBox portTB;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox westNetLogo;
        private System.Windows.Forms.Button regTeambtn;
        private System.Windows.Forms.Button querybtn;
        private System.Windows.Forms.Button execbtl;
    }
}
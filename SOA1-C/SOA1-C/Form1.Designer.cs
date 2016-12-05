namespace SOA1_C
{
    partial class Form1
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
            this.form1Ttl = new System.Windows.Forms.Label();
            this.srvc1btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // form1Ttl
            // 
            this.form1Ttl.AutoSize = true;
            this.form1Ttl.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.form1Ttl.Location = new System.Drawing.Point(-1, 9);
            this.form1Ttl.Name = "form1Ttl";
            this.form1Ttl.Size = new System.Drawing.Size(344, 55);
            this.form1Ttl.TabIndex = 0;
            this.form1Ttl.Text = "Service Select";
            // 
            // srvc1btn
            // 
            this.srvc1btn.Location = new System.Drawing.Point(9, 116);
            this.srvc1btn.Name = "srvc1btn";
            this.srvc1btn.Size = new System.Drawing.Size(315, 23);
            this.srvc1btn.TabIndex = 1;
            this.srvc1btn.Text = "Service 1";
            this.srvc1btn.UseVisualStyleBackColor = true;
            this.srvc1btn.Click += new System.EventHandler(this.srvc1btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 154);
            this.Controls.Add(this.srvc1btn);
            this.Controls.Add(this.form1Ttl);
            this.Name = "Form1";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label form1Ttl;
        private System.Windows.Forms.Button srvc1btn;
    }
}
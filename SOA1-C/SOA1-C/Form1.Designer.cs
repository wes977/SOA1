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
            this.srvc2btn = new System.Windows.Forms.Button();
            this.srvc3btn = new System.Windows.Forms.Button();
            this.srvc4btn = new System.Windows.Forms.Button();
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
            this.srvc1btn.Location = new System.Drawing.Point(13, 68);
            this.srvc1btn.Name = "srvc1btn";
            this.srvc1btn.Size = new System.Drawing.Size(315, 23);
            this.srvc1btn.TabIndex = 1;
            this.srvc1btn.Text = "Service 1";
            this.srvc1btn.UseVisualStyleBackColor = true;
            this.srvc1btn.Click += new System.EventHandler(this.srvc1btn_Click);
            // 
            // srvc2btn
            // 
            this.srvc2btn.Location = new System.Drawing.Point(13, 97);
            this.srvc2btn.Name = "srvc2btn";
            this.srvc2btn.Size = new System.Drawing.Size(315, 23);
            this.srvc2btn.TabIndex = 2;
            this.srvc2btn.Text = "Service 2";
            this.srvc2btn.UseVisualStyleBackColor = true;
            // 
            // srvc3btn
            // 
            this.srvc3btn.Location = new System.Drawing.Point(13, 126);
            this.srvc3btn.Name = "srvc3btn";
            this.srvc3btn.Size = new System.Drawing.Size(315, 23);
            this.srvc3btn.TabIndex = 3;
            this.srvc3btn.Text = "Service 3";
            this.srvc3btn.UseVisualStyleBackColor = true;
            // 
            // srvc4btn
            // 
            this.srvc4btn.Location = new System.Drawing.Point(13, 155);
            this.srvc4btn.Name = "srvc4btn";
            this.srvc4btn.Size = new System.Drawing.Size(315, 23);
            this.srvc4btn.TabIndex = 4;
            this.srvc4btn.Text = "Service 4";
            this.srvc4btn.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 189);
            this.Controls.Add(this.srvc4btn);
            this.Controls.Add(this.srvc3btn);
            this.Controls.Add(this.srvc2btn);
            this.Controls.Add(this.srvc1btn);
            this.Controls.Add(this.form1Ttl);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label form1Ttl;
        private System.Windows.Forms.Button srvc1btn;
        private System.Windows.Forms.Button srvc2btn;
        private System.Windows.Forms.Button srvc3btn;
        private System.Windows.Forms.Button srvc4btn;
    }
}
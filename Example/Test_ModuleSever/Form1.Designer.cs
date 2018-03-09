namespace Test_ModuleSever
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
            this.btSent = new System.Windows.Forms.Button();
            this.tbMess = new System.Windows.Forms.TextBox();
            this.lvMess = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btSent
            // 
            this.btSent.Location = new System.Drawing.Point(377, 249);
            this.btSent.Name = "btSent";
            this.btSent.Size = new System.Drawing.Size(75, 53);
            this.btSent.TabIndex = 11;
            this.btSent.Text = "Sent";
            this.btSent.UseVisualStyleBackColor = true;
            this.btSent.Click += new System.EventHandler(this.btSent_Click);
            // 
            // tbMess
            // 
            this.tbMess.Location = new System.Drawing.Point(12, 249);
            this.tbMess.Multiline = true;
            this.tbMess.Name = "tbMess";
            this.tbMess.Size = new System.Drawing.Size(359, 52);
            this.tbMess.TabIndex = 10;
            // 
            // lvMess
            // 
            this.lvMess.Location = new System.Drawing.Point(12, 12);
            this.lvMess.Name = "lvMess";
            this.lvMess.Size = new System.Drawing.Size(438, 231);
            this.lvMess.TabIndex = 9;
            this.lvMess.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 310);
            this.Controls.Add(this.btSent);
            this.Controls.Add(this.tbMess);
            this.Controls.Add(this.lvMess);
            this.Name = "Form1";
            this.Text = "Sever";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSent;
        private System.Windows.Forms.TextBox tbMess;
        private System.Windows.Forms.ListView lvMess;
    }
}


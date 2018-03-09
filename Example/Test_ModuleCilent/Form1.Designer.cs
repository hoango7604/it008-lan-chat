namespace Test_ModuleCilent
{
    partial class Client
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
            this.btSent.Location = new System.Drawing.Point(382, 245);
            this.btSent.Name = "btSent";
            this.btSent.Size = new System.Drawing.Size(75, 48);
            this.btSent.TabIndex = 8;
            this.btSent.Text = "Sent";
            this.btSent.UseVisualStyleBackColor = true;
            this.btSent.Click += new System.EventHandler(this.btSent_Click);
            // 
            // tbMess
            // 
            this.tbMess.Location = new System.Drawing.Point(17, 245);
            this.tbMess.Multiline = true;
            this.tbMess.Name = "tbMess";
            this.tbMess.Size = new System.Drawing.Size(359, 52);
            this.tbMess.TabIndex = 7;
            // 
            // lvMess
            // 
            this.lvMess.Location = new System.Drawing.Point(17, 8);
            this.lvMess.Name = "lvMess";
            this.lvMess.Size = new System.Drawing.Size(438, 231);
            this.lvMess.TabIndex = 6;
            this.lvMess.UseCompatibleStateImageBehavior = false;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 304);
            this.Controls.Add(this.btSent);
            this.Controls.Add(this.tbMess);
            this.Controls.Add(this.lvMess);
            this.Name = "Client";
            this.Text = "Client";
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


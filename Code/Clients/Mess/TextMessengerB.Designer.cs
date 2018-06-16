namespace Clients.Mess
{
    partial class TextMessengerB
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbMess = new System.Windows.Forms.TextBox();
            this.lbsender = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbMess
            // 
            this.tbMess.Location = new System.Drawing.Point(304, 34);
            this.tbMess.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbMess.Multiline = true;
            this.tbMess.Name = "tbMess";
            this.tbMess.Size = new System.Drawing.Size(420, 61);
            this.tbMess.TabIndex = 0;
            // 
            // lbsender
            // 
            this.lbsender.AutoSize = true;
            this.lbsender.Location = new System.Drawing.Point(560, 9);
            this.lbsender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbsender.Name = "lbsender";
            this.lbsender.Size = new System.Drawing.Size(51, 20);
            this.lbsender.TabIndex = 1;
            this.lbsender.Text = "label1";
            // 
            // TextMessengerB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbsender);
            this.Controls.Add(this.tbMess);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TextMessengerB";
            this.Size = new System.Drawing.Size(750, 123);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMess;
        private System.Windows.Forms.Label lbsender;
    }
}

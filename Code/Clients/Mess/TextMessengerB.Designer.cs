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
            this.lbsender = new System.Windows.Forms.Label();
            this.tbMess = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbsender
            // 
            this.lbsender.Location = new System.Drawing.Point(665, 0);
            this.lbsender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbsender.Name = "lbsender";
            this.lbsender.Size = new System.Drawing.Size(85, 29);
            this.lbsender.TabIndex = 1;
            this.lbsender.Text = "label1";
            this.lbsender.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbMess
            // 
            this.tbMess.Location = new System.Drawing.Point(250, 29);
            this.tbMess.Name = "tbMess";
            this.tbMess.Size = new System.Drawing.Size(500, 70);
            this.tbMess.TabIndex = 0;
            this.tbMess.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextMessengerB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbMess);
            this.Controls.Add(this.lbsender);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TextMessengerB";
            this.Size = new System.Drawing.Size(750, 123);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbsender;
        private System.Windows.Forms.Label tbMess;
    }
}

namespace Clients.Mess
{
    partial class TextMeesengerA
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
            this.tbMess = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbMess
            // 
            this.tbMess.Location = new System.Drawing.Point(15, 13);
            this.tbMess.Name = "tbMess";
            this.tbMess.Size = new System.Drawing.Size(488, 70);
            this.tbMess.TabIndex = 0;
            // 
            // TextMeesengerA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tbMess);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TextMeesengerA";
            this.Size = new System.Drawing.Size(750, 97);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label tbMess;
    }
}

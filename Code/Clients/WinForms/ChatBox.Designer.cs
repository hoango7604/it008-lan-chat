namespace Clients
{
    partial class ChatBox
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
            this.layout = new System.Windows.Forms.TableLayoutPanel();
            this.tbText = new System.Windows.Forms.TextBox();
            this.btfile = new System.Windows.Forms.PictureBox();
            this.btChooseImage = new System.Windows.Forms.PictureBox();
            this.btsent = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btChooseImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btsent)).BeginInit();
            this.SuspendLayout();
            // 
            // layout
            // 
            this.layout.AutoScroll = true;
            this.layout.BackColor = System.Drawing.Color.White;
            this.layout.ColumnCount = 1;
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layout.Location = new System.Drawing.Point(5, 9);
            this.layout.Name = "layout";
            this.layout.RowCount = 2;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.33161F));
            this.layout.Size = new System.Drawing.Size(519, 328);
            this.layout.TabIndex = 9;
            // 
            // tbText
            // 
            this.tbText.Location = new System.Drawing.Point(5, 343);
            this.tbText.Multiline = true;
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(521, 67);
            this.tbText.TabIndex = 19;
            this.tbText.Click += new System.EventHandler(this.tbText_Click);
            // 
            // btfile
            // 
            this.btfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btfile.Image = global::Clients.Properties.Resources.attachment;
            this.btfile.Location = new System.Drawing.Point(336, 415);
            this.btfile.Name = "btfile";
            this.btfile.Size = new System.Drawing.Size(45, 51);
            this.btfile.TabIndex = 30;
            this.btfile.TabStop = false;
            this.btfile.Click += new System.EventHandler(this.btfile_Click);
            // 
            // btChooseImage
            // 
            this.btChooseImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btChooseImage.Image = global::Clients.Properties.Resources.image;
            this.btChooseImage.Location = new System.Drawing.Point(261, 416);
            this.btChooseImage.Name = "btChooseImage";
            this.btChooseImage.Size = new System.Drawing.Size(49, 52);
            this.btChooseImage.TabIndex = 29;
            this.btChooseImage.TabStop = false;
            this.btChooseImage.Click += new System.EventHandler(this.btimage_Click);
            // 
            // btsent
            // 
            this.btsent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btsent.Image = global::Clients.Properties.Resources.Sentbt;
            this.btsent.Location = new System.Drawing.Point(415, 417);
            this.btsent.Name = "btsent";
            this.btsent.Size = new System.Drawing.Size(109, 51);
            this.btsent.TabIndex = 28;
            this.btsent.TabStop = false;
            this.btsent.Click += new System.EventHandler(this.btsent_Click);
            // 
            // ChatBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(531, 501);
            this.Controls.Add(this.btfile);
            this.Controls.Add(this.btChooseImage);
            this.Controls.Add(this.btsent);
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.layout);
            this.Name = "ChatBox";
            this.Text = "Tin nhắn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatBox_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btChooseImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btsent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layout;
        private System.Windows.Forms.TextBox tbText;
        private System.Windows.Forms.PictureBox btsent;
        private System.Windows.Forms.PictureBox btChooseImage;
        private System.Windows.Forms.PictureBox btfile;
    }
}







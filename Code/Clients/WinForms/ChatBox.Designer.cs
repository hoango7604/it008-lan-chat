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
            this.btChooseFile = new System.Windows.Forms.Button();
            this.tbText = new System.Windows.Forms.TextBox();
            this.btSend = new System.Windows.Forms.Button();
            this.lbFilename = new System.Windows.Forms.Label();
            this.btChoosePicture = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // layout
            // 
            this.layout.AutoScroll = true;
            this.layout.ColumnCount = 1;
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layout.Location = new System.Drawing.Point(18, 14);
            this.layout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.layout.Name = "layout";
            this.layout.RowCount = 2;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.33161F));
            this.layout.Size = new System.Drawing.Size(786, 529);
            this.layout.TabIndex = 9;
            // 
            // btChooseFile
            // 
            this.btChooseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btChooseFile.Location = new System.Drawing.Point(520, 562);
            this.btChooseFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btChooseFile.Name = "btChooseFile";
            this.btChooseFile.Size = new System.Drawing.Size(132, 37);
            this.btChooseFile.TabIndex = 15;
            this.btChooseFile.Text = "Chọn file";
            this.btChooseFile.UseVisualStyleBackColor = true;
            this.btChooseFile.Click += new System.EventHandler(this.btChooseFile_Click);
            // 
            // tbText
            // 
            this.tbText.Location = new System.Drawing.Point(18, 611);
            this.tbText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbText.Multiline = true;
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(634, 33);
            this.tbText.TabIndex = 19;
            this.tbText.Click += new System.EventHandler(this.tbText_Click);
            // 
            // btSend
            // 
            this.btSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSend.Location = new System.Drawing.Point(664, 562);
            this.btSend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(140, 82);
            this.btSend.TabIndex = 26;
            this.btSend.Text = "Gửi tin";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // lbFilename
            // 
            this.lbFilename.AutoSize = true;
            this.lbFilename.Location = new System.Drawing.Point(420, 571);
            this.lbFilename.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFilename.Name = "lbFilename";
            this.lbFilename.Size = new System.Drawing.Size(91, 20);
            this.lbFilename.TabIndex = 0;
            this.lbFilename.Text = "Example.txt";
            // 
            // btChoosePicture
            // 
            this.btChoosePicture.Location = new System.Drawing.Point(520, 652);
            this.btChoosePicture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btChoosePicture.Name = "btChoosePicture";
            this.btChoosePicture.Size = new System.Drawing.Size(132, 35);
            this.btChoosePicture.TabIndex = 27;
            this.btChoosePicture.Text = "chon anh";
            this.btChoosePicture.UseVisualStyleBackColor = true;
            this.btChoosePicture.Click += new System.EventHandler(this.btChoosePicture_Click);
            // 
            // ChatBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 732);
            this.Controls.Add(this.btChoosePicture);
            this.Controls.Add(this.lbFilename);
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.btChooseFile);
            this.Controls.Add(this.layout);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ChatBox";
            this.Text = "Tin nhắn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatBox_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layout;
        private System.Windows.Forms.Button btChooseFile;
        private System.Windows.Forms.TextBox tbText;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Label lbFilename;
        private System.Windows.Forms.Button btChoosePicture;
    }
}







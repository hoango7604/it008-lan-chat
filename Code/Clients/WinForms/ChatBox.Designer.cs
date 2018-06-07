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
            this.button4 = new System.Windows.Forms.Button();
            this.tblinkFile = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.tbText = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // layout
            // 
            this.layout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layout.AutoScroll = true;
            this.layout.ColumnCount = 1;
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layout.Location = new System.Drawing.Point(13, 14);
            this.layout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.layout.Name = "layout";
            this.layout.RowCount = 2;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.33161F));
            this.layout.Size = new System.Drawing.Size(1180, 338);
            this.layout.TabIndex = 9;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(839, 362);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 36);
            this.button4.TabIndex = 15;
            this.button4.Text = "Chọn file";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tblinkFile
            // 
            this.tblinkFile.Location = new System.Drawing.Point(13, 364);
            this.tblinkFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tblinkFile.Multiline = true;
            this.tblinkFile.Name = "tblinkFile";
            this.tblinkFile.Size = new System.Drawing.Size(814, 34);
            this.tblinkFile.TabIndex = 17;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(839, 410);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(86, 34);
            this.button5.TabIndex = 18;
            this.button5.Text = "Lưu file";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // tbText
            // 
            this.tbText.Location = new System.Drawing.Point(13, 410);
            this.tbText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbText.Multiline = true;
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(814, 34);
            this.tbText.TabIndex = 19;
            this.tbText.TextChanged += new System.EventHandler(this.tbText_TextChanged);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(933, 364);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(91, 80);
            this.button6.TabIndex = 20;
            this.button6.Text = "Gửi";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(1116, 384);
            this.button9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(77, 66);
            this.button9.TabIndex = 26;
            this.button9.Text = "Thoát";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // ChatBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 452);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.tblinkFile);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.layout);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ChatBox";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layout;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox tblinkFile;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox tbText;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button9;
    }
}


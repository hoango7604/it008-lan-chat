namespace ImageClient
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
            this.btSend = new System.Windows.Forms.Button();
            this.btChoose = new System.Windows.Forms.Button();
            this.tbSoure = new System.Windows.Forms.TextBox();
            this.layout = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.tbname = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btSend
            // 
            this.btSend.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btSend.Location = new System.Drawing.Point(361, 249);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(82, 47);
            this.btSend.TabIndex = 11;
            this.btSend.Text = "Send";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // btChoose
            // 
            this.btChoose.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btChoose.Location = new System.Drawing.Point(261, 239);
            this.btChoose.Name = "btChoose";
            this.btChoose.Size = new System.Drawing.Size(94, 23);
            this.btChoose.TabIndex = 10;
            this.btChoose.Text = "Choose";
            this.btChoose.UseVisualStyleBackColor = true;
            this.btChoose.Click += new System.EventHandler(this.btChoose_Click);
            // 
            // tbSoure
            // 
            this.tbSoure.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbSoure.Location = new System.Drawing.Point(12, 266);
            this.tbSoure.Name = "tbSoure";
            this.tbSoure.ReadOnly = true;
            this.tbSoure.Size = new System.Drawing.Size(343, 20);
            this.tbSoure.TabIndex = 9;
            // 
            // layout
            // 
            this.layout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layout.AutoScroll = true;
            this.layout.ColumnCount = 1;
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layout.Location = new System.Drawing.Point(12, 12);
            this.layout.Name = "layout";
            this.layout.RowCount = 2;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.33161F));
            this.layout.Size = new System.Drawing.Size(633, 226);
            this.layout.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(449, 244);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "CreatRoom";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbname
            // 
            this.tbname.Location = new System.Drawing.Point(440, 273);
            this.tbname.Name = "tbname";
            this.tbname.Size = new System.Drawing.Size(122, 20);
            this.tbname.TabIndex = 13;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(570, 244);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 49);
            this.button2.TabIndex = 14;
            this.button2.Text = "Login";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 308);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbname);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.btChoose);
            this.Controls.Add(this.tbSoure);
            this.Controls.Add(this.layout);
            this.Name = "Form1";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Button btChoose;
        private System.Windows.Forms.TextBox tbSoure;
        private System.Windows.Forms.TableLayoutPanel layout;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbname;
        private System.Windows.Forms.Button button2;
    }
}


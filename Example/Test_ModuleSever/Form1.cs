using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Cy_Connection_Sever;

namespace Test_ModuleSever
{
    public partial class Form1 : Form
    {
        Sever_module module = new Sever_module();
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
      
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            module.Connect();
            module.ReciveTextEvent += TextListener;
            module.ReciveImageEvent += ImageListener;
          
        }
      
        private void TextListener(object obj, int RoomId)
        {
            MessageBox.Show("Sever recive Mess, Room " + RoomId + " : " + obj.ToString());
        }

        private void ImageListener(object obj, int RoomId)
        {
            addmess(obj);
        }

        private void addmess(object data)
        {
            // o thể sửa UI từ 1 thread khác
            // https://stackoverflow.com/questions/14750872/c-sharp-controls-created-on-one-thread-cannot-be-parented-to-a-control-on-a-diff
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    Image img = data as Image;
                    PictureBox picBox = new PictureBox();
                    picBox.Image = img;
                    picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    layout.Controls.Add(picBox);


                });
            }
            else
            {
                Image img = data as Image;
                PictureBox picBox = new PictureBox();
                picBox.Image = img;
                picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                layout.Controls.Add(picBox);
            }
        }


        private void btChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            // dialog.Filter = "*png";
            dialog.Multiselect = false;
            dialog.ShowDialog();
            string s = dialog.FileName;
            tbSoure.Text = s;
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            Image img = Image.FromFile(tbSoure.Text.ToString());
            addmess(img);
            tbSoure.Clear();
            module.Send(img, DataType.Image, 0);
            module.Send(tbSoure.Text, DataType.Text, 0);
        }
    }
}

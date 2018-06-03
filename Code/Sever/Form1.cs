using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cy_Connection_Sever;

namespace Sever
{
    public partial class sever : Form
    {
        Sever_module myserver;
        public sever()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void sever_Load(object sender, EventArgs e)
        {
            myserver = new Sever_module();
            myserver.Connect();
        }

        private void Myserver_ReciveImageEvent(object obj, int RoomId)
        {
            pussMess(obj);
        }

        private void pussMess(object data)
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

        private void button1_Click(object sender, EventArgs e)
        {
            myserver.Ping();
        }
    }
}

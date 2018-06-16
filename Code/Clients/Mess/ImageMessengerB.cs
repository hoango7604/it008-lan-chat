using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clients.Mess
{
    public partial class ImageMessengerB : UserControl
    {
        public ImageMessengerB(string sender,object img)
        {
            InitializeComponent();
            lbsender.Text = sender;
            putImage(img);
        }
        private void putImage(object data)
        {
            // o thể sửa UI từ 1 thread khác
            // https://stackoverflow.com/questions/14750872/c-sharp-controls-created-on-one-thread-cannot-be-parented-to-a-control-on-a-diff
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    Image img = data as Image;
                    pictureBox.Image = img;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                });
            }
            else
            {
                Image img = data as Image;
                pictureBox.Image = img;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }
    }
}

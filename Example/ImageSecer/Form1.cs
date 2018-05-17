using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ImageSecer
{
    public partial class Sever : Form
    {
        Sever_module mysever;
        public Sever()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Sever_Load(object sender, EventArgs e)
        {
            mysever = new Sever_module();
            mysever.Connect();
            mysever.ReciveImageEvent += ReciveImage;
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
        /* https://stackoverflow.com/questions/3801275/how-to-convert-image-in-byte-array/16576471#16576471
            Xem lại cách conver image tại đaây
               */
        /*  private byte[] Searialize(object obj)
          {
              Image img = obj as Image;
              using (MemoryStream ms =  new MemoryStream())
              {
                  img.Save(ms, img.RawFormat);
                  return ms.ToArray(); 
              }
          }
          private static readonly ImageConverter _imageConverter = new ImageConverter();

          private object DeSearialize(byte[] data)
          {
              Bitmap bm = (Bitmap)_imageConverter.ConvertFrom(data);
              if (bm != null && (bm.HorizontalResolution != (int)bm.HorizontalResolution ||
                          bm.VerticalResolution != (int)bm.VerticalResolution))
              {
                  bm.SetResolution((int)(bm.HorizontalResolution + 0.5f),
                                   (int)(bm.VerticalResolution + 0.5f));
              }

              return bm;
          }
          */
     
        private void writedata(byte[] data)
        {
           
            FileStream fstream = new FileStream(@"C:\Users\admin\OneDrive - gm.uit.edu.vn\Worlkpace Winform\Socket Chat\sever_DeSerialize.txt",FileMode.OpenOrCreate,FileAccess.ReadWrite);
            StreamWriter stream = new StreamWriter(fstream);
            foreach (byte i in data)
            {
                stream.Write(i + "");
            }
            fstream.Close();
        }

       

        private void btChoose_Click(object sender, EventArgs e)
        {
            mysever.Ping();
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
            pussMess(img);
            tbSoure.Clear();
            mysever.Send(img, DataType.Image, 0);

        }

        private  void ReciveImage(object image, int RoomId)
        {
            pussMess(image);
        }
    }
}

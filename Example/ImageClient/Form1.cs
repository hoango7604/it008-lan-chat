using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageClient
{
    public partial class Form1 : Form
    {
        Client_module myclient;
        string username;
        byte lastId;
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myclient = new Client_module();
            myclient.Connect();
            myclient.ReciveImageEvent += ReciveImage; 
            myclient.ReciveLoginEvent += Myclient_ReciveLoginEvent;
            myclient.ReceiveListClientEvent += Myclient_ReceiveListClientEvent;
            myclient.ReceiveCreatRoomEvent += Myclient_ReceiveCreatRoomEvent;
        }

        
        private void Myclient_ReceiveCreatRoomEvent(int id, string[] listMember)
        {
            string members = "";
            foreach (string mem in listMember)
            {
                members+= " "+mem;
            }
            lastId =(byte) id;
            MessageBox.Show("username : " + username + " , yêu cầu vào phòng " + id + " bao gồm " +members);
        }

        private void Myclient_ReceiveListClientEvent(string[] listClients)
        {
            string result = "";
            foreach (string name in listClients)
            {
                result = result +" "+ name;
            }
            MessageBox.Show("Current clients " + result);
        }

        private void Myclient_ReciveLoginEvent(string username)
        {
            MessageBox.Show("Login thành công vs usernam "+ username);
            this.username = username;
            this.Name = username;
        }

        private void ReciveImage(string sendername,object obj,int RoomId)
        {
            MessageBox.Show(this.Name+"Vừa nhận dc tin nhắn từ "+sendername+"trong room "+RoomId);
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
          //  pussMess(img);
            tbSoure.Clear();
            myclient.Send(img, DataType.Image, lastId);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usernamesStr = tbname.Text;
            string[] split = new string[] {" "};
            string[] usenameSrr = usernamesStr.Split(split, StringSplitOptions.RemoveEmptyEntries);
            List<string> usernames = new List<string>(usenameSrr);
            myclient.CreatRoomChat(usernames);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myclient.LogIn(tbname.Text.ToString(), "cylasion");
        }
    }
}

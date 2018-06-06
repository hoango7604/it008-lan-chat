using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cy_Connection_Client;

namespace Clients
{
    public partial class ChatBox : Form
    {
        Client_module myclient;
        string username;
        byte lastId;
        string filename;
        int indexoffile;

        public ChatBox()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myclient = new Client_module();
            myclient.Connect();
            myclient.ReciveTextEvent += Myclient_ReciveTextEvent;
            myclient.ReciveImageEvent += Myclient_ReciveImageEvent;
            myclient.ReciveLoginEvent += Myclient_ReciveLoginEvent;
            myclient.ReceiveLogoutEvent += Myclient_ReceiveLogoutEvent;
            myclient.ReceiveListClientEvent += Myclient_ReceiveListClientEvent;
            myclient.ReceiveCreatRoomEvent += Myclient_ReceiveCreatRoomEvent;
            myclient.ReciveFileMessEvent += Myclient_ReciveFileMessEvent;
            myclient.ReceiveFileEvent += Myclient_ReceiveFileEvent;
        }

        private void Myclient_ReceiveLogoutEvent(string username, int room)
        {
            MessageBox.Show("Thông báo : thằng lờ "+ username + " tạch cmnr , chuẩn bị bay màu khỏi phòng "+room + " nhá  "+this.username+ " :3 ");
        }

        private void Myclient_ReciveTextEvent(string sender, object obj, int RoomId)
        {
            MessageBox.Show(username +" : tin nhắn từ "+sender+" : "+obj.ToString()+"  // tại phòng số "+RoomId);
        }

        private void Myclient_ReceiveFileEvent(byte[] file)
        {
            string path = tbsaveas.Text;
            DataConverter.Deserialize_File(file, path, filename);
            MessageBox.Show("Nhận file thành cmn công");
        }

        private void Myclient_ReciveFileMessEvent(string sender, int indexoffile, string filename, int roomid)
        {
            this.filename = filename;
            MessageBox.Show("username : " + username + " vừa nhận được file " + filename + " từ " + sender + " ở phòng " + roomid + " , ct sẽ tải về");

            this.indexoffile = indexoffile;
        }

        private void Myclient_ReceiveCreatRoomEvent(int id, string[] listMember)
        {
            string members = "";
            foreach (string mem in listMember)
            {
                members += " " + mem;
            }
            lastId = (byte)id;
            MessageBox.Show("username : " + username + " , yêu cầu vào phòng " + id + " bao gồm " + members);
        }

        private void Myclient_ReceiveListClientEvent(string[] listClients)
        {
            string result = "";
            foreach (string name in listClients)
            {
                result = result + " " + name;
            }
            MessageBox.Show("Current clients " + result);
        }

        private void Myclient_ReciveLoginEvent(string username)
        {
            MessageBox.Show("Login thành công vs usernam " + username);
            this.username = username;
            this.Name = username;
        }

        private void Myclient_ReciveImageEvent(string sendername, object obj, int RoomId)
        {
            MessageBox.Show(this.Name + "Vừa nhận dc tin nhắn từ " + sendername + "trong room " + RoomId);
            putImage(obj); ;
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
            myclient.LogIn(tblogin.Text, "day la pass");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = tbcreatroom.Text;
            string[] split = new string[] { " " };
            string[] usenameSrr = username.Split(split, StringSplitOptions.RemoveEmptyEntries);
            List<string> usernames = new List<string>(usenameSrr);
            myclient.CreatRoomChat(usernames);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            myclient.SendText(tbText.Text, lastId);
        }

        string path;
        string name;
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            // dialog.Filter = "*png";
            dialog.Multiselect = false;
            dialog.ShowDialog();
            string s = dialog.FileName;
            tblinkinage.Text = s;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            // dialog.Filter = "*png";
            dialog.Multiselect = false;
            dialog.ShowDialog();
            string s = dialog.FileName;
            tblinkFile.Text = s;
            System.IO.FileInfo info = new System.IO.FileInfo(s);
            path = info.DirectoryName;
            name = info.Name;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Image img = Image.FromFile(tblinkinage.Text.ToString());
            tblinkinage.Clear();
            myclient.SendImage(img, lastId);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            myclient.SendFile(path, name, lastId);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            myclient.RequestDownloadFile(indexoffile);
        }

        private void tbText_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbcreatroom_TextChanged(object sender, EventArgs e)
        {

        }

        private void tblogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            myclient.Logout(username);
        }
    }
}

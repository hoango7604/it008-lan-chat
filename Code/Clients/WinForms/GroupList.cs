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
using Clients.WinForms;
using System.Threading;

namespace Clients
{
    public partial class GroupList : Form
    {
        Client_module myClient;
        List<string> onlineUser = new List<string>();
        List<ChatBox> listChatBox = new List<ChatBox>();
        string username = "";
        public GroupList()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            CreateConnection();
            Login();
        }
   
        private void CreateConnection()
        {
            myClient = new Client_module();
            myClient.Connect();
            myClient.ReceiveCreatRoomEvent += MyClient_ReceiveCreatRoomEvent;
            myClient.ReceiveListClientEvent += MyClient_ReceiveListClientEvent1;
            myClient.ReceiveLogoutEvent += MyClient_ReceiveLogoutEvent;
            myClient.ReciveFileMessEvent += MyClient_ReciveFileMessEvent;
            myClient.ReceiveFileEvent += MyClient_ReceiveFileEvent1;
            myClient.ReciveImageEvent += MyClient_ReciveImageEvent;
            myClient.ReciveLoginEvent += MyClient_ReciveLoginEvent;
            myClient.ReciveTextEvent += MyClient_ReciveTextEvent;
        }
        private void Login()
        {
            Login loginform = new Login();
            this.Visible = false;
            DialogResult result =  loginform.ShowDialog();
            if (result == DialogResult.OK)
            {
                string username = loginform.username;
                myClient.LogIn(username, "WeDontHavePass");
            }
            else this.Close();
            loginform.GroupListReference(this);
        }
        public void LoginSuccess(string _username)
        {
            this.username = _username;
            this.Visible = true;
        }

        void InitializeListClient()
        {
           
            //làm trống lại danh sách các button

            foreach (string name in onlineUser)
            {
                OnlineClientItem item = new OnlineClientItem(name);
                item.CreatRoomButtonEvenClick += Item_CreatRoomButtonEvenClick;               
                if (this.InvokeRequired)
                {
                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        buttonFlowLayoutPanel.Controls.Add(item);
                    });
                }
                else
                {
                    buttonFlowLayoutPanel.Controls.Add(item);
                }
            }
        }
        private void Item_CreatRoomButtonEvenClick(string username)
        {
            List<string> room = new List<string>();
            room.Add(this.username);
            room.Add(username);
            myClient.CreatRoomChat(room);
        }
        private void MyClient_ReciveTextEvent(string sender, object obj, int RoomId)
        {
            //if (sender == username)
            //{
            //    //tự gửi tự nhận
            //    return;
            //}

            foreach (ChatBox cb in listChatBox)
            {
                if (cb.RoomId == RoomId)
                {
                    cb.ReceiveMessText(sender, obj);
                }
            }
        }
        private void MyClient_ReciveLoginEvent(string username)
        {
            if (username != "UserAlreadyLogin")
            {
                this.Visible = true;
                this.Text = "Username : " + username;
                MessageBox.Show("logint thành công vs username "+ username);
                this.username = username;
            }
            else
            {
                Login login = new Clients.Login();
                login.ShowDialog();
            }
        }
        private void MyClient_ReciveImageEvent(string sender, object obj, int RoomId)
        {
            //if (sender == username)
            //{
            //    //tự gửi tự nhận
            //    return;
            //}

            foreach (ChatBox cb in listChatBox)
            {
                if (cb.RoomId == RoomId)
                {
                    cb.ReceiveImage(sender, obj);
                }
            }
        }
        private void MyClient_ReciveFileMessEvent(string sender, int indexoffile, string filename, int roomid)
        {
            //if (sender == username)
            //{
            //    //tự gửi tự nhận
            //    return;
            //}

            foreach (ChatBox cb in listChatBox)
            {
                if (cb.RoomId == roomid)
                {
                    cb.ReceiveFileMess(sender, indexoffile, filename, roomid);
                }
            }
        }
        private void MyClient_ReceiveFileEvent1(byte[] file,int roomId)
        {
            //if (sender == username)
            //{
            //    //tự gửi tự nhận
            //    return;
            //}

            foreach (ChatBox cb in listChatBox)
            {
                if (cb.RoomId == roomId)
                {
                    cb.ReceiveFileDownLoad(file);
                }
            }
        }
        private void MyClient_ReceiveLogoutEvent(string username, int room)
        {
            throw new NotImplementedException(); 
        }
        private void MyClient_ReceiveListClientEvent1(string[] listClients)
        {
            //xóa control có sẵn

            onlineUser = new List<string>(listClients);
            InitializeListClient();
        }
        private void MyClient_ReceiveCreatRoomEvent(int id, string[] listMember)
        {
            ChatBox box = new ChatBox(id, listMember);
            box.RoomSendFileEvent += Box_RoomSendFileEvent;
            box.RoomSendImageEvent += Box_RoomSendImageEvent;
            box.RoomSendMessEvent += Box_RoomSendMessEvent;
            box.RoomRequestDownload += Box_RoomRequestDownload;
            box.RoomRequestOpenBrowserDialog += Box_RoomRequestOpenBrowserDialog;
            listChatBox.Add(box);
            MessageBox.Show("username "+username +" dc yeu cau vao phong chat "+ id+" bao gom " +listMember.ToArray().ToString());

            /// tạo 1 luồng mới để form chạy
            new Thread(() => box.ShowDialog()).Start();

        }
        private void Box_RoomRequestOpenBrowserDialog(byte[] data , int roomid)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (ChatBox cb in listChatBox)
                {
                    if (cb.RoomId == roomid)
                    {
                        cb.ReciverSavepath(dialog.SelectedPath, data);
                    }
                }
            }
        }
        private void Box_RoomRequestDownload(int id,int roomid)
        {
            myClient.RequestDownloadFile(id,roomid);    
        }
        #region xu li event cho 1 room
        private void Box_RoomSendMessEvent(object obj, int RoomId)
        {
            myClient.SendText(obj.ToString(), (byte)RoomId);
        }

        private void Box_RoomSendImageEvent(object obj, int RoomId)
        {
            myClient.SendImage(obj as Image, (byte)RoomId);
        }

        private void Box_RoomSendFileEvent(string path, string filename, int roomid)
        {
            myClient.SendFile(path, filename, (byte)roomid);
        }

      
        #endregion
        private void GroupList_FormClosing(object sender, FormClosingEventArgs e)
        {
            myClient.Logout(this.username);
        }
    }
}

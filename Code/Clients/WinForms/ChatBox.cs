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
using Clients.Mess;
using System.Threading;
using System.Diagnostics;

namespace Clients
{
    public partial class ChatBox : Form
    {

        public int RoomId;

        public delegate void MessingDelegate(object obj, int RoomId);
        public delegate void FileMessDelegate(string path, string filename, int roomid);
        public delegate void DownLoadFileDelegate(int id, int roomid);
        public delegate void OpenFolderBrowserDialogDelegate(byte[] file, int roomid);
        public event MessingDelegate RoomSendMessEvent;
        public event MessingDelegate RoomSendImageEvent;
        public event FileMessDelegate RoomSendFileEvent;
        public event DownLoadFileDelegate RoomRequestDownload;
        public event OpenFolderBrowserDialogDelegate RoomRequestOpenBrowserDialog;


        private string[] Member;
        private Cy_Connection_Client.DataType typeSent;

        string filepath = "";
        string filename = "";

        public ChatBox(int roomid, string[] member)
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.RoomId = roomid;
            this.Member = member;
            this.Text = "Phòng chat " + roomid + " < " + member[0] + " && " + member[1] + " > ";


        }

        private void Addcontrols(Control c)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    layout.Controls.Add(c);
                });
            }
            else
            {
                layout.Controls.Add(c);
            }
        }

        public void ReceiveMessText(string sender, object info)
        {
            TextMessengerB messB = new TextMessengerB(sender, (string)info);
            Addcontrols(messB);
        }

        public void ReceiveImage(string sender, object info)
        {
            ImageMessengerB imageB = new ImageMessengerB(sender, info);
            Addcontrols(imageB);
        }

        public void ReceiveFileMess(string sender, int indexoffile, string filename, int roomid)
        {
            FileMessengerB fileB = new FileMessengerB(sender, indexoffile, filename);
            fileB.DownLoadfileRequest += FileB_DownLoadfileRequest;
            Addcontrols(fileB);
        }

        public void ReciverSavepath(string path, byte[] data)
        {
            Cy_Connection_Client.DataConverter.Deserialize_File(data, path, DownloadFilename);
        }

        string DownloadFilename;
        private void FileB_DownLoadfileRequest(int id, string name)
        {
            if (RoomRequestDownload != null)
            {
                RoomRequestDownload(id, RoomId);
                DownloadFilename = name;
            }

        }

        public void ReceiveFileDownLoad(byte[] data)
        {
            RoomRequestOpenBrowserDialog(data, RoomId);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btSend_Click(object sender, EventArgs e)
        {
            if (typeSent == DataType.Text)
            {
                if (RoomSendMessEvent != null)
                {
                    RoomSendMessEvent(tbText.Text, RoomId);
                    TextMeesengerA messA = new TextMeesengerA(tbText.Text);
                    Addcontrols(messA);
                }
            }
            if (typeSent == DataType.Image)
            {
                if (RoomSendImageEvent != null)
                {
                    Image img = Image.FromFile(tbText.Text.ToString());
                    tbText.Clear();
                    RoomSendImageEvent(img, RoomId);
                    ImageMessengerA imageA = new ImageMessengerA(img);
                    Addcontrols(imageA);
                }
            }


            if (typeSent == DataType.File)
            {
                if (RoomSendFileEvent != null)
                {
                    tbText.Clear();
                    RoomSendFileEvent(filepath, filename, RoomId);
                    FileMessengerA fileA = new FileMessengerA(filepath, filename);
                    RoomSendFileEvent(filepath, filename, RoomId);
                    fileA.OpenfileEvent += FileA_OpenfileEvent;
                    Addcontrols(fileA);
                }
            }

        }

        private void FileA_OpenfileEvent(string dir)
        {
            Process.Start(dir);
        }

        private void ChatBox_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btChooseFile_Click(object sender, EventArgs e)
        {
            typeSent = DataType.File;
            Thread t = new Thread(new ThreadStart(ChosefileDialog));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }




        private void btChoosePicture_Click(object sender, EventArgs e)
        {
            typeSent = DataType.Image;
            Thread t = new Thread(new ThreadStart(ChosefileDialog));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void ChosefileDialog()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string s = dialog.FileName;
                tbText.Text = s;

                System.IO.FileInfo info = new System.IO.FileInfo(s);
                filename = info.Name;
                filepath = info.DirectoryName;

            }
            else
            {
                typeSent = DataType.Text;
            }

        }
        private void tbText_Click(object sender, EventArgs e)
        {
            typeSent = DataType.Text;
        }
    }
}

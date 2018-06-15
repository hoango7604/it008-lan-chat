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
    public partial class GroupList : Form
    {
        Client_module myClient;
        string username;
        byte lastId;
        string filename;
        int indexoffile;
        List<string> clientList = new List<string>();
        public GroupList()
        {
            InitializeComponent();
            //InitializeButtons();
        }
        public void SetClientModule(Client_module _Module)
        {
            myClient = _Module;
            //myClient.ReceiveListClientEvent += MyClient_ReceiveListClientEvent;
        }

        private void MyClient_ReceiveListClientEvent(string[] listClients)
        {
            string result = "";
            foreach (string name in listClients)
            {
                result = result + " " + name;
                clientList.Add(name);
            }
            MessageBox.Show("Current clients " + result);

        }

        void InitializeButtons(List<string> _clients)
        {
            for (int i = 0; i < _clients.Capacity; i++)
            {
                FlowLayoutPanel panel = new FlowLayoutPanel() { Height = buttonFlowLayoutPanel.ClientSize.Height - 280, Width = buttonFlowLayoutPanel.ClientSize.Width };
                Label label = new Label() { Width = panel.ClientSize.Width - 200 , TextAlign = ContentAlignment.MiddleLeft };
                Button button = new Button() { Height = label.ClientSize.Height };
                label.Text = _clients[i];
                button.Text = "Begin Messaging";
                button.Click += new EventHandler(OpenChatbox);
                panel.Controls.Add(label);
                panel.Controls.Add(button);
                buttonFlowLayoutPanel.Controls.Add(panel);
            }
        }
        void OpenChatbox(object sender, EventArgs e)
        {
            ChatBox a = new ChatBox() { Text = "Chat Box" };
            a.Show();
        }

        private void GroupList_Load(object sender, EventArgs e)
        {
            myClient = new Client_module();
            myClient.Connect();
            //myClient.ReceiveListClientEvent += ListCLientEvent;
            myClient.ReciveLoginEvent += Myclient_ReciveLoginEvent;

            this.Visible = false;
            Login logIn = new Login();
            logIn.GroupListReference(this);
            logIn.ShowDialog();
        }
        private void ListCLientEvent(string[] _listClient)
        {

        }
        private void Myclient_ReciveLoginEvent(string username)
        {
            MessageBox.Show("Login thành công với username " + username);
        }
        public void LogIn(string _username,string _password)
        {
            this.Visible = true;
            myClient.LogIn(_username, _password);
        }
    }
}

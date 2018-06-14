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
    }
}

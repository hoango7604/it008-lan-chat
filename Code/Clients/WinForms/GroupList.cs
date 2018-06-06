using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clients
{
    public partial class GroupList : Form
    {
        public GroupList()
        {
            InitializeComponent();
            InitializeButtons();
        }
        void InitializeButtons()
        {
            for (int i = 0; i < 5; i++)
            {
                Button button = new Button() { Width = buttonFlowLayoutPanel.ClientSize.Width };
                button.Text = "Choose group " + i;
                button.Click += new EventHandler(OpenChatbox);
                buttonFlowLayoutPanel.Controls.Add(button);
            }
        }
        void OpenChatbox(object sender, EventArgs e)
        {
            ChatBox a = new ChatBox() { Text = "Chat Box" };
            a.Show();
        }
    }
}

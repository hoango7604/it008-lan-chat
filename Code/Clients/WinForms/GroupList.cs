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
            for (int i = 0; i < 10; i++)
            {

                FlowLayoutPanel panel = new FlowLayoutPanel() { Height = buttonFlowLayoutPanel.ClientSize.Height - 280, Width = buttonFlowLayoutPanel.ClientSize.Width };
                Label label = new Label() { Width = panel.ClientSize.Width - 200 , TextAlign = ContentAlignment.MiddleLeft };
                Button button = new Button() { Height = label.ClientSize.Height };
                label.Text = "User " + i;
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

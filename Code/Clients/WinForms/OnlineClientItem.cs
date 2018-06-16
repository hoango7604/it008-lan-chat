using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clients.WinForms
{
    public partial class OnlineClientItem : UserControl
    {
        public delegate void CreatRoomClick(string username);
        public event CreatRoomClick CreatRoomButtonEvenClick;
        private string username;

        public OnlineClientItem()
        {
            InitializeComponent();
        }

        public OnlineClientItem(string username)
        {
            InitializeComponent();
            lbName.Text = username;
            this.username = username;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btCreat_Click(object sender, EventArgs e)
        {
            CreatRoomButtonEvenClick(this.username);
        }
    }
}

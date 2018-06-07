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
    public partial class Login : Form
    {
        Client_module myclient;
        string username;
        byte lastId;
        string filename;
        int indexoffile;

        public Login()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //myclient.LogIn(textBox1.Text, "1234");
            GroupList groupList = new GroupList();
            groupList.ShowDialog();
        }
    }
}

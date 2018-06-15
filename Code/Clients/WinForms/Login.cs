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
        GroupList _groupList;

        public Login()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        public void GroupListReference(GroupList _instance)
        {
            _groupList = _instance;
        }
        
        private void Login_Load(object sender, EventArgs e)
        {
        }
        private void Myclient_ReciveLoginEvent(string username)
        {
            MessageBox.Show("Login thành công với username " + username);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _groupList.LogIn(textBox1.Text,"cylasion");
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

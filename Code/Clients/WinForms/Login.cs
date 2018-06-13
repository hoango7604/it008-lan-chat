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

        
        private void Login_Load(object sender, EventArgs e)
        {
            myclient = new Client_module();
            myclient.Connect();
            
            myclient.ReceiveListClientEvent += ListCLientEvent;
            myclient.ReciveLoginEvent += Myclient_ReciveLoginEvent;
        }
        private void Myclient_ReciveLoginEvent(string username)
        {
            MessageBox.Show("Login thành công vs usernam " + username);
        }
        private void ListCLientEvent(string[] listClients)
        {
            //string result = "";
            //foreach (string name in listClients)
            //{
            //    result = result + " " + name;
            //}
            //MessageBox.Show("Current clients " + result);
            MessageBox.Show("Success");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            myclient.LogIn(textBox1.Text, "cylasion");
            //GroupList groupList = new GroupList();
            //groupList.SetClientModule(myclient);
            //groupList.ShowDialog();
        }
        
    }
}

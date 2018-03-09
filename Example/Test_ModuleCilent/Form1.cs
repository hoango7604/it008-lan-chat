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

namespace Test_ModuleCilent
{
    public partial class Client : Form
    {
        Client_module module = new Client_module();

        public Client()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            lvMess.View = View.List;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            module.Connect();
            module.ReciveTextEvent += TextListener;
        }

        private void btSent_Click(object sender, EventArgs e)
        {
            module.Send(tbMess.Text);
            addmess(tbMess.Text);
        }

        private void TextListener(object obj)
        {
            addmess(obj.ToString());          
        }
        public void addmess(string text)
        {
            ListViewItem item = new ListViewItem(text);
            lvMess.Items.Add(item);
        }
    }
}

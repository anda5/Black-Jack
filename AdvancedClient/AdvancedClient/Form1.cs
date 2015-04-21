using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetworksApi.TCP.CLIENT;

namespace AdvancedClient
{
    public partial class Form1 : Form
    {

        Client client;
       

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox5.Text!="")
            {
                client.ClientName = textBox1.Text;
                client.ServerIp = textBox2.Text;
                client.ServerPort = textBox5.Text;

                client.Connect();
            }
            else
            {
                MessageBox.Show("Fill the textBox");
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}

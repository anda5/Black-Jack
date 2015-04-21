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
    public delegate void Update(string txt);
    public partial class Form1 : Form
    {

        Client client;
       

        public Form1()
        {
            InitializeComponent();
        }
        public void ChageTextBox(string txt)
        {
            if(textBox3.InvokeRequired){
                Invoke(new Update(ChageTextBox),new object[] {txt});
            }else{
                textBox3.Text += txt + "\r\n";
            }
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
            if (client != null && client.IsConnected)
            {
                client.Send(textBox4.Text);
                textBox4.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox5.Text !="")
            {
                client = new Client();
                client.ClientName = textBox1.Text;
                client.ServerIp = textBox2.Text;
                client.ServerPort = textBox5.Text;

                client.OnClientConnected += new OnClientConnectedDelegate(client_OnClientConnected);
                client.OnClientConnecting += new OnClientConnectingDelegate(client_OnClientConnecting);
                client.OnClientDisconnected += new OnClientDisconnectedDelegate(client_OnClientDisconected);
                client.OnClientError += new OnClientErrorDelegate(client_OnClientError);
                client.OnClientFileSending += new OnClientFileSendingDelegate(client_OnClientFileSending);
                client.OnDataReceived += new OnClientReceivedDelegate(client_OnClientRecivedDelegate);
                client.Connect();
            }
            else
            {
                MessageBox.Show("Fill the textBox");
            }
        }

        private void client_OnClientRecivedDelegate(object Sender, ClientReceivedArguments R)
        {
            ChageTextBox(R.ReceivedData);
        }

        private void client_OnClientFileSending(object Sender, ClientFileSendingArguments R)
        {
            
        }

        private void client_OnClientError(object Sender, ClientErrorArguments R)
        {
            ChageTextBox(R.ErrorMessage);
        }

        private void client_OnClientDisconected(object Sender, ClientDisconnectedArguments R)
        {
            ChageTextBox(R.EventMessage);
        }

        private void client_OnClientConnecting(object Sender, ClientConnectingArguments R)
        {
            ChageTextBox(R.EventMessage);
        }

        void client_OnClientConnected(object Sender, ClientConnectedArguments R)
        {
            ChageTextBox(R.EventMessage);
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (client != null && client.IsConnected && e.KeyCode == Keys.Enter)
            {
                client.Send(textBox4.Text);
                textBox4.Clear();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }
    }
}

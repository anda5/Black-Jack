using NetworksApi.TCP.CLIENT;
using NetworksApi.TCP.SERVER;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedClient
{
    public partial class Form2 : Form
    {
        String text1;
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        String text;
        Client client;
        String room = " ";
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                client = new Client();
                client.ClientName = textBox1.Text;
                client.ServerIp = "192.168.56.1";
                client.ServerPort = "80";


                client.OnClientConnected += new OnClientConnectedDelegate(client_OnClientConnected);
                client.OnClientConnecting += new OnClientConnectingDelegate(client_OnClientConnecting);
                client.OnClientDisconnected += new OnClientDisconnectedDelegate(client_OnClientDisconected);
                client.OnClientError += new OnClientErrorDelegate(client_OnClientError);
                client.OnClientFileSending += new OnClientFileSendingDelegate(client_OnClientFileSending);
                client.OnDataReceived += new OnClientReceivedDelegate(client_OnClientRecivedDelegate);
                client.Connect();
                this.Hide();
                Form3 gameForm = new Form3(textBox1.Text,client,text1);
                gameForm.ShowDialog();
                text = textBox1.Text;
                

            }
            else
            {
                MessageBox.Show("Fill the textBox");
            }
        }

        public void client_OnClientRecivedDelegate(object Sender, ClientReceivedArguments R)
        {
            if (R.ReceivedData.StartsWith("r#"))
            {
               String[] m = R.ReceivedData.Split('#');

               text1 = m[1];

            }
        }

        private void client_OnClientFileSending(object Sender, ClientFileSendingArguments R)
        {
         
        }

        private void client_OnClientError(object Sender, ClientErrorArguments R)
        {
         
        }

        private void client_OnClientDisconected(object Sender, ClientDisconnectedArguments R)
        {
           
        }

        private void client_OnClientConnecting(object Sender, ClientConnectingArguments R)
        {
        }

        private void client_OnClientConnected(object Sender, ClientConnectedArguments R)
        {
           
        }


        //private void client_OnClientConnected(object Sender, ClientConnectedArguments R)
        //{
        //    client.Send("r#" + text);
        //}
   
       

        //private void client_OnClientRecivedDelegate(object Sender, ClientReceivedArguments R)
        //{
        //    if (R.ReceivedData.StartsWith("r#"))
        //    {
        //        String[] m = R.ReceivedData.Split('#');
        //        room = m[1];
        //    }
            
        //}
       

        //public String getText()
        //{
        //    return text;
        //}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4(textBox1.Text);
            form4.ShowDialog();
        }
    }
}

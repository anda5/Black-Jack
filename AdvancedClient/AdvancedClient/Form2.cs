using NetworksApi.TCP.CLIENT;
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
              
                client.OnDataReceived += new OnClientReceivedDelegate(client_OnClientRecivedDelegate);
                client.Connect();

                
                this.Hide();
                Form3 gameForm = new Form3(textBox1.Text,client);
                gameForm.ShowDialog();
                text = textBox1.Text;
                

            }
            else
            {
                MessageBox.Show("Fill the textBox");
            }
        }

        private void client_OnClientConnecting(object Sender, ClientConnectingArguments R)
        {
            
        }

        private void client_OnClientConnected(object Sender, ClientConnectedArguments R)
        {
            client.Send("r#" + text);
        }
   
       

        private void client_OnClientRecivedDelegate(object Sender, ClientReceivedArguments R)
        {
            if (R.ReceivedData.StartsWith("r#"))
            {
                String[] m = R.ReceivedData.Split('#');
                room = m[1];
            }
            
        }
       

        public String getText()
        {
            return text;
        }
    }
}

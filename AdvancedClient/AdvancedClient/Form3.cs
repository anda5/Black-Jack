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
    public delegate void Change(string txt);
    
    public partial class Form3 : Form
    {
        Client client;
       
        public Form3(String a,Client c)
        {
            InitializeComponent();
            text = a;
            client=c;
            client.ServerIp = "192.168.56.1";
            client.ServerPort = "80";
            client.OnDataReceived += new OnClientReceivedDelegate(client_OnClientRecivedDelegate);
           client.Connect();
        }
        public void Change(string txt)
        {
            if (listBox1.InvokeRequired)
            {
                Invoke(new Update(Change), new object[] { txt });
            }
            else
            {
                string[] r = txt.Split('#');
                room1 = r[1];
                listBox1.Items.Add(room1);

                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

                listBox1.Items.Add(textBox1.Text);
               client.Send("r#" + textBox1.Text);
            
            
        }
        String text;
        
        private void button2_Click(object sender, EventArgs e)
        {
            String room = (string)listBox1.SelectedItem;
            this.Hide();
            client.Send("disconect");
            Form1 gameForm = new Form1(text);
            gameForm.ShowDialog();
            
            

        }
        String room1;
        private void client_OnClientRecivedDelegate(object Sender, ClientReceivedArguments R)
        {
            String mesaj = R.ReceivedData;
            if (mesaj.StartsWith("r#"))
            {

                Change(mesaj);
           
            }
        }
        public String getText()
        {
            return text;
        }
    }
}

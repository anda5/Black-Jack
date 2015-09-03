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
        Client client1;
        String name;
        String textul;
      
       
        public Form3(String text,Client client,String text1)
        {
            InitializeComponent();
            name = text;
            client1 = client;
            textul = text1;

            client1.OnClientConnected += new OnClientConnectedDelegate(client_OnClientConnected);
            client1.OnDataReceived += new OnClientReceivedDelegate(client_OnClientRecivedDelegate);
            
        }

        private void client_OnClientConnected(object Sender, ClientConnectedArguments R)
        {
            //throw new NotImplementedException();
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
                
                client1.Send("r#" + textBox1.Text);
                listBox1.Items.Add(textBox1.Text); 
                
              
               
            
            
        }
      
        
        private void button2_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedItem != null)
            {
                client1.Disconnect();
                this.Hide();
                Form1 gameForm = new Form1(name);
                gameForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a room!");
            }
            

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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 firstForm = new Form2();
            firstForm.ShowDialog();
        }
       
    }
}

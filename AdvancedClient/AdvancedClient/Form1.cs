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
using System.Drawing.Imaging;
using System.Resources;
using AdvancedClient.Properties;
using System.IO;

namespace AdvancedClient
{
    public delegate void Update(string txt);
    public delegate void UpdateLabel(string txt);
    public partial class Form1 : Form
    {

        Client client;
     
       

        Player player1 = new Player();
        Player player2 = new Player();
        Random random = new Random();
        Image img;


        int card1;
        int card2;
        int card5;
        int card6;

        String m;
        MemoryStream ms;

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
        public void ChangeLabel(string img)
        {if(pictureBox6.InvokeRequired){
                Invoke(new UpdateLabel(ChangeLabel),new object[] {img});
        }
        else
        {
            if (ms != null)
            {
                MemoryStream ms1 = new MemoryStream(ms.ToArray());
                Image returnImage = Image.FromStream(ms1);
                pictureBox6.Image = returnImage;

            }  
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
                if (ms != null)
                {
                    ms = new MemoryStream();
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    client.Send(ms.ToArray().ToString());
                }

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
                Boolean diff = false;
                if (diff == false)
                {
                    player1.setCArd(random.Next(1, 11));
                    card1 = player1.getCard();
                    Shape shape = new Shape();
                    Card card = shape.generateShape();

                    Image image1 = card.draw(card1);
                    pictureBox2.Image = image1;
                  
                    diff = true;


                    player2.setCArd(card1);
                    card2 = player2.getCard();
                    Image img = card.draw(card2);


                   
                }
                if (diff == true)
                {
                    player1.setCArd(random.Next(1, 11));
                    card2 = player1.getCard();
                    Shape shape = new Shape();
                    Card card = shape.generateShape();
                    Image image11 = card.draw(card2);
                    pictureBox3.Image = image11;
                }

            }
            else
            {
                MessageBox.Show("Fill the textBox");
            }
        }

        private void client_OnClientRecivedDelegate(object Sender, ClientReceivedArguments R)
        {
            ChageTextBox(R.ReceivedData);
            ChangeLabel(R.ReceivedData);
            

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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (ms != null)
            {
                ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                m = ms.ToArray().ToString();
            }

          
        }
        public void calculate()
        {
            int sum1, sum2;

            sum1 = card1 + card2;
            sum2 = card5 + card6;
            Console.WriteLine("sum1 =" + sum1);
            Console.WriteLine("sum2 =" + sum2);

            for (int i = 0; i < 2; i++)
            {

                Console.WriteLine("Apsa hit sau stay:");
                String action = Console.ReadLine();
                player1.setAction(action);


                Console.WriteLine("Apsa hit sau stay:");
                String action2 = Console.ReadLine();
                player2.setAction(action2);

                if (player1.getaction() == "hit")
                {
                    sum1 += random.Next(10);
                    Console.WriteLine(sum1);
                }
                if (player1.getaction() == "stay")
                {
                    sum1 += 0;
                    Console.WriteLine(sum1);
                }

                if (player2.getaction() == "hit")
                {
                    sum2 += random.Next(10);
                    Console.WriteLine(sum2);
                }
                if (player2.getaction() == "stay")
                {
                    sum2 += 0;
                    Console.WriteLine(sum2);
                }

            }
            if (sum1 <= 21)
            {
                Console.Write("The winer in player1");
            }
            if (sum2 <= 21)
            {
                Console.WriteLine("The winer is player2");
            }
            if (sum1 > 21 || sum2 > 21)
            {
                Console.WriteLine("Lose");
            }
            if (sum1 > sum2 && sum1 > 21 && sum2 > 21)
            {
                Console.WriteLine("The winer is player 1");
            }
            else
            {
                Console.WriteLine("The winer is player 2");
            }
        }

        public void displayCard(int number){

            Random random = new Random();
            int num = random.Next(1, 4);

            switch (number)
            { case  1:
                    if (num == 1)
                    {
                        pictureBox2.Image = Resources.d2;
                    }
                    else if (num == 2)
                    {
                        pictureBox2.Image = Resources.h2;
                    }
                    else if (num == 3)
                    {
                        pictureBox2.Image = Resources.s2;
                    }
                    else if (num == 4)
                    {
                        pictureBox2.Image = Resources.t2;
                    }
                    break;
                    

            }
        }
        bool test = false;
        private void button4_Click(object sender, EventArgs e)
        {
        
            if (test==false) { 
            player1.setCArd(random.Next(1, 11));
            card5 = player1.getCard();
            Shape shape1 = new Shape();
            Card cardc = shape1.generateShape();
            Image image11 = cardc.draw(card5);
            pictureBox4.Image = image11;
            test =true;
            }
            else
            if (test ==true)
            {
                player1.setCArd(random.Next(1, 11));
                card5 = player1.getCard();
                Shape shape1 = new Shape();
                Card cardc = shape1.generateShape();
                Image image11 = cardc.draw(card5);
                pictureBox5.Image = image11;
            }
        }
           
         

    }

}

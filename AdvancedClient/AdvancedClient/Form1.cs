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
    public delegate void RememberImage(string txt);
    public partial class Form1 : Form
    {

        Client client;
       

        Card card;

        Player player1 = new Player();
        Player player2 = new Player();
        Dealer dealer = new Dealer();
        Random random = new Random();
        Random random1 = new Random();
        Random random2 = new Random();
        Random random3 = new Random();
        int score;
        String gi, txt;
        Image img, img1;
        Image deal1, deal2, deal3;
     

        int card1;
        int card2;
        int card5;
        int card6;
        int number;
        String shape;

        Boolean tests;
        String get,get1;
        int dealerScore = 0;
       
        
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

        public void ChageLabel(string txt)
        {
            if (textBox3.InvokeRequired)
            {
                Invoke(new Update(ChageLabel), new object[] { txt });
            }
            else
            {
                String[] m = txt.Split('s');
                label9.Text = m[1];

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
            if (textBox1.Text != "" && textBox2.Text != "" && textBox5.Text != "")
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

            String mesaj = R.ReceivedData;

            if (mesaj.StartsWith("#"))
            {
                String[] text = mesaj.Split('/');
                String mesaj1 = text[0];
                String mesaj2 = text[1];
                int cardNumber = CardNumber(mesaj1);
                String cardShape = CardShape(mesaj2);
                for (int i = 2; i <= 14; i++)
                {
                    if (cardNumber == i)
                    {
                        if (cardShape == "heart")
                        {
                            player1.setCArd(i);
                            int card = player1.getCard();
                            CardFactory cardfact = new CardFactory();
                            Shape.card sh = Shape.card.HEART;
                            Image imge1 = cardfact.getShape(sh).draw(card);
                            pictureBox6.Image = imge1;
                        }

                        else if (cardShape == "diamonds")
                        {
                            player1.setCArd(i);
                            int card = player1.getCard();
                            CardFactory cardfact = new CardFactory();
                            Shape.card sh = Shape.card.DIAMONDS;
                            Image imge1 =  cardfact.getShape(sh).draw(card);
                            pictureBox6.Image = imge1;

                        }
                        else if (cardShape == "clubs")
                        {
                            player1.setCArd(i);
                            int card = player1.getCard();
                            CardFactory cardfact = new CardFactory();
                            Shape.card sh = Shape.card.CLUBS;
                            Image imge1 = cardfact.getShape(sh).draw(card);
                            pictureBox6.Image = imge1;


                        }
                        else if (cardShape == "spades")
                        {
                            player1.setCArd(i);
                            int card = player1.getCard();
                            CardFactory cardfact = new CardFactory();
                            Shape.card sh = Shape.card.SPADES;
                            Image imge1 = cardfact.getShape(sh).draw(card);
                            pictureBox6.Image = imge1;

                        }
                    }
                }
            }
                if (mesaj.StartsWith("$#"))
                {
                    String[] text = mesaj.Split('/');
                    String mesaj1 = text[0];
                    String mesaj2 = text[1];
                    int cardNumber = CardNumberOne(mesaj1);
                    String cardShape = CardShape(mesaj2);
                    for (int i = 2; i <= 14; i++)
                    {
                        if (cardNumber == i)
                        {
                            if (cardShape == "heart")
                            {
                                player1.setCArd(i);
                                int card = player1.getCard();
                                CardFactory cardfact = new CardFactory();
                                Shape.card sh = Shape.card.HEART;
                                Image imge1 = cardfact.getShape(sh).draw(card);
                                pictureBox7.Image = imge1;
                            }

                            else if (cardShape == "diamonds")
                            {
                                player1.setCArd(i);
                                int card = player1.getCard();
                                CardFactory cardfact = new CardFactory();
                                Shape.card sh = Shape.card.DIAMONDS;
                                Image imge1 = cardfact.getShape(sh).draw(card);
                                pictureBox7.Image = imge1;

                            }
                            else if (cardShape == "clubs")
                            {
                                player1.setCArd(i);
                                int card = player1.getCard();
                                CardFactory cardfact = new CardFactory();
                                Shape.card sh = Shape.card.CLUBS;
                                Image imge1 = cardfact.getShape(sh).draw(card);
                                pictureBox7.Image = imge1;


                            }
                            else if (cardShape == "spades")
                            {
                                player1.setCArd(i);
                                int card = player1.getCard();
                                CardFactory cardfact = new CardFactory();
                                Shape.card sh = Shape.card.SPADES;
                                Image imge1 = cardfact.getShape(sh).draw(card);
                                pictureBox7.Image = imge1;

                            }
                        }
                    }
                }
                if (mesaj.StartsWith("!#"))
                {
                    String[] text = mesaj.Split('/');
                    String mesaj1 = text[0];
                    String mesaj2 = text[1];
                    int cardNumber = CardNumberTwo(mesaj1);
                    String cardShape = CardShape(mesaj2);
                    for (int i = 2; i <= 14; i++)
                    {
                        if (cardNumber == i)
                        {
                            if (cardShape == "heart")
                            {
                                player1.setCArd(i);
                                int card = player1.getCard();
                                CardFactory cardfact = new CardFactory();
                                Shape.card sh = Shape.card.HEART;
                                Image imge1 = cardfact.getShape(sh).draw(card);
                                pictureBox8.Image = imge1;
                            }

                            else if (cardShape == "diamonds")
                            {
                                player1.setCArd(i);
                                int card = player1.getCard();
                                CardFactory cardfact = new CardFactory();
                                Shape.card sh = Shape.card.DIAMONDS;
                                Image imge1 = cardfact.getShape(sh).draw(card);
                                pictureBox8.Image = imge1;

                            }
                            else if (cardShape == "clubs")
                            {
                                player1.setCArd(i);
                                int card = player1.getCard();
                                CardFactory cardfact = new CardFactory();
                                Shape.card sh = Shape.card.CLUBS;
                                Image imge1 = cardfact.getShape(sh).draw(card);
                                pictureBox8.Image = imge1;


                            }
                            else if (cardShape == "spades")
                            {
                                player1.setCArd(i);
                                int card = player1.getCard();
                                CardFactory cardfact = new CardFactory();
                                Shape.card sh = Shape.card.SPADES;
                                Image imge1 = cardfact.getShape(sh).draw(card);
                                pictureBox8.Image = imge1;

                            }
                        }
                    }
                }
                if (mesaj.StartsWith("@#"))
                {
                    String[] text = mesaj.Split('/');
                    String mesaj1 = text[0];
                    String mesaj2 = text[1];
                    int cardNumber = CardNumberThree(mesaj1);
                    String cardShape = CardShape(mesaj2);
                    for (int i = 2; i <= 14; i++)
                    {
                        if (cardNumber == i)
                        {
                            if (cardShape == "heart")
                            {
                                player1.setCArd(i);
                                int card = player1.getCard();
                                CardFactory cardfact = new CardFactory();
                                Shape.card sh = Shape.card.HEART;
                                Image imge1 = cardfact.getShape(sh).draw(card);
                                pictureBox9.Image = imge1;
                            }

                            else if (cardShape == "diamonds")
                            {
                                player1.setCArd(i);
                                int card = player1.getCard();
                                CardFactory cardfact = new CardFactory();
                                Shape.card sh = Shape.card.DIAMONDS;
                                Image imge1 = cardfact.getShape(sh).draw(card);
                                pictureBox9.Image = imge1;

                            }
                            else if (cardShape == "clubs")
                            {
                                player1.setCArd(i);
                                int card = player1.getCard();
                                CardFactory cardfact = new CardFactory();
                                Shape.card sh = Shape.card.CLUBS;
                                Image imge1 = cardfact.getShape(sh).draw(card);
                                pictureBox9.Image = imge1;


                            }
                            else if (cardShape == "spades")
                            {
                                player1.setCArd(i);
                                int card = player1.getCard();
                                CardFactory cardfact = new CardFactory();
                                Shape.card sh = Shape.card.SPADES;
                                Image imge1 = cardfact.getShape(sh).draw(card);
                                pictureBox9.Image = imge1;

                            }
                        }
                    }
                }
                    if (mesaj.StartsWith("d#"))
                    {
                        String[] text = mesaj.Split('/');
                        String mesaj1 = text[0];
                        String mesaj2 = text[1];
                        int cardNumber = CardNumberDealer(mesaj1);
                        String cardShape = CardShape(mesaj2);
                        for (int i = 2; i <= 14; i++)
                        {
                            if (cardNumber == i)
                            {
                                if (cardShape == "heart")
                                {
                                    player1.setCArd(i);
                                    int card = player1.getCard();
                                    CardFactory cardfact = new CardFactory();
                                    Shape.card sh = Shape.card.HEART;
                                    Image imge1 = cardfact.getShape(sh).draw(card);
                                    pictureBox10.Image = imge1;
                                   
                                }

                                else if (cardShape == "diamonds")
                                {
                                    player1.setCArd(i);
                                    int card = player1.getCard();
                                    CardFactory cardfact = new CardFactory();
                                    Shape.card sh = Shape.card.DIAMONDS;
                                    Image imge1 = cardfact.getShape(sh).draw(card);
                                    pictureBox10.Image = imge1;
                             

                                }
                                else if (cardShape == "clubs")
                                {
                                    player1.setCArd(i);
                                    int card = player1.getCard();
                                    CardFactory cardfact = new CardFactory();
                                    Shape.card sh = Shape.card.CLUBS;
                                    Image imge1 = cardfact.getShape(sh).draw(card);
                                    pictureBox10.Image = imge1;
                                   


                                }
                                else if (cardShape == "spades")
                                {
                                    player1.setCArd(i);
                                    int card = player1.getCard();
                                    CardFactory cardfact = new CardFactory();
                                    Shape.card sh = Shape.card.SPADES;
                                    Image imge1 = cardfact.getShape(sh).draw(card);
                                    pictureBox10.Image = imge1;
                                   

                                }
                            }
                        }

                    } if (mesaj.StartsWith("s"))
                    {
                        ChageLabel(R.ReceivedData);

                    }
                else
                {
                    ChageTextBox(R.ReceivedData);
                }
                }

        public int CardNumberDealer(String mesaj)
        {
            String[] text = { "d#0", "d#1", "d#2", "d#3", "d#4", "d#5", "d#6", "d#7", "d#8", "d#9", "d#10", "d#11", "d#12", "d#13", "d#14" };

            for (int i = 0; i <= 14; i++)
            {
                if (mesaj == text[i])
                    number = i;
            }
            return number;

        }

        public int CardNumber(String mesaj)
        {
            String[] text = { "#0", "#1", "#2", "#3", "#4", "#5", "#6", "#7", "#8", "#9", "#10", "#11", "#12", "#13", "#14" };

            for (int i = 0; i <= 14; i++) {
                if(mesaj==text[i])
                 number = i;
            }
             return number;

        }
        public int CardNumberOne(String mesaj)
        {
            String[] text = { "$#0", "$#1", "$#2", "$#3", "$#4", "$#5", "$#6", "$#7", "$#8", "$#9", "$#10", "$#11", "$#12", "$#13", "$#14" };

            for (int i = 0; i <= 14; i++)
            {
                if (mesaj == text[i])
                    number = i;
            }
            return number;

        }
        public int CardNumberTwo(String mesaj)
        {
            String[] text = { "!#0", "!#1", "!#2", "!#3", "!#4", "!#5", "!#6", "!#7", "!#8", "!#9", "!#10", "!#11", "!#12", "!#13", "!#14" };

            for (int i = 0; i <= 14; i++)
            {
                if (mesaj == text[i])
                    number = i;
            }
            return number;

        }
        public int CardNumberThree(String mesaj)
        {
            String[] text = { "@#0", "@#1", "@#2", "@#3", "@#4", "@#5", "@#6", "@#7", "@#8", "@#9", "@#10", "@#11", "@#12", "@#13", "@#14" };

            for (int i = 0; i <= 14; i++)
            {
                if (mesaj == text[i])
                    number = i;
            }
            return number;

        }
        public String CardShape(string mesaj)
        {
            String[] text = { "heart", "clubs", "diamonds", "spades" };
            foreach(String s in text){
                if (mesaj == s)
                {
                    shape = s;
                }
            }
            return shape;
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
           // RememberImage(R.EventMessage);
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

        int test2 = 0;
        private void Start_Click(object sender, EventArgs e)
        {

           if (test2 == 0)
            {
                player1.setCArd(random.Next(2, 14));
                int card1 = player1.getCard();
                get = Convert.ToString(card1);
                Shape shape = new Shape();
                Random rand = new Random();
                Card card;
                String s;
                if (card1 <= 11)
                {
                    score += card1;
                }
                else if (card1 > 11)
                {
                    score += 10;
                }
                label8.Text = Convert.ToString(score);
                client.Send("s" + Convert.ToString(score));
                int nrrr = rand.Next(1, 4);
                if (nrrr == 1)
                {

                    CardFactory cardfact = new CardFactory();
                    Shape.card sh = Shape.card.SPADES;
                    Image imge1 = cardfact.getShape(sh).draw(card1);
                    pictureBox2.Image = imge1;
                    s = "spades";
                    client.Send("#" + get + "/" + s);

                }
                else if (nrrr == 2)
                {

                    CardFactory cardfact1 = new CardFactory();
                    Shape.card sh = Shape.card.HEART;
                    s = cardfact1.getSh();
                    Image imge1 = cardfact1.getShape(sh).draw(card1);
                    pictureBox2.Image = imge1;
                    s = "heart";

                    client.Send("#" + get + "/" + s);



                }
                else if (nrrr == 3)
                {

                    CardFactory cardfact2 = new CardFactory();
                    Shape.card sh = Shape.card.DIAMONDS;
                    s = cardfact2.getSh();
                    Image imge1 = cardfact2.getShape(sh).draw(card1);
                    pictureBox2.Image = imge1;
                    s = "diamonds";

                    client.Send("#" + get + "/" + s);


                }
                else if (nrrr == 4)
                {

                    CardFactory cardfact3 = new CardFactory();
                    Shape.card sh = Shape.card.CLUBS;
                    s = cardfact3.getSh();
                    Image image1 = cardfact3.getShape(sh).draw(card1);
                    pictureBox2.Image = image1;
                    s = "clubs";
                    client.Send("#" + get + "/" + s);
                }

                test2++;
            }
           else if (test2 == 1)
           {

               player2.setCArd(random1.Next(2, 14));
               int card11 = player2.getCard();
               String g = Convert.ToString(card11);
               Random rando = new Random();
               Card cardd;
               String sf;
               if (card11 <= 11)
               {
                   score += card11;
               }
               else if (card11 > 11)
               {
                   score += 10;
               }
               label8.Text = Convert.ToString(score);
               client.Send("s" + Convert.ToString(score));
               int ni = rando.Next(1, 4);
               if (ni == 1)
               {
                   CardFactory cardfact = new CardFactory();
                   Shape.card sh = Shape.card.SPADES;
                   Image imge1 = cardfact.getShape(sh).draw(card11);
                   pictureBox3.Image = imge1;
                   sf = "spades";
                   client.Send("$#" + g + "/" + sf);

               }
               else if (ni == 2)
               {
                   CardFactory cardfact1 = new CardFactory();
                   Shape.card sh = Shape.card.HEART;
                   Image imge1 = cardfact1.getShape(sh).draw(card11);
                   pictureBox3.Image = imge1;
                   sf = "heart";
                   client.Send("$#" + g + "/" + sf);

               }
               else if (ni == 3)
               {
                   CardFactory cardfact2 = new CardFactory();
                   Shape.card sh = Shape.card.DIAMONDS;
                   Image imge1 = cardfact2.getShape(sh).draw(card11);
                   pictureBox3.Image = imge1;
                   sf = "diamonds";
                   client.Send("$#" + g + "/" + sf);


               }
               else if (ni == 4)
               {
                   CardFactory cardfact3 = new CardFactory();
                   Shape.card sh = Shape.card.CLUBS;
                   Image imge1 = cardfact3.getShape(sh).draw(card11);
                   pictureBox3.Image = imge1;
                   sf = "clubs";
                   client.Send("$#" + g + "/" + sf);


               }
               
          
                   pictureBox10.Image = dealer.generateCard();
                   gi = dealer.getCardNumber();
                   txt = dealer.getShape();
                   if (Convert.ToInt16(gi) <= 11)
                   {
                       dealerScore += Convert.ToInt16(gi);
                   }
                   else if (Convert.ToInt16(gi) > 11)
                   {
                       dealerScore += 10;
                   }
                   label10.Text = Convert.ToString(score);
                   client.Send("d#" + gi + "/" + txt);
               }
           }
    

            

        int test=0;
      
       
        private void button4_Click(object sender, EventArgs e)
        {

             if (test == 0)
            {
                player1.setCArd(random1.Next(2, 14));
                int card0 = player1.getCard();
                String g = Convert.ToString(card0);
                Shape shape1 = new Shape();
                Random rand = new Random();
                Card card;
                String s;
                if (card0 <= 11)
                {
                    score += card0;
                }
                else if (card0 > 11)
                {
                    score += 10;
                }
                label8.Text = Convert.ToString(score);
                client.Send("s"+Convert.ToString(score));
                int nr = rand.Next(1, 4);
                if (nr == 1)
                {
                    CardFactory cardfact = new CardFactory();
                    Shape.card sh = Shape.card.SPADES;
                    Image imge1 = cardfact.getShape(sh).draw(card0);
                    pictureBox4.Image = imge1;
                    s = "spades";
                    client.Send("!#" + g + "/" + s);

                }
                else if (nr == 2)
                {
                    CardFactory cardfact1 = new CardFactory();
                    Shape.card sh = Shape.card.HEART;
                    
                    Image imge1 = cardfact1.getShape(sh).draw(card0);
                    pictureBox4.Image = imge1;
                    s = "heart";
                    client.Send("!#" + g + "/" + s);

                }
                else if (nr == 3)
                {
                    CardFactory cardfact2 = new CardFactory();
                    Shape.card sh = Shape.card.DIAMONDS;
                
                    Image imge1 = cardfact2.getShape(sh).draw(card0);
                    pictureBox4.Image = imge1;
                    s = "diamonds";
                    client.Send("!#" + g + "/" + s);


                }
                else if (nr == 4)
                {
                    CardFactory cardfact3 = new CardFactory();
                    Shape.card sh = Shape.card.CLUBS;

                    Image imge1 = cardfact3.getShape(sh).draw(card0);
                    pictureBox4.Image = imge1;
                    s = "clubs";
                    client.Send("!#" + g + "/" + s);


                }

                test++;


            }
            else if (test == 1)
            {
                player1.setCArd(random1.Next(2, 14));
                int card0 = player1.getCard();
                String g = Convert.ToString(card0);
                Shape shape1 = new Shape();
                Random rand = new Random();
                Card card;
                String s;
                if (card0 <= 11)
                {
                    score += card0;
                }
                else if (card0 > 11)
                {
                    score += 10;
                }
                label8.Text = Convert.ToString(score);
                client.Send("s"+Convert.ToString(score));
                int nr = rand.Next(1, 4);
                if (nr == 1)
                {
                    CardFactory cardfact = new CardFactory();
                    Shape.card sh = Shape.card.SPADES;
                    Image imge1 = cardfact.getShape(sh).draw(card0);
                    pictureBox5.Image = imge1;
                    s = "spades";
                    client.Send("@#" + g + "/" + s);

                }
                else if (nr == 2)
                {
                    CardFactory cardfact1 = new CardFactory();
                    Shape.card sh = Shape.card.HEART;
                    Image imge1 = cardfact1.getShape(sh).draw(card0);
                    pictureBox5.Image = imge1;
                    s = "heart";
                    client.Send("@#" + g + "/" + s);

                }
                else if (nr == 3)
                {
                    CardFactory cardfact2 = new CardFactory();
                    Shape.card sh = Shape.card.DIAMONDS;
                    Image imge1 = cardfact2.getShape(sh).draw(card0);
                    pictureBox5.Image = imge1;
                    s = "diamonds";
                    client.Send("@#" + g + "/" + s);


                }
                else if (nr == 4)
                {
                    CardFactory cardfact3 = new CardFactory();
                    Shape.card sh = Shape.card.CLUBS;
                    Image imge1 = cardfact3.getShape(sh).draw(card0);
                    pictureBox5.Image = imge1;
                    s = "clubs";
                    client.Send("@#" + g + "/" + s);

                    


                }

        
            }
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(label8.Text)<21)
            {
                deal1 = dealer.generateCard();
                String g1 = dealer.getCardNumber();
                int card0 = Convert.ToInt32(g1);
                if (card0 <= 11)
                {
                    dealerScore+= card0;
                }
                else if (card0 > 11)
                {
                   dealerScore += 10;
                }
                label10.Text = Convert.ToString(score);
                client.Send("s" + Convert.ToString(score));
                String txt1 = dealer.getShape();
                client.Send("d#" + g1 + "/" + txt1);
                pictureBox11.Image = deal1;
                deal2 = dealer.generateCard();
                String g2 = dealer.getCardNumber();
                String txt2 = dealer.getShape();
                int card1 = Convert.ToInt32(g2);
                if (card1 <= 11)
                {
                    dealerScore += card0;
                }
                else if (card1 > 11)
                {
                    dealerScore += 10;
                }
                label10.Text = Convert.ToString(score);
                client.Send("d#" + g2 + "/" + txt2);
                pictureBox12.Image = deal2;
                deal3 = dealer.generateCard();
                String g3 = dealer.getCardNumber();
                String txt3 = dealer.getShape();
                int card2 = Convert.ToInt32(g3);
                if (card2 <= 11)
                {
                    dealerScore += card2;
                }
                else if (card2 > 11)
                {
                    dealerScore += 10;
                }
                label10.Text = Convert.ToString(score);
                client.Send("d#" + g3 + "/" + txt3);
                pictureBox13.Image = deal3;

            }
        }
           
         

    }

}

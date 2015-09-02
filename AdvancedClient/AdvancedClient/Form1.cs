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
using System.Threading;
using System.Media;
using System.Speech.Synthesis;

namespace AdvancedClient
{
    public delegate void Update(string txt);
    public delegate void ChangeLabel(string txt);
    public delegate void ChangeLabel2(string txt);
    public delegate void ChangeLabel8(string txt);
    public delegate void ChangeLabel11(string txt);
    public delegate void ChangeTextBox(string txt);
    public delegate void ChangeMoney(string txt);
    public partial class Form1 : Form
    {
        String clientName;
        public Form1(String a)
        {
            InitializeComponent();
            clientName = a;
            pictureBox10.Image.Tag = "checked";
            pictureBox11.Image.Tag = "checked";
            pictureBox12.Image.Tag = "checked";
            pictureBox13.Image.Tag = "checked";
            client = new Client();
            client.ClientName = clientName;
            //schimba ip--
            client.ServerIp = "192.168.56.1";
            client.ServerPort = "80";


            client.OnClientConnected += new OnClientConnectedDelegate(client_OnClientConnected);
            client.OnClientConnecting += new OnClientConnectingDelegate(client_OnClientConnecting);
            client.OnClientDisconnected += new OnClientDisconnectedDelegate(client_OnClientDisconected);
            client.OnClientError += new OnClientErrorDelegate(client_OnClientError);
            client.OnClientFileSending += new OnClientFileSendingDelegate(client_OnClientFileSending);
            client.OnDataReceived += new OnClientReceivedDelegate(client_OnClientRecivedDelegate);
            client.Connect();


        }


        Client client;
        int yourMoney;
        int dealerMoney;
        int opponentMoney;

        Card card;

        Player player1 = new Player();
        Player player2 = new Player();
        Dealer dealer = new Dealer();
        Random random = new Random();
        Random random1 = new Random();
        Random random2 = new Random();
        Random random3 = new Random();
        int scorePlyer1 = 0, scorePlayer2 = 0;
        String gi, txt;
        Image img, img1;
        Image deal1, deal2, deal3;



        int card2;
        int card5;
        int card6;
        int number;
        String shape;
        String dealermes;
        Boolean tests;
        String get, get1;
        int dealerScore = 0;


      
        public void ChageTextBox(string txt)
        {
            if (textBox3.InvokeRequired)
            {
                Invoke(new Update(ChageTextBox), new object[] { txt });
            }
            else
            {

                textBox3.Text += txt + "\r\n";

            }
        }

        public void ChageLabel8(string txt)
        {
            if (label9.InvokeRequired)
            {
                Invoke(new Update(ChageLabel8), new object[] { txt });
            }
            else
            {
                String[] m = txt.Split('s');
                player2mes = m[1];
                label9.Text = player2mes;


            }
        }

        public void ChageLabel(string txt)
        {
            if (label10.InvokeRequired)
            {
                Invoke(new Update(ChageLabel), new object[] { txt });
            }
            else
            {
                String[] m = txt.Split('s');
                dealermes = m[1];
                label10.Text = dealermes;


            }
        }
        public void ChageLabel11(string txt)
        {
            if (label11.InvokeRequired)
            {
                Invoke(new Update(ChageLabel11), new object[] { txt });
            }
            else
            {
                SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Senior);
                synthesizer.Volume = 100;  // 0...100
                synthesizer.Rate = 1; 

                String[] m = txt.Split('#');
                label11.Text = m[1];
                synthesizer.Speak(label11.Text);

                reload();
            }
        }
        public void ChangeMoney(string txt)
        {
            if (label11.InvokeRequired)
            {
                Invoke(new Update(ChangeMoney), new object[] { txt });
            }
            else
            {
                

                String[] m = txt.Split('#');
               opponentMoney += Convert.ToInt32(m[1]);
                label2.Text = Convert.ToString(yourMoney);
                
            }
        }

        public void ChangeLabel2(string txt)
        {
            if (label11.InvokeRequired)
            {
                Invoke(new Update(ChangeMoney), new object[] { txt });
            }
            else
            {


                String[] m = txt.Split('#');
                yourMoney += Convert.ToInt16(m[1]);
                label2.Text = Convert.ToString(m[1]);

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
            textBox3.Text = " ";
        }

       
           

        
        String player2mes;

        private void client_OnClientRecivedDelegate(object Sender, ClientReceivedArguments R)
        {

            String mesaj = R.ReceivedData;
            if (mesaj.StartsWith("opponent#"))
            {
                ChangeLabel2(mesaj);
            }
            if (mesaj.StartsWith("#"))
            {
                String[] text = mesaj.Split('/');
                String mesaj1 = text[0];
                String mesaj2 = text[1];
                int cardNumber = CardNumber(mesaj1);
                String cardShape = CardShape(mesaj2);
                scorePlayer2 += cardNumber;

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
                            Image imge1 = cardfact.getShape(sh).draw(card);
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
           int test = 0;
            if (mesaj.StartsWith("d#"))
            {

                if (pictureBox10.Image.Tag == "checked")
                {
                    pictureBox10.Image.Tag = "dealer";



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
                                dealer.setCArd(i);
                                int card = dealer.getCard();
                                CardFactory cardfact = new CardFactory();
                                Shape.card sh = Shape.card.HEART;
                                Image imge1 = cardfact.getShape(sh).draw(card);

                                pictureBox10.Image = imge1;

                            }

                            else if (cardShape == "diamonds")
                            {
                                dealer.setCArd(i);
                                int card = dealer.getCard();
                                CardFactory cardfact = new CardFactory();
                                Shape.card sh = Shape.card.DIAMONDS;
                                Image imge1 = cardfact.getShape(sh).draw(card);
                                pictureBox10.Image = imge1;


                            }
                            else if (cardShape == "clubs")
                            {
                                dealer.setCArd(i);
                                int card = dealer.getCard();
                                CardFactory cardfact = new CardFactory();
                                Shape.card sh = Shape.card.CLUBS;
                                Image imge1 = cardfact.getShape(sh).draw(card);
                                pictureBox10.Image = imge1;



                            }
                            else if (cardShape == "spades")
                            {
                                dealer.setCArd(i);
                                int card = dealer.getCard();
                                CardFactory cardfact = new CardFactory();
                                Shape.card sh = Shape.card.SPADES;
                                Image imge1 = cardfact.getShape(sh).draw(card);
                                pictureBox10.Image = imge1;


                            }

                        }
                    }
                   test++;
                }

            }

            if (mesaj.StartsWith("d2#"))
            {

                if (pictureBox12.Image.Tag == "checked")
                {
                    pictureBox12.Image.Tag = "dealer";
                    String[] text = mesaj.Split('/');
                    String mesaj1 = text[0];
                    String mesaj2 = text[1];
                    int cardNumber = CardNumberDealer2(mesaj1);
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

                                pictureBox12.Image = imge1;

                            }

                            else if (cardShape == "diamonds")
                            {
                                player1.setCArd(i);
                                int card = player1.getCard();
                                CardFactory cardfact = new CardFactory();
                                Shape.card sh = Shape.card.DIAMONDS;
                                Image imge1 = cardfact.getShape(sh).draw(card);
                                pictureBox12.Image = imge1;


                            }
                            else if (cardShape == "clubs")
                            {
                                player1.setCArd(i);
                                int card = player1.getCard();
                                CardFactory cardfact = new CardFactory();
                                Shape.card sh = Shape.card.CLUBS;
                                Image imge1 = cardfact.getShape(sh).draw(card);
                                pictureBox12.Image = imge1;



                            }
                            else if (cardShape == "spades")
                            {
                                player1.setCArd(i);
                                int card = player1.getCard();
                                CardFactory cardfact = new CardFactory();
                                Shape.card sh = Shape.card.SPADES;
                                Image imge1 = cardfact.getShape(sh).draw(card);
                                pictureBox12.Image = imge1;


                            }

                        }
                    }
                }


            }
            if (mesaj.StartsWith("d3#"))
            {
                if (pictureBox13.Image.Tag == "checked")
                {
                    pictureBox13.Image.Tag = "asad";

                    String[] text = mesaj.Split('/');
                    String mesaj1 = text[0];
                    String mesaj2 = text[1];
                    int cardNumber = CardNumberDealer3(mesaj1);
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

                                pictureBox13.Image = imge1;

                            }

                            else if (cardShape == "diamonds")
                            {
                                player1.setCArd(i);
                                int card = player1.getCard();
                                CardFactory cardfact = new CardFactory();
                                Shape.card sh = Shape.card.DIAMONDS;
                                Image imge1 = cardfact.getShape(sh).draw(card);
                                pictureBox13.Image = imge1;


                            }
                            else if (cardShape == "clubs")
                            {
                                player1.setCArd(i);
                                int card = player1.getCard();
                                CardFactory cardfact = new CardFactory();
                                Shape.card sh = Shape.card.CLUBS;
                                Image imge1 = cardfact.getShape(sh).draw(card);
                                pictureBox13.Image = imge1;



                            }
                            else if (cardShape == "spades")
                            {
                                player1.setCArd(i);
                                int card = player1.getCard();
                                CardFactory cardfact = new CardFactory();
                                Shape.card sh = Shape.card.SPADES;
                                Image imge1 = cardfact.getShape(sh).draw(card);
                                pictureBox13.Image = imge1;


                            }

                        }
                    }
                }
            }
            if (mesaj.StartsWith("d1#"))
            {

                if (pictureBox11.Image.Tag == "checked")
                {
                    pictureBox11.Image.Tag = "dada";
                    String[] text = mesaj.Split('/');
                    String mesaj1 = text[0];
                    String mesaj2 = text[1];
                    int cardNumber = CardNumberDealer1(mesaj1);
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

                                pictureBox11.Image = imge1;

                            }

                            else if (cardShape == "diamonds")
                            {
                                player1.setCArd(i);
                                int card = player1.getCard();
                                CardFactory cardfact = new CardFactory();
                                Shape.card sh = Shape.card.DIAMONDS;
                                Image imge1 = cardfact.getShape(sh).draw(card);
                                pictureBox11.Image = imge1;


                            }
                            else if (cardShape == "clubs")
                            {
                                player1.setCArd(i);
                                int card = player1.getCard();
                                CardFactory cardfact = new CardFactory();
                                Shape.card sh = Shape.card.CLUBS;
                                Image imge1 = cardfact.getShape(sh).draw(card);
                                pictureBox11.Image = imge1;



                            }
                            else if (cardShape == "spades")
                            {
                                player1.setCArd(i);
                                int card = player1.getCard();
                                CardFactory cardfact = new CardFactory();
                                Shape.card sh = Shape.card.SPADES;
                                Image imge1 = cardfact.getShape(sh).draw(card);
                                pictureBox11.Image = imge1;


                            }

                        }
                    }
                }
            }
            if (mesaj.StartsWith("w#"))
            {
                ChageLabel11(R.ReceivedData);
                

            }

            if (mesaj.StartsWith("*s"))
            {

                ChageLabel8(R.ReceivedData);

            }
            if (mesaj.StartsWith("ds"))
            {
                ChageLabel(R.ReceivedData);

            }
            if (mesaj.StartsWith("m#"))
            {
                ChangeMoney(R.ReceivedData);
            }
            else
            {


                ChageTextBox(R.ReceivedData);

            }

        }


        public int CardNumberDealer1(String mesaj)
        {
            String[] text = { "d1#0", "d1#1", "d1#2", "d1#3", "d1#4", "d1#5", "d1#6", "d1#7", "d1#8", "d1#9", "d1#10", "d1#11", "d1#12", "d1#13", "d1#14" };

            for (int i = 0; i <= 14; i++)
            {
                if (mesaj == text[i])
                    number = i;
            }
            return number;

        }
        public int CardNumberDealer2(String mesaj)
        {
            String[] text = { "d2#0", "d2#1", "d2#2", "d2#3", "d2#4", "d2#5", "d2#6", "d2#7", "d2#8", "d2#9", "d2#10", "d2#11", "d2#12", "d2#13", "d2#14" };

            for (int i = 0; i <= 14; i++)
            {
                if (mesaj == text[i])
                    number = i;
            }
            return number;

        }
        public int CardNumberDealer3(String mesaj)
        {
            String[] text = { "d3#0", "d3#1", "d3#2", "d3#3", "d3#4", "d3#5", "d3#6", "d3#7", "d3#8", "d3#9", "d3#10", "d3#11", "d3#12", "d3#13", "d3#14" };

            for (int i = 0; i <= 14; i++)
            {
                if (mesaj == text[i])
                    number = i;
            }
            return number;

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

            for (int i = 0; i <= 14; i++)
            {
                if (mesaj == text[i])
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
            foreach (String s in text)
            {
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
        int handNumber = 0;
        private void Start_Click(object sender, EventArgs e)
        {

            handNumber++;
            label12.Text = Convert.ToString(handNumber);
            if (handNumber < 7)
            {
                SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Senior);
                synthesizer.Volume = 100;  // 0...100
                synthesizer.Rate = 1;     // -10...10

                // Synchronous
                synthesizer.Speak("Deal");

                pictureBox2.Image = player1.generateCard(client, "#");
                String number = player1.getCardNumber();
                String shape = player1.getShape();
                if (Convert.ToInt32(number) <= 11)
                {
                    scorePlyer1 += Convert.ToInt16(number);


                }
                else if (Convert.ToInt32(number) > 11)
                {
                    scorePlyer1 += 10;


                }



                Player player3 = new Player();
                pictureBox3.Image = player3.generateCard(client, "$#");
                String number1 = player3.getCardNumber();
                String shape1 = player3.getShape();
                if (Convert.ToInt32(number1) <= 11)
                {
                    scorePlyer1 += Convert.ToInt32(number1);


                }
                else if (Convert.ToInt32(number1) > 11)
                {
                    scorePlyer1 += 10;

                }


                label8.Text = Convert.ToString(scorePlyer1);
                client.Send("*s" + Convert.ToString(scorePlyer1));


                if (pictureBox10.Image.Tag == "checked")
                {
                    pictureBox10.Image.Tag = "unchecked";
                    pictureBox10.Image = dealer.generateCard(client, "d#");
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
                    label10.Text = Convert.ToString(dealerScore);
                    client.Send("ds" + label10.Text);


                }

            }
            else
            {
                MessageBox.Show("End of game!"+"\n"+"Your score is :" + yourMoney+"\n"+
                                             "Opponent score is :"+opponentMoney+"\n"+
                                             "Dealer score is :"+dealerMoney);
            }

        }





        int testul = 0;


        private void button4_Click(object sender, EventArgs e)
        {

            if (testul == 0)
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
                    scorePlyer1 += card0;
                }
                else if (card0 > 11)
                {
                    scorePlyer1 += 10;
                }
                label8.Text = Convert.ToString(scorePlyer1);
                client.Send("*s" + Convert.ToString(scorePlyer1));
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

                testul=1;


            }
            else if (testul == 1)
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
                    scorePlyer1 += card0;
                }
                else if (card0 > 11)
                {
                    scorePlyer1 += 10;
                }
                label8.Text = Convert.ToString(scorePlyer1);
                client.Send("*s" + Convert.ToString(scorePlyer1));
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
           // gameWiner();
        }

        private void button6_Click(object sender, EventArgs e)
        {


            if (Convert.ToInt16(label8.Text) < 21 || Convert.ToInt16(label9.Text)<21)
                {
                    if (pictureBox11.Image.Tag == "checked")
                    {
                        pictureBox11.Image.Tag = "unchecked";
                        deal1 = dealer.generateCard(client, "d1#");
                        String g1 = dealer.getCardNumber();
                        int card0 = Convert.ToInt32(g1);
                        if (card0 <= 11)
                        {
                            dealerScore += card0;
                        }
                        else if (card0 > 11)
                        {
                            dealerScore += 10;
                        }

                        String txt1 = dealer.getShape();
                       
                        pictureBox11.Image = deal1;
                    }
                    if (pictureBox12.Image.Tag == "checked")
                    {
                        pictureBox12.Image.Tag = "unchacked";
                        deal2 = dealer.generateCard(client, "d2#");
                        String g2 = dealer.getCardNumber();
                        String txt2 = dealer.getShape();
                        int card1 = Convert.ToInt32(g2);
                        if (card1 <= 11)
                        {
                            dealerScore += card1;
                        }
                        else if (card1 > 11)
                        {
                            dealerScore += 10;
                        }
                        
                        pictureBox12.Image = deal2;

                    }
                    if (pictureBox13.Image.Tag == "checked")
                    {

                        pictureBox13.Image.Tag = "unchecked";
                    deal3 = dealer.generateCard(client, "d3#");
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
                    //  client.Send("ds" + Convert.ToString(dealerScore));
                    //    label10.Text = Convert.ToString(dealerScore);
                    // client.Send("d#" + g3 + "/" + txt3);
                    pictureBox13.Image = deal3;


                    
                    }
                    label10.Text = Convert.ToString(dealerScore);
                    client.Send("ds" + Convert.ToString(dealerScore));

                }
            gameWiner();
            }

        private void gameWiner()
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Senior);
            synthesizer.Volume = 100;  // 0...100
            synthesizer.Rate = 1;
            client.Send("m#" + label2.Text);
            dealerMoney = 10000;


              if (scorePlyer1 == 21)
            {
                label11.Text = "Black Jack";
                client.Send("w#" + label11.Text);
                synthesizer.Speak(label11.Text);
                yourMoney += dealerMoney * 3 / 2+opponentMoney;
                dealerMoney = 0 ;
                opponentMoney = 0; ;
                client.Send("opponent#" + opponentMoney);
            }
            if (scorePlayer2 == 21)
            {
                label11.Text = "Black Jack";
                client.Send("w#" + label11.Text);
                synthesizer.Speak(label11.Text);
               
                opponentMoney += dealerMoney * 3 / 2 + yourMoney; 
                dealerMoney = 0;
                yourMoney = 0;
                client.Send("opponent#" + opponentMoney);
            }
             if (dealerScore == 21)
            {
                label11.Text = "Black Jack";
                client.Send("w#" + label11.Text);
                synthesizer.Speak(label11.Text);
               
                dealerMoney += yourMoney + opponentMoney;
                yourMoney = 0 ;
                opponentMoney = 0;
                client.Send("opponent#" + opponentMoney);
            }
              if (dealerScore > 21 && scorePlayer2 < 21 && scorePlyer1 < 21)
            {
                label11.Text = " players win";
                client.Send("w#" + label11.Text);
                synthesizer.Speak(label11.Text);
                yourMoney += dealerMoney * 3 / 2;
                opponentMoney += dealerMoney * 3 / 2;
                if (dealerMoney > 0)
                {
                    dealerMoney -= 2 * (dealerMoney * 3 / 2);
                }
                else
                {
                    dealerMoney = 0;
                }
                client.Send("opponent#" + opponentMoney);
            }
             else if (dealerScore > 21 && scorePlyer1 < 21 && scorePlayer2 > 21)
            {
                label11.Text = "you win";
                client.Send("w#" + "your opponent wins");
                synthesizer.Speak(label11.Text);
                yourMoney += dealerMoney * 3 / 2+opponentMoney;
                if (dealerMoney > 0)
                {
                    dealerMoney -= (dealerMoney * 3 / 2);
                }
                else
                {
                    dealerMoney = 0;
                }
                if (opponentMoney > 0)
                {
                    opponentMoney -= (opponentMoney * 3 / 2);
                }
                else
                {
                    opponentMoney = 0;
                }
                client.Send("opponent#" + opponentMoney);

            }
             else if (dealerScore > 21 && scorePlayer2 > 21 && scorePlayer2 < 21)
            {
                label11.Text = "your opponent wins";
                client.Send("w#" + "you win");
                synthesizer.Speak(label11.Text);
                
                opponentMoney = dealerMoney * 3 / 2 + opponentMoney;
                if (dealerMoney > 0)
                {
                    dealerMoney -= (dealerMoney * 3 / 2);
                }
                else
                {
                    dealerMoney = 0;
                }
                yourMoney = 0;
                client.Send("opponent#" + opponentMoney);

            }
            else if (dealerScore < 21) {

                label11.Text = "dealer win";
                client.Send("w#" + label11.Text);
                synthesizer.Speak(label11.Text);
                dealerMoney += yourMoney + opponentMoney;
                if (yourMoney > 0)
                {
                    yourMoney -= (yourMoney * 3 / 2);
                }
                else
                {
                    yourMoney = 0;
                } if (opponentMoney > 0)
                {
                    opponentMoney -= (opponentMoney * 3 / 2);
                }
                else
                {
                    opponentMoney = 0; 
                }
                client.Send("opponent#" + opponentMoney);
                
            }

              else if (scorePlyer1 > 21)
              {
                  label11.Text = "you lost";
                  client.Send("w#" + "your opponent lost");
                  synthesizer.Speak(label11.Text);
                  opponentMoney += yourMoney;
                  yourMoney = 0;
                  client.Send("opponent#" + opponentMoney);

              }
              else if (scorePlayer2 > 21)
              {
                  label11.Text = "your opponent lost";
                  client.Send("w#" + "you lost");
                  synthesizer.Speak(label11.Text);
                  yourMoney += opponentMoney;
                  opponentMoney = 0;
                  client.Send("opponent#" + opponentMoney);
              }
              else if (dealerScore > 21)
              {
                  label11.Text = "dealer lost";
                  client.Send("w#" + label11.Text);
                  synthesizer.Speak(label11.Text);
                  opponentMoney = dealerScore * 3 / 2;
                  yourMoney = dealerMoney * 3 / 2;
                  if (dealerMoney > 0)
                  {
                      dealerMoney -= 2 * (dealerMoney * 3 / 2);
                  }
                  else
                  {
                      dealerMoney = 0;
                  }
                  client.Send("opponent#" + opponentMoney);

              }
            label2.Text =Convert.ToString(yourMoney);
            client.Send("opponent#" + Convert.ToString(opponentMoney));

            reload();
        }
        private void reload()
        {
            pictureBox2.Image = AdvancedClient.Properties.Resources.cardbg;
            pictureBox3.Image = AdvancedClient.Properties.Resources.cardbg;
            pictureBox4.Image = AdvancedClient.Properties.Resources.cardbg;
            pictureBox5.Image = AdvancedClient.Properties.Resources.cardbg;
            pictureBox6.Image = AdvancedClient.Properties.Resources.cardbg;
            pictureBox7.Image = AdvancedClient.Properties.Resources.cardbg;
            pictureBox8.Image = AdvancedClient.Properties.Resources.cardbg;
            pictureBox9.Image = AdvancedClient.Properties.Resources.cardbg;
            pictureBox10.Image = AdvancedClient.Properties.Resources.cardbg;
            pictureBox11.Image = AdvancedClient.Properties.Resources.cardbg;
            pictureBox12.Image = AdvancedClient.Properties.Resources.cardbg;
            pictureBox13.Image = AdvancedClient.Properties.Resources.cardbg;
            label10.Text = "0";
            label9.Text = "0";
            label8.Text = "0";
            scorePlyer1 = 0;
            scorePlayer2 = 0;
            dealerScore = 0;
            label11.Text = "new hand";
            pictureBox10.Image.Tag = "checked";
            pictureBox11.Image.Tag = "checked";
            pictureBox12.Image.Tag = "checked";
            pictureBox13.Image.Tag = "checked";

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Player player3 = new Player();
            pictureBox3.Image = player3.generateCard(client, "$#");
            String number1 = player3.getCardNumber();
            String shape1 = player3.getShape();
            if (Convert.ToInt32(number1) <= 11)
            {
                scorePlyer1 += Convert.ToInt32(number1);


            }
            else if (Convert.ToInt32(number1) > 11)
            {
                scorePlyer1 += 10;

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            yourMoney += 5;
            label2.Text =Convert.ToString(yourMoney);
        }

        private void button8_Click(object sender, EventArgs e)
        {

            yourMoney += 25;
            label2.Text = Convert.ToString(yourMoney);

        }
        
        private void button11_Click(object sender, EventArgs e)
        {
            yourMoney += 100;
            label2.Text = Convert.ToString(yourMoney);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            yourMoney += 500;
            label2.Text = Convert.ToString(yourMoney);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            yourMoney +=1000;
            label2.Text = Convert.ToString(yourMoney);
        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3(clientName, client, null);
            form3.ShowDialog();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

      

    }
}

using NetworksApi.TCP.CLIENT;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedClient
{
   public class Player{
       private String playerAction;
        private Random random = new Random();
        private String get,s;
        private int card { set; get; }
        private int sum { set; get; }

        public Player() { }

        public int getSum()
        {
            return sum;
        }

        public String getShape()
        {
            return s;
        }
        public int getCard()
        {
            return card;
        }
        public String getCardNumber(){
            return get;
        }

        public void setCArd(int card)
        {
            this.card = card;
        }

        public String getaction()
        {
            return playerAction;
        }
        public void setAction(String action)
        {
            this.playerAction = action;
        }

        public void setChooserCard(String playerAction)
        {
            this.playerAction = playerAction;
        }
        public Image generateCard(Client client,String mesaj)
        {



            int number = random.Next(2, 14);
            get = Convert.ToString(number);
            Random rand = new Random();
            int nrrr = rand.Next(1, 4);
            if (nrrr == 1)
            {

                CardFactory cardfact = new CardFactory();
                Shape.card sh1 = Shape.card.SPADES;
                Image imge1 = cardfact.getShape(sh1).draw(number);
                s = "spades";
                client.Send(mesaj + get + "/" + s);
                return imge1;

            }
            else if (nrrr == 2)
            {

                CardFactory cardfact1 = new CardFactory();
                Shape.card sh2 = Shape.card.HEART;
                Image imge1 = cardfact1.getShape(sh2).draw(number);          
                s = "heart";
                client.Send(mesaj + get + "/" + s);
                return imge1;



            }
            else if (nrrr == 3)
            {

                CardFactory cardfact2 = new CardFactory();
                Shape.card sh3 = Shape.card.DIAMONDS;
                Image imge1 = cardfact2.getShape(sh3).draw(number);
                s = "diamonds";
                client.Send(mesaj + get + "/" + s);
                return imge1;


            }
            else if (nrrr == 4)
            {

                CardFactory cardfact3 = new CardFactory();
                Shape.card sh4 = Shape.card.CLUBS;
                Image image1 = cardfact3.getShape(sh4).draw(number);
                s = "clubs";
                client.Send(mesaj + get + "/" + s);
                return image1;
            }

            return null;

        }
        



    }
}

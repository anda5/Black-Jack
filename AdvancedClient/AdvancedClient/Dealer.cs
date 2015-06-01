using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedClient
{
    class Dealer
    {
        String gi, txt;
        private Random random = new Random();
        private int card { set; get; }
        private String cardNumber { set; get; }
        private String cardShape { set; get; }
      

        public Dealer() { }
        public String getCardNumber()
        {
            return gi;
        }
        public String getShape()
        {
            return txt;
        }
     
        public int getCard(){
            return card;
        }

        public void setCArd(int card)
        {
            this.card = card;
        }

        public Image  generateCard(){

            
            int cardDealer = random.Next(2,14);
             gi = Convert.ToString(cardDealer);
            Shape shape2 = new Shape();
            Random randomm = new Random();
           
            int n = randomm.Next(1, 4);
            if (n == 1)
            {
                CardFactory cardfact = new CardFactory();
                Shape.card sh = Shape.card.SPADES;
                Image imge1 = cardfact.getShape(sh).draw(cardDealer);
                return imge1;

            }
            else if (n == 2)
            {
                CardFactory cardfact1 = new CardFactory();
                Shape.card sh = Shape.card.HEART;
                txt = cardfact1.getSh();
                Image imge1 = cardfact1.getShape(sh).draw(cardDealer);
                return imge1;

            }
            else if (n == 3)
            {
                CardFactory cardfact2 = new CardFactory();
                Shape.card sh = Shape.card.DIAMONDS;
                txt = cardfact2.getSh();
                Image imge1 = cardfact2.getShape(sh).draw(cardDealer);
                return imge1;


            }
            else if (n == 4)
            {
                CardFactory cardfact3 = new CardFactory();
                Shape.card sh = Shape.card.CLUBS;
                txt = cardfact3.getSh();
                Image imge1 = cardfact3.getShape(sh).draw(cardDealer);
                return imge1;


            }
            return null;

        }



    }
    
}

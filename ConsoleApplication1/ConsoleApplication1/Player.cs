using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Player
    {
            
       
        private String playerAction;
        private Random random = new Random();
        private int card { set; get; }
        private int sum { set; get; }

        public Player() { }

        public int getSum()
        {
            return sum;
        }

        public void setSum(int card)
        {
            this.sum= sum;
        }
        public int getCard(){
            return card;
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

        public void addChooserCard()
        {
          card = random.Next(10);
        }



    }
    }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Game
    {
        Player player1 = new Player();
        Player player2 = new Player();
        Random random = new Random();
     

        int card1;
        int card2;
        int card5;
        int card6;
       

        public Game()
        {
            player1.addChooserCard();
            card1 = player1.getCard();

            player1.addChooserCard();
            card2 = player1.getCard();



            player2.addChooserCard();
            card5 = player2.getCard();

            player2.setCArd(random.Next(10));
            card6 = player2.getCard();

            Console.WriteLine(card1+"    " +"     "+ card2 +"    "+ card5+"    " + card6);

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
             if (sum1 > sum2 && sum1>21 && sum2>21)
             {
                 Console.WriteLine("The winer is player 1");
             }
             else
             {
                 Console.WriteLine("The winer is player 2");
             }
        }

    }
}

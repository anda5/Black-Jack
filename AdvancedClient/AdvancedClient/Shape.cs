﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedClient
{
    class Shape
    {
        public enum card
        {
            CLUBS,
            DIAMONDS,
            HEART,
            SPADES

        }
        public Shape() { }

        public Card generateShape()
        {
            Random rand = new Random();
            Card card;
            int nr = rand.Next(1, 4);
            if (nr == 1)
            {
                CardFactory cardfact = new CardFactory();
                Shape.card sh = Shape.card.SPADES;
                return cardfact.getShape(sh);

            }
            else if (nr == 2)
            {
                CardFactory cardfact1 = new CardFactory();
                Shape.card sh = Shape.card.HEART;
                return cardfact1.getShape(sh);
            }
            else if (nr == 3)
            {
                CardFactory cardfact2 = new CardFactory();
                Shape.card sh = Shape.card.DIAMONDS;
                return cardfact2.getShape(sh);
            }
            else if (nr == 4)
            {
                CardFactory cardfact3 = new CardFactory();
                Shape.card sh = Shape.card.CLUBS;
                return cardfact3.getShape(sh);
            }


            return null;

        }
    }

}

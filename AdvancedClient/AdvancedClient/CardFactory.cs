using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedClient
{
    class CardFactory
    {
        String s;

        public Card getShape(Shape.card shapeType)
        {
            if (shapeType == null)
            {
                return null;
            }
            if (shapeType.Equals(Shape.card.CLUBS))
            {
                return new Clubs();
                s = "clubs";
                

            }
            else if (shapeType.Equals(Shape.card.DIAMONDS))
            {
                return new Diamonds();
                s = "diamonds";

            }
            else if (shapeType.Equals(Shape.card.HEART))
            {
                return new Hearts();
                s = "heart";
            }
            else if (shapeType.Equals(Shape.card.SPADES))
            {
                return new Spades();
                s = "spades";
            }

            return null;
        }
        public String getSh()
        {
            return s;
        }

    }
}

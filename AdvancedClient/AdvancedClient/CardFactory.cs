using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedClient
{
    class CardFactory
    {


        public Card getShape(Shape.card shapeType)
        {
            if (shapeType == null)
            {
                return null;
            }
            if (shapeType.Equals(Shape.card.CLUBS))
            {
                return new Clubs();

            }
            else if (shapeType.Equals(Shape.card.DIAMONDS))
            {
                return new Diamonds();

            }
            else if (shapeType.Equals(Shape.card.HEART))
            {
                return new Hearts();
            }
            else if (shapeType.Equals(Shape.card.SPADES))
            {
                return new Spades();
            }

            return null;
        }

    }
}

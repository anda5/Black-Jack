using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedClient
{
    class Diamonds:Card
    {
        public Image draw(int number)
        {
            Image img;

            switch (number)
            {
                case 1: img = AdvancedClient.Properties.Resources.d11;
                    return img;
                    break;
                case 2: img = AdvancedClient.Properties.Resources.d2;
                    return img;
                    break;
                case 3: img = AdvancedClient.Properties.Resources.d3;
                    return img;
                    break;
                case 4: img = AdvancedClient.Properties.Resources.d4;
                    return img;
                    break;
                case 5: img = AdvancedClient.Properties.Resources.d5;
                    return img;
                    break;
                case 6: img = AdvancedClient.Properties.Resources.d6;
                    return img;
                    break;
                case 7: img = AdvancedClient.Properties.Resources.d7;
                    return img;
                    break;
                case 8: img = AdvancedClient.Properties.Resources.d8;
                    return img;
                    break;
                case 9: img = AdvancedClient.Properties.Resources.d9;
                    return img;
                    break;
                case 10: img = AdvancedClient.Properties.Resources.d10;
                    return img;
                    break;
                case 11: img = AdvancedClient.Properties.Resources.d11;
                    return img;
                    break;

            }
            return null;
        }
    }
}

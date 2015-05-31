using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedClient
{
    class Spades:Card
    {
        public Image draw(int number)
        {
            Image img;

            switch (number)
            {
                case 1: img = AdvancedClient.Properties.Resources.s11;
                    return img;
                    break;
                case 2: img = AdvancedClient.Properties.Resources.s2;
                    return img;
                    break;
                case 3: img = AdvancedClient.Properties.Resources.s3;
                    return img;
                    break;
                case 4: img = AdvancedClient.Properties.Resources.s4;
                    return img;
                    break;
                case 5: img = AdvancedClient.Properties.Resources.s5;
                    return img;
                    break;
                case 6: img = AdvancedClient.Properties.Resources.s6;
                    return img;
                    break;
                case 7: img = AdvancedClient.Properties.Resources.s7;
                    return img;
                    break;
                case 8: img = AdvancedClient.Properties.Resources.s8;
                    return img;
                    break;
                case 9: img = AdvancedClient.Properties.Resources.s9;
                    return img;
                    break;
                case 10: img = AdvancedClient.Properties.Resources.s10;
                    return img;
                    break;
                case 11: img = AdvancedClient.Properties.Resources.s11;
                    return img;
                    break;
                case 12: img = AdvancedClient.Properties.Resources.s12;
                    return img;
                    break;
                case 13: img = AdvancedClient.Properties.Resources.s13;
                    return img;
                    break;
                case 14: img = AdvancedClient.Properties.Resources.s14;
                    return img;
                    break;

            }
            return null;
        }
    }
}

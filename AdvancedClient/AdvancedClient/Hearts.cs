using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedClient
{
    class Hearts:Card
    {
        public Image draw(int number)
        {
            Image img;

            switch (number)
            {
                
                case 2: img = AdvancedClient.Properties.Resources.h2;
                    return img;
                    break;
                case 3: img = AdvancedClient.Properties.Resources.h3;
                    return img;
                    break;
                case 4: img = AdvancedClient.Properties.Resources.h4;
                    return img;
                    break;
                case 5: img = AdvancedClient.Properties.Resources.h5;
                    return img;
                    break;
                case 6: img = AdvancedClient.Properties.Resources.h6;
                    return img;
                    break;
                case 7: img = AdvancedClient.Properties.Resources.h7;
                    return img;
                    break;
                case 8: img = AdvancedClient.Properties.Resources.h8;
                    return img;
                    break;
                case 9: img = AdvancedClient.Properties.Resources.h9;
                    return img;
                    break;
                case 10: img = AdvancedClient.Properties.Resources.h10;
                    return img;
                    break;
                case 11: img = AdvancedClient.Properties.Resources.h11;
                    return img;
                    break;
                case 12: img = AdvancedClient.Properties.Resources.h12;
                    return img;
                    break;
                case 13: img = AdvancedClient.Properties.Resources.h13;
                    return img;
                    break;
                case 14: img = AdvancedClient.Properties.Resources.h14;
                    return img;
                    break;
               
                    

            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedClient
{
    class Clubs:Card
    {

        public Image draw(int number)
        {
            Image img;
            
            switch (number)
            {
               
                case 2: img = AdvancedClient.Properties.Resources.t2;
                    return img;
                    break;
                case 3: img = AdvancedClient.Properties.Resources.t3;
                    return img;
                    break;
                case 4: img = AdvancedClient.Properties.Resources.t4;
                    return img;
                    break;
                case 5: img = AdvancedClient.Properties.Resources.t5;
                    return img;
                    break;
                case 6: img = AdvancedClient.Properties.Resources.t6;
                    return img;
                    break;
                case 7: img = AdvancedClient.Properties.Resources.t7;
                    return img;
                    break;
                case 8: img = AdvancedClient.Properties.Resources.t8;
                    return img;
                    break;
                case 9: img = AdvancedClient.Properties.Resources.t9;
                    return img;
                    break;
                case 10: img = AdvancedClient.Properties.Resources.t10;
                    return img;
                    break;
                case 11: img = AdvancedClient.Properties.Resources.t11;
                    return img;
                    break;
                case 12: img = AdvancedClient.Properties.Resources.t12;
                    return img;
                    break;
                case 13: img = AdvancedClient.Properties.Resources.t13;
                    return img;
                    break;
                case 14: img = AdvancedClient.Properties.Resources.t14;
                    return img;
                    break;
               
            }
            return null;
            
        }
        
    }
}

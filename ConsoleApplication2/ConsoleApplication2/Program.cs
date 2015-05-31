using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)

        {
            String text = "#5#clubs";
            String[] s = text.Split('#','#');
            Console.WriteLine(s[0]);
            Console.WriteLine(s[1]);
            Console.ReadLine();

        }
    }
}

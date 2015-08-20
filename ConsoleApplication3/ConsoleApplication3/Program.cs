using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> parsedData = new List<string[]>();

            try
            {
                String path = @"C:\\Users\anda\Desktop\Anda.txt";
                    StreamReader readFile = new StreamReader(path);
                    string line;
                    string[] row;

                    while ((line = readFile.ReadLine()) != null)
                    {
                        row = line.Split(',');
                        parsedData.Add(row);
                        Console.WriteLine(row.First());
                        Console.Read();
                    }
                //    Console.WriteLine(parsedData[0]);
                  //  Console.Read();
                }
            
            catch (Exception e)
            {
              
            }

        
          Console.Read();
        }
    }
}

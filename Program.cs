using System;

namespace CSharpStats
{
    class Program
    {
        static void Main(string[] args)
        {
/* 
            if(args.Length > 0)
            {
                string s = "";
                for (int i = 0; i < args.Length; i++)
                {
                    s += args[i];
                    s += ", ";
                }
                Console.WriteLine("command-line args: " + s);
            }
            // Console.WriteLine("Hello, world!");
            string outStr = "Enter a string: ";
            Console.Write(outStr);
            string inStr = Console.ReadLine();  // change .vscode/launch.json to allow input in integrated terminal
            outStr = "You entered: " + inStr;
            Console.WriteLine(outStr); 
*/

            Console.Write("Enter 1 for keyboard input, 2 for file input: ");
            string inStr = Console.ReadLine();
            int mode = Int32.Parse(inStr);
            if (mode == 1)
            {
                Console.WriteLine("When no more data is left to enter, simply hit return.");
                double n = 0.0;
                double term = 0.0;
                double sum = 0.0;
                double mean = 0.0;
                double max = -1.0E10;
                double min = 1.0E10;
                double stdev = 0.0;
                //int sLen = 1;
                string s; 
                while(true)
                {
                    Console.Write("Data point {0}: ", n+1);
                    s = Console.ReadLine();
                    //bool isNull = (s == null);
                    int sLen = s.Length;
                    //Console.WriteLine("You entered: {0}; isNull = {1}, sLen = {2}", s, isNull, sLen);
                    if (sLen == 0)
                    {
                        break;
                    }
                    n++;
                    term = Double.Parse(s);
                    if (term > max)
                    {
                        max = term;
                    }
                    if (term < min)
                    {
                        min = term;
                    }
                    sum += term;
                }
                if (n > 0)
                {
                    mean = sum / n;
                    Console.WriteLine("\nFor {0:F0} data points: ", n);
                    Console.WriteLine("   the mean (average) is {0:0.00}", mean);
                    Console.WriteLine("   the maximum is {0:0.00}", max);
                    Console.WriteLine("   the minimum is {0:0.00}", min);
                }
                else
                {
                    Console.WriteLine("\nNo data was entered.");
                }
            }
            else if (mode == 2)
            {

            }
            else
            {
                Console.WriteLine("\nInvalid mode; exiting program.");
            }

        }
    }
}

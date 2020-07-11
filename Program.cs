using System;
using System.Collections.Generic;

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
*/
            List<double> dArrL = new List<double>();

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
                string s; 
                while (true)
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
                    term = Double.Parse(s);
                    if (term > max)
                    {
                        max = term;
                    }
                    if (term < min)
                    {
                        min = term;
                    }
                    dArrL.Add(term);
                    n++;
                    sum += term;
                }
                if (n > 0)
                {
                    mean = sum / n;
                    Console.WriteLine("\nFor {0:F0} data points: ", n);
                    Console.WriteLine("   the maximum is {0:0.00}", max);
                    Console.WriteLine("   the minimum is {0:0.00}", min);
                    Console.WriteLine("   the mean (average) is {0:0.00}", mean);
                    if (n > 1)
                    {
                        sum = 0.0;
                        for (int i = 0; i < n; i++)
                        {
                            //term = dArr[i] - mean;
                            term = dArrL[i] - mean;
                            sum += term * term;
                            stdev = Math.Sqrt(sum / (double) (n - 1));
                        }
                        Console.WriteLine("   the std dev is {0:0.00}", stdev);
                    }
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

/*
EHKs-MBP:CSharpStats ehk$ dotnet run
Enter 1 for keyboard input, 2 for file input: 1
When no more data is left to enter, simply hit return.
Data point 1: 6
Data point 2: 1
Data point 3: 5
Data point 4: 2
Data point 5: 3
Data point 6: 4
Data point 7: 

For 6 data points: 
   the maximum is 6.00
   the minimum is 1.00
   the mean (average) is 3.50
   the std dev is 1.87

EHKs-MBP:CSharpStats ehk$ dotnet run
Enter 1 for keyboard input, 2 for file input: 1
When no more data is left to enter, simply hit return.
Data point 1: 3.5
Data point 2: 

For 1 data points: 
   the maximum is 3.50
   the minimum is 3.50
   the mean (average) is 3.50

EHKs-MBP:CSharpStats ehk$ dotnet run
Enter 1 for keyboard input, 2 for file input: 1
When no more data is left to enter, simply hit return.
Data point 1: 

No data was entered.

*/









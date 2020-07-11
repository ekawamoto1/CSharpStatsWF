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
            int n = 0;
            double[] minmax = new double[2];
            double term, mean, stdev;
            string s;
            int sLen;

            Console.Write("Enter 1 for keyboard input, 2 for file input: ");
            string inStr = Console.ReadLine();
            int mode = Int32.Parse(inStr);
            if (mode == 1)
            {
                Console.WriteLine("When no more data is left to enter, simply hit return.");
                while (true)
                {
                    Console.Write("Data point {0}: ", n+1);
                    s = Console.ReadLine();
                    sLen = s.Length;
                    if (sLen == 0)
                    {
                        break;
                    }
                    term = Double.Parse(s);
                    dArrL.Add(term);
                    n++;
                }

                if (n > 0)
                {
                    minmax = ComputeExtremes(dArrL);
                    mean = ComputeMean(dArrL);
                    Console.WriteLine("\nFor {0:F0} data points: ", n);
                    Console.WriteLine("   the maximum is {0:0.00}", minmax[1]);
                    Console.WriteLine("   the minimum is {0:0.00}", minmax[0]);
                    Console.WriteLine("   the mean (average) is {0:0.00}", mean);
                    if (n > 1)
                    {
                        stdev = ComputeStdev(dArrL, mean);
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
                Console.Write("Enter pathname of data file: ");
                string fName = Console.ReadLine();


            }
            else
            {
                Console.WriteLine("\nInvalid mode; exiting program.");
            }

        }


        private static void PrintDataPoints(List<Double> inArr)
        {
            int n = inArr.Count;
            
            if (n > 0)
            {
                if (n < 10)    // print all data points
                {
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine("Data point {0}: {1:0.00}\n", i + 1, inArr[i]);
                    }
                }
                else    // just print first and last five data points
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine("Data point {0}: {1:0.00}\n", i + 1, inArr[i]);
                    }
                    Console.WriteLine("     ... ");
                    for (int i = n - 5; i < n; i++)
                    {
                        Console.WriteLine("Data point {0}: {1:0.00}\n", i + 1, inArr[i]);
                    }                    
                }
            }
            
            return;
        }


        private static double[] ComputeExtremes(List<Double> inArr)
        {
            double[] extremes = {0.0, 0.0};
            int n = inArr.Count;
            
            if (n > 0)
            {
                double max = -1.0E10;
                double min = 1.0E10;
                double term;
                for (int i = 0; i < n; i++)
                {
                    term = inArr[i];
                    if (term > max)
                    {
                        max = term;
                    }
                    if (term < min)
                    {
                        min = term;
                    }
                }
                extremes[0] = min;
                extremes[1] = max;
            }
            
            return extremes;
        }


        private static double ComputeMean(List<double> inArr)
        {
            double mean = 0.0;
            int n = inArr.Count;
            
            if (n > 0)
            {
                double sum = 0.0;
                for (int i = 0; i < n; i++)
                {
                    sum += inArr[i];
                }
                mean = sum / (double) n;
            }
            
            return mean;    // returns 0 if n < 1
        }


        private static double ComputeStdev(List<double> inArr, double mean)
        {
            double stdev = 0.0;
            int n = inArr.Count;
            
            if (n > 1)
            {
                double sum = 0.0;
                double term = 0.0;
                for (int i = 0; i < n; i++)
                {
                    term = inArr[i] - mean;
                    sum += term * term;
                }
                stdev = Math.Sqrt(sum / (double) (n - 1));
            }

            return stdev;    // returns 0 if n < 2
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









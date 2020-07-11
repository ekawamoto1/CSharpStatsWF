using System;

namespace CSharpStats
{
    class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}

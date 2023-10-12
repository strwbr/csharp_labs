using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testCmdArgs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFile = args[0];
            string outputFile = args[1];
            Console.WriteLine("Input file path = " + inputFile);
            Console.WriteLine("Output file path = " + outputFile);

            Console.ReadKey(true);
        }
    }
}

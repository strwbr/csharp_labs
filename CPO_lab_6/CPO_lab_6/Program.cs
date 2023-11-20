using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stationery stationery = new Folder();
            stationery.ReadFromConsole();

            Console.WriteLine("\nДО:");
            stationery.Print();

            Console.WriteLine("\nПОСЛЕ:");
            stationery.Edit();
            stationery.Print();

            Console.ReadKey(true);
        }
    }
}

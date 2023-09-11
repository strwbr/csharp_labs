using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_1_task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = -1, b = -1;
            float dx = 1;
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Введите диапазон [a, b]:");
                Console.Write("a = ");
                a = Convert.ToInt32(Console.ReadLine());

                Console.Write("b = ");
                b = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите шаг dt: ");
                dx = float.Parse(Console.ReadLine());

                flag = a > b || dx <= 0;
                if (flag)
                    Console.WriteLine("Неправильные данные.Повторите ввод\n");
            }

            //Console.WriteLine(a + " " + b + " " + dx);
            WriteTable(a, b, dx);

            Console.ReadKey(true);
        }

        static void WriteTable(int a, int b, float dx)
        {
            Console.WriteLine("");
            Console.WriteLine("_____________________________");
            Console.WriteLine("{0, 10} |{1, 10}", "x", "y");
            Console.WriteLine("_____________________________");
            for (float x = a; x <= b; x += dx)
            {
                Console.WriteLine("{0, 10} |{1, 10}", x, Function(x));
            }
        }

        static float Function(float x)
        {
            // x^3 - 8x^2 + 11x + 20x = x(x(x-8)+11)+20
            return x * (x * (x - 8) + 11) + 20;
        }

    }
}

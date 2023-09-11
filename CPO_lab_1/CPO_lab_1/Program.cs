using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i;
            Console.WriteLine("Число точек:");
            int n = Input(2, 10);

            float[] x = new float[n]; // создать массив на n элементов
            float[] y = new float[n];
            Console.WriteLine("\n Координаты: ");
            for (i = 0; i < n; i++)
            {
                Console.Write("x[" + i + "] = ");
                string temp = Console.ReadLine();
                x[i] = Convert.ToInt32(temp);
                Console.Write("y[" + i + "] = ");
                y[i] = Convert.ToInt32(Console.ReadLine());
            }

            //Console.WriteLine("/n You've entered:");
            //for (i = 0; i < n; i++)
            //{
            //    Console.WriteLine("x[{0}] = {1}     | y[{0}] = {2}", i + 1, x[i], y[i]);
            //}

            WriteTable(x, y);

            // НЕ УДАЛЯТЬ, ИНАЧЕ КОНСОЛЬ ЗАКРЫВАЕТСЯ
            Console.ReadKey(true);
        }

        static void WriteTable(float[] x, float[] y)
        {
            Console.WriteLine("");
            Console.WriteLine("_____________________________");
            Console.WriteLine("{0, 10} |{1, 10}", "x", "y");
            Console.WriteLine("_____________________________");
            for (int i = 0; i < x.Length; i++)
            {
                Console.WriteLine("{0, 10} |{1, 10}", x[i], y[i]);
            }
            Console.WriteLine("_____________________________");
            Console.WriteLine("");
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("{0, 10} |{1, 10}    |{2, 10}", "", "x", "y");
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("{0, 10} |{1, 10}    |{2, 10}", "min", x.Min(), y.Max());
            Console.WriteLine("{0, 10} |{1, 10}    |{2, 10}", "max", x.Max(), y.Max());
            Console.WriteLine("{0, 10} |{1, 10}    |{2, 10}", "mean", x.Average(), y.Average());
            Console.WriteLine("_____________________________________________");
        }

        static int Input(int min, int max)
        {
            int n = -1;
            bool bad = true;
            while (bad)
            {
                Console.WriteLine("Введите целое число в диапазоне {0}..{1}", min, max);
                n = Convert.ToInt32(Console.ReadLine());
                // очистка буфера?????
                bad = n < min || max < n;
                if (bad)
                {
                    Console.WriteLine("Вне диапазона {0}..{1}", min, max);
                    // ждем реакцию ????
                }
            }
            return n;
        }
    }
}

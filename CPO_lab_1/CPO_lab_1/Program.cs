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
            Console.WriteLine("Number of points:");
            int n = Input(2, 10);

            float[] x = new float[n]; // создать массив на n элементов
            float[] y = new float[n];
            Console.WriteLine("\n Points Coordinates: ");
            for (i = 0; i < n; i++)
            {
                Console.Write("x[" + i + "] = ");
                string temp = Console.ReadLine();
                x[i] = Convert.ToInt32(temp);
                Console.WriteLine("y[" + i + "] = ");
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
            Console.WriteLine("_____________________________________");
            Console.WriteLine("{0, 10}    |{1, 10}", "x", "y");
            Console.WriteLine("_____________________________________");
            for (int i = 0; i < x.Length; i++)
            {
                Console.WriteLine("{0, 10}    |{1, 10}", x[i], y[i]);
            }
            Console.WriteLine("_____________________________________");
            Console.WriteLine("");
            Console.WriteLine("________________________________________________________");
            float xmin = Min(x);
            float ymin = Min(y);
            float xmax = Max(x);
            float ymax = Max(y);
            float xmean = Mean(x);
            float ymean = Mean(y);
            Console.WriteLine("{0, 10}    |{1, 10}    |{2, 10}", "", "x", "y");
            Console.WriteLine("________________________________________________________");
            Console.WriteLine("{0, 10}    |{1, 10}    |{2, 10}", "min", xmin, ymin);
            Console.WriteLine("{0, 10}    |{1, 10}    |{2, 10}", "max", xmax, ymax);
            Console.WriteLine("{0, 10}    |{1, 10}    |{2, 10}", "mean", xmean, ymean);
            Console.WriteLine("________________________________________________________");
        }

        static float Min(float[] array)
        {
            float min = 0;
            foreach (float i in array)
            {
                if (min > i)
                {
                    min = i;
                }
            }
            return min;
        }

        static float Max(float[] array)
        {
            float max = 0;
            foreach (float i in array)
            {
                if (max < i)
                    max = i;
            }
            return max;
        }

        static float Mean(float[] array)
        {
            float mean = 0;
            foreach (float i in array)
            {
                mean += i;
            }
            mean /= array.Length;
            return mean;
        }

        static int Input(int min, int max)
        {
            int n = -1;
            bool bad = true;
            while (bad)
            {
                Console.WriteLine("Enter an integer " + min + ".." + max);
                n = Convert.ToInt32(Console.ReadLine());
                // очистка буфера?????
                bad = n < min || max < n;
                if (bad)
                {
                    Console.WriteLine("Out of range " + min + ".." + max);
                    // ждем реакцию ????
                }
            }
            return n;
        }
    }
}

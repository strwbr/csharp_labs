using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float a = -1f, b = -1f;
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Введите диапазон [a, b]:");
                Console.Write("a = ");
                a = float.Parse(Console.ReadLine());

                Console.Write("b = ");
                b = float.Parse(Console.ReadLine());

                flag = a > b;
                if (flag)
                    Console.WriteLine("Неправильные данные. Повторите ввод\n");
            }
            float e = 0.0001f; // точность
            float result = Y(a, b, e);
            Console.WriteLine("Корень полинома на отрезке [{0}, {1}] = {3}"б
                a, b, result);

            Console.ReadKey(true);
        }

        static float Y(float a, float b, float e)
        {
            float mid = (a + b) / 2;
            while (true)
            {
                if (Function(mid) == 0.0f || Math.Abs(b - a) < Math.Abs(e))
                    return mid;
                if (Function(a) * Function(mid) < 0.0f)
                    b = mid;
                if (Function(a) * Function(mid) > 0.0f) // else
                    a = mid;
            }
        }

        static float Function(float x)
        {
            // x^3 - 8x^2 + 11x + 20x = x(x(x-8)+11)+20
            return x * (x * (x - 8) + 11) + 20;
        }
    }
}

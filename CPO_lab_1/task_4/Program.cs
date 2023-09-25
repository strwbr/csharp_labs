using System;

/* Программа, которая на заданном отрезке 
выполняет поиск одного из корней полинома
методом деления отрезка пополам.
Границы отрезка вводяться с клавиатуры.*/
namespace task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Границы отрезка
            float a = -1f, b = -1f;
            // Ввод границ отрезка
            bool isWrongInput = true;
            while (isWrongInput)
            {
                Console.WriteLine("Введите границы отрезка [a, b]:");
                Console.Write("a = ");
                a = float.Parse(Console.ReadLine());

                Console.Write("b = ");
                b = float.Parse(Console.ReadLine());

                // Проверка на правильность ввода
                isWrongInput = a > b;
                // Если границы отрезка неправильные, то запрашиваются новые значения
                if (isWrongInput)
                    Console.WriteLine("Неправильные данные. Повторите ввод\n");
            }
            // Точность
            float e = 0.000000001f;
            // Вычисление результата
            float result = Y(a, b, e);
            Console.WriteLine("Корень полинома на отрезке [{0}, {1}] = {2}", a, b, result);

            Console.ReadKey(true);
        }

        // Поиск одного из корней методом деления отрезка пополам
        static float Y(float a, float b, float e)
        {
            while (true)
            {
                float mid = (a + b) / 2;

                if (Polynomial(mid) == 0.0f || Math.Abs(b - a) < Math.Abs(e))
                    return mid;
                if (Polynomial(a) * Polynomial(mid) > 0.0f)
                    a = mid;
                else 
                    b = mid;
            }
        }

        // Полином
        static float Polynomial(float x)
        {
            // x^3 - 8x^2 + 11x + 20x
            return (x + 1) * (x - 4) * (x - 5);
        }
    }
}

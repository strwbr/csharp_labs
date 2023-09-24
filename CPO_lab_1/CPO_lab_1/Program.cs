using System;
using System.Linq;

/* Программа я реализует ввод точек 
экспериментально полученной зависимости y = f(x), 
вывод их в виде таблицы, вычисляет и выводит в виде таблицы сумму,
среднее арифметическое, минимальное и максимальное значения по X и по Y.*/
namespace CPO_lab_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ввод количества точек
            Console.WriteLine("Число точек");
            int pointsNum = Input(2, 10);

            // Массивы значений точек; их размер = pointsNum
            float[] x = new float[pointsNum]; 
            float[] y = new float[pointsNum];

            // Ввод точек
            Console.WriteLine("\nКоординаты: ");
            for (int i = 0; i < pointsNum; i++)
            {
                Console.Write("x[" + i + "] = ");
                x[i] = Convert.ToInt32(Console.ReadLine());
                Console.Write("y[" + i + "] = ");
                y[i] = Convert.ToInt32(Console.ReadLine());
            }

            // Вывод таблиц
            WriteTable(x, y);

            // Ожидание реакции пользователя (не закрывает сразу консоль)
            Console.ReadKey(true);
        }
        
        // Вывод таблицы со значениями точек, сред.арифм., мин и макс по Х и У
        static void WriteTable(float[] x, float[] y)
        {
            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine("{0, 10} |{1, 10} |{2, 10}", "", "x", "y");
            Console.WriteLine("---------------------------------------------");
            for (int i = 0; i < x.Length; i++)
            {
                Console.WriteLine("{0, 10} |{1, 10} |{2, 10}","", x[i], y[i]);
            }
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("{0, 10} |{1, 10} |{2, 10}", "Минимум", x.Min(), y.Min());
            Console.WriteLine("{0, 10} |{1, 10} |{2, 10}", "Максимум", x.Max(), y.Max());
            Console.WriteLine("{0, 10} |{1, 10} |{2, 10}", "Среднее", x.Average(), y.Average());
            Console.WriteLine("---------------------------------------------");
        }

        // Ввод количества точек
        static int Input(int min, int max)
        {
            int n = -1;
            bool isWrongInput = true;
            while (isWrongInput)
            {
                Console.Write("Введите целое число в диапазоне [{0}; {1}]: ", min, max);
                n = Convert.ToInt32(Console.ReadLine());
                // Проверка на принадлежность диапазону
                isWrongInput = n < min || max < n;
                // Если не принадлежит, запрашивается новое значение
                if (isWrongInput)
                {
                    Console.WriteLine("Вне диапазона [{0}; {1}]\n", min, max);
                }
            }
            return n;
        }
    }
}

using System;

/* Программа, которая для полинома x^3 - 8x^2 + 11x + 20x выводит таблицу значений по X и Y.
Диапазон и шаг изменения Х вводяться с клавиатуры. */
namespace CPO_lab_1_task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Границы диапазона
            int a = -1, b = -1;
            // Шаг изменения
            float dx = 1;
            // Ввод диапазона и шага изменения
            bool isWrongInput = true;
            while (isWrongInput)
            {
                Console.WriteLine("Введите диапазон [a, b]:");
                Console.Write("a = ");
                a = Convert.ToInt32(Console.ReadLine());

                Console.Write("b = ");
                b = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите шаг dt: ");
                dx = float.Parse(Console.ReadLine());
                // Проверка на правильность ввода
                isWrongInput = a > b || dx <= 0;
                // Если диапазон или шаг неправильные, то запрашиваются новые значения
                if (isWrongInput)
                    Console.WriteLine("Неправильные данные. Повторите ввод\n");
            }
            // Вывод таблицы
            WriteTable(a, b, dx);

            // Ожидание реакции пользователя (не закрывает сразу консоль)
            Console.ReadKey(true);
        }

        // Вывод таблицы со значениями Х и У
        static void WriteTable(int a, int b, float dx)
        {
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine("{0, 10} |{1, 10}", "x", "y");
            Console.WriteLine("-----------------------------");
            for (float x = a; x <= b; x += dx)
            {
                Console.WriteLine("{0, 10} |{1, 10}", x, Polynomial(x));
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

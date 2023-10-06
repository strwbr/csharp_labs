using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_2
{
    internal class MainClass
    {
        static void Main(string[] args)
        {
            Stationery[] Data = null; // массив набора объектов
            string path = "data/data.txt"; // путь к файлу

            bool flag = true; // флаг работы программы
            while (flag)
            {
                Console.Clear(); // очистка консоли

                Console.WriteLine("Меню");
                Console.WriteLine("----------------------------");
                Console.WriteLine("1 - Ввести данные");
                Console.WriteLine("2 - Сохранить данные в файл");
                Console.WriteLine("3 - Считать данные из файла");
                Console.WriteLine("4 - Вывести данные");
                Console.WriteLine("0 - Выход");
                Console.WriteLine("----------------------------");
                Console.Write("Введите команду: ");
                sbyte command = sbyte.Parse(Console.ReadLine()); // sbyte = [-128;127], 1 байт

                Console.Clear();
                //Console.WriteLine("\n************************************\n");

                switch (command)
                {
                    case 0:
                        Console.WriteLine("Закрытие программы...");
                        flag = false;
                        break;
                    case 1:
                        Console.Write("Введите количество товаров: ");
                        int size = int.Parse(Console.ReadLine());
                        Data = InputAllData(size);
                        Console.WriteLine("\nВы завершили ввод данных.\nДля возврата в меню нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case 2:
                        if (Data == null) 
                            Console.WriteLine("Данные отсутствуют");
                        else
                        {
                            SaveToFile(Data, path);
                            Console.WriteLine("Данные успешно сохранены в файл");
                        }

                        Console.WriteLine("\nДля возврата в меню нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case 3:
                        Data = LoadFromFile(path);
                        Console.WriteLine((Data == null) ? "Файл пустой" : "Данные успешно загружены из файла");

                        Console.WriteLine("\nДля возврата в меню нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case 4:
                        if (Data == null)
                            Console.WriteLine("Данные отсутствуют");
                        else
                            PrintData(Data);

                        Console.WriteLine("\nДля возврата в меню нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    default:
                        Console.WriteLine("Ошибочная команда. Повторите ввод");
                        Console.WriteLine("\nДля возврата в меню нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                }
            }
        }

        // Пункт 1: Ввод набора данных с клавиатуры
        static Stationery[] InputAllData(int size)
        {
            Stationery[] stationeries = new Stationery[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Товар {i + 1}");
                stationeries[i] = ReadDataFromConsole();
            }
            return stationeries;
        }

        // Пункт 2: Сохранение данных из массива в файл
        static void SaveToFile(Stationery[] stationeries, string path)
        {
            StreamWriter writer = new StreamWriter(path, true);
            foreach (Stationery el in stationeries)
            {
                el.WriteToFile(writer);
            }
            writer.Close();
        }

        // Пункт 3: Загрузка данных из файла в массив
        static Stationery[] LoadFromFile(string path)
        {
            if (IsFileEmpty(path))
                return null;

            List<Stationery> list = new List<Stationery>();
            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                Stationery temp = new Stationery();
                if (temp.ReadFromFile(reader))
                    list.Add(temp);
            }
            reader.Close();
            return list.ToArray();
        }

        // Пункт 4: Вывод данных из массива в виде таблицы
        static void PrintData(Stationery[] stationeries)
        {
            // Формат строки таблицы
            string format = $"| {{0,-5}} | {{1,-15}} | {{2,-20}} | {{3,-10}} |";

            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine(format, "", "Тип", "Фирма-производитель", "Цена");
            Console.WriteLine("---------------------------------------------------------------");

            for (int i = 0; i < stationeries.Length; i++)
            {
                Console.WriteLine(format, i + 1, stationeries[i].Type, stationeries[i].Company, stationeries[i].Price);
                Console.WriteLine("---------------------------------------------------------------");
            }
        }

        // Считывание информации об одном объекте с консоли
        static Stationery ReadDataFromConsole()
        {
            Stationery temp = new Stationery();

            Console.Write("Тип: ");
            temp.Type = Console.ReadLine();

            Console.Write("Фирма-производитель: ");
            temp.Company = Console.ReadLine();

            bool success = false; // флаг успешности ввода
            // Запрос ввода цены повторяется, пока пользователь не введет число
            while (!success)
            {
                Console.Write("Цена: ");
                success = float.TryParse(Console.ReadLine(), out float price);
                if (success)
                {
                    temp.Price = price;
                    break;
                }
                Console.WriteLine("Неверный формат. Введите число");
            }
            return temp;
        }

        // Проверка файла на пустоту (проверяется длина содержимого файла)
        static bool IsFileEmpty(string path)
        {
            var fileInfo = new FileInfo(path);
            return fileInfo.Length == 0;
        }
    }
}

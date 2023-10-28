using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Входной и выходной файлы
            string inputFile, outputFile;
            // Получение пути к файлам через аргументы командной строки
            if (args.Length > 0)
            {
                inputFile = args[0];
                outputFile = args[1];
            } // При отсутствии аргументов - ввод путей с клавиатуры 
            else
            {
                Console.WriteLine("Отсутствуют идентификаторы входного и выходного файлов.");
                Console.Write("Входной файл: ");
                inputFile = Console.ReadLine();
                Console.Write("Выходной файл: ");
                outputFile = Console.ReadLine();
            }

            Menu(outputFile);
        }

        //  Меню программы
        static void Menu(string filePath)
        {
            Stationery[] data = null; // Массив данных
            StationeryService service = new StationeryService(); // Класс сервиса для работы с объектами типа Stationery
            bool flag = true; // флаг работы программы
            while (flag)
            {
                PrintMenu(); // Вывод меню
                // Считывание команды с консоли
                Console.Write("Введите команду: ");
                string command = Console.ReadLine();
                Console.Clear(); // Очистка консоли

                switch (command)
                {
                    case "0":
                        Console.WriteLine("Закрытие программы...");
                        flag = false;
                        break;
                    case "1":
                        Console.Write("Введите количество товаров: ");
                        int size = int.Parse(Console.ReadLine());
                        data = service.InputAllData(size);
                        Console.WriteLine("\nВы завершили ввод данных.\nДля возврата в меню нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case "2":
                        if (data == null)
                            Console.WriteLine("Данные отсутствуют");
                        else
                        {
                            service.SaveToFile(data, filePath);
                            Console.WriteLine("Данные успешно сохранены в файл");
                        }
                        Console.WriteLine("\nДля возврата в меню нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case "3":
                        data = service.LoadFromFile(filePath);

                        if (data == null)
                            Console.WriteLine("Файл пустой");
                        else
                        {
                            Console.WriteLine("Данные успешно загружены из файла");
                            service.PrintData(data);
                        }
                        Console.WriteLine("\nДля возврата в меню нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case "4":
                        if (data == null)
                            Console.WriteLine("Данные отсутствуют");
                        else
                            service.PrintData(data);
                        Console.WriteLine("\nДля возврата в меню нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case "5": service.Search(); Console.ReadKey(true); break;
                    case "6": service.Edit(); Console.ReadKey(true); break;
                    case "7":
                        Sort(service);
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
        // Вывод меню
        static void PrintMenu()
        {
            Console.Clear(); // Очистка консоли

            Console.WriteLine("Меню");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1 - Ввести данные");
            Console.WriteLine("2 - Сохранить данные в файл");
            Console.WriteLine("3 - Считать данные из файла");
            Console.WriteLine("4 - Вывести данные");
            Console.WriteLine("5 - Поиск");
            Console.WriteLine("6 - Редактирование");
            Console.WriteLine("7 - Сортировка");
            Console.WriteLine("0 - Выход");
            Console.WriteLine("----------------------------");
        }

        static void Sort(StationeryService service)
        {
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("Сортировка");
                Console.WriteLine("Выберите поле для сортировки:");
                Console.WriteLine("1 - Тип товара");
                Console.WriteLine("2 - Фирма-производитель");
                Console.WriteLine("3 - Цена");                
                Console.WriteLine("0 - Возврат в главное меню");
                Console.Write("Введите команду: ");
                string command = Console.ReadLine();
                Stationery[] data;
                switch (command)
                {
                    case "1":
                        data = service.Sort("type");
                        Console.WriteLine("Результат сортировки");
                        service.PrintData(data);
                        break;
                    case "2":
                        data = service.Sort("company");
                        Console.WriteLine("Результат сортировки");
                        service.PrintData(data);
                        break;
                    case "3":
                        data = service.Sort("price");
                        Console.WriteLine("Результат сортировки");
                        service.PrintData(data);
                        break;
                    case "0": flag = false; break;
                    default:
                        Console.WriteLine("Ошибочная команда. Повторите ввод");
                        Console.WriteLine("\nДля возврата в меню нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                }

            }



        }
    }
}

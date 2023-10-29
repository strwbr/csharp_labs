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

        //  Главное меню программы
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
                        Console.WriteLine("\nВы завершили ввод данных.\nДля возврата в главное меню нажмите любую клавишу...");
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
                        Console.WriteLine("\nДля возврата в главное меню нажмите любую клавишу...");
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
                        Console.WriteLine("\nДля возврата в главное меню нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case "4":
                        if (data == null)
                            Console.WriteLine("Данные отсутствуют");
                        else
                            service.PrintData(data);
                        Console.WriteLine("\nДля возврата в главное меню нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case "5":
                        if (data == null) 
                            Console.WriteLine("Данные отсутствуют");
                        else 
                            Search(service, data);
                        Console.WriteLine("\nДля возврата в главное меню нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case "6":
                        if (data == null)
                            Console.WriteLine("Данные отсутствуют");
                        else
                            Edit(service, data);
                        Console.WriteLine("\nДля возврата в главное меню нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case "7":
                        if (data == null)
                            Console.WriteLine("Данные отсутствуют");
                        else
                            Sort(service, data);
                        Console.WriteLine("\nДля возврата в главное меню нажмите любую клавишу...");
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

        static void PrintSortMenu()
        {
            Console.Clear(); // Очистка консоли
            Console.WriteLine("-----Сортировка-----");
            Console.WriteLine("Выберите поле для сортировки:");
            Console.WriteLine("1 - Тип товара");
            Console.WriteLine("2 - Фирма-производитель");
            Console.WriteLine("3 - Цена");
            Console.WriteLine("0 - Возврат в главное меню");
        }

        static void Sort(StationeryService service, Stationery[] data)
        {
            bool flag = true;

            while (flag)
            {
                PrintSortMenu();
                Console.Write("\nВведите команду: ");
                string command = Console.ReadLine();
                Console.Clear(); // Очистка консоли
                switch (command)
                {
                    case "1":
                        data = service.SortByType(data);
                        Console.WriteLine("Результат сортировки по полю 'Тип товара'");
                        service.PrintData(data);
                        Console.WriteLine("\nДля возврата в меню сортировки нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case "2":
                        data = service.SortByCompany(data);
                        Console.WriteLine("Результат сортировки по полю 'Фирма-производитель'");
                        service.PrintData(data);
                        Console.WriteLine("\nДля возврата в меню сортировки нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case "3":
                        data = service.SortByPrice(data);
                        Console.WriteLine("Результат сортировки по полю 'Цена'");
                        service.PrintData(data);
                        Console.WriteLine("\nДля возврата в меню сортировки нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case "0": flag = false; break;
                    default:
                        Console.WriteLine("Ошибочная команда. Повторите ввод");
                        Console.WriteLine("\nДля возврата в меню сортировки нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                }
            }
        }

        // Вспомогательный метод для вывода результата поиска
        static void PrintSearchData(StationeryService service, Stationery[] data)
        {
            Console.WriteLine("Результат поиска");
            if (data.Length == 0)
            {
                Console.WriteLine("Ничего не найдено");
                return;
            }
            service.PrintData(data);
        }

        static void PrintSearchMenu()
        {
            Console.Clear(); // Очистка консоли
            Console.WriteLine("-----Поиск-----");
            Console.WriteLine("Выберите поле для поиска:");
            Console.WriteLine("1 - Тип товара");
            Console.WriteLine("2 - Фирма-производитель");
            Console.WriteLine("3 - Цена");
            Console.WriteLine("0 - Возврат в главное меню");
        }

        // Поиск записей в массиве (в файл изменения не попадают)
        static void Search(StationeryService service, Stationery[] data)
        {
            bool flag = true;

            while (flag)
            {
                PrintSearchMenu();
                Console.Write("\nВведите команду: ");
                string command = Console.ReadLine();
                Console.Clear();
                switch (command)
                {
                    case "1":
                        Console.Write("Введите тип товара для поиска: ");
                        string type = Console.ReadLine().ToLower();
                        PrintSearchData(service, service.SearchByType(data, type));
                        Console.WriteLine("\nДля возврата в меню поиска нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case "2":
                        Console.Write("Введите фирму-производителя для поиска: ");
                        string company = Console.ReadLine().ToLower();
                        PrintSearchData(service, service.SearchByCompany(data, company));
                        Console.WriteLine("\nДля возврата в меню поиска нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case "3":
                        bool success = false;
                        while (!success)
                        {
                            Console.Write("Введите цену товара для поиска: ");
                            success = float.TryParse(Console.ReadLine(), out float price);
                            if (success)
                            {
                                PrintSearchData(service, service.SearchByPrice(data, price));
                                break;
                            }
                            Console.WriteLine("Неверный формат. Введите число");
                        }
                        Console.WriteLine("\nДля возврата в меню поиска нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case "0": flag = false; break;
                    default:
                        Console.WriteLine("Ошибочная команда. Повторите ввод");
                        Console.WriteLine("\nДля возврата в меню поиска нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                }
            }
        }

        // Редактирование записей в массиве (в файл изменения не попадают)
        static void Edit(StationeryService service, Stationery[] data)
        {
            Console.WriteLine("-----Редактирование-----");
            Console.WriteLine("\nВведите номер товара, который хотите отредактировать.\nВведите 0 для возврата в главное меню");
            Console.Write("\nНомер товара: ");
            bool success = false;
            while (!success)
            {
                if (int.TryParse(Console.ReadLine(), out int listNumber) && (listNumber >= 0 && listNumber <= data.Length))
                {
                    if (listNumber == 0) return;

                    success = true;
                    Console.WriteLine("Товар №" + listNumber);
                    service.PrintOneStationery(data[listNumber - 1], listNumber);

                    Console.WriteLine("\nВведите новое значение поля, если хотите его отредактировать\nИначе введите '-'");
                    data[listNumber - 1] = service.EditStationery(data[listNumber - 1]);
                    Console.WriteLine("\nОтредактированная запись");
                    service.PrintOneStationery(data[listNumber - 1], listNumber);
                }
                else Console.WriteLine("Неверный номер. Повторите ввод");
            }
        }
    }
}

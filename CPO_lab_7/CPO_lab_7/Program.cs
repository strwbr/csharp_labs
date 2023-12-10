using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string PATH = "data.dat";
            List list = new List();
            Menu(PATH, list);
            
            Console.ReadKey(true);
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

        // Меню выбора вида канцелярии - Тетрадь/Скоросшиватель/Органайзер/Карандаш
        static void PrintStationeryMenu()
        {
            Console.Clear(); // Очистка консоли

            Console.WriteLine("Меню");
            Console.WriteLine("Выберите вид канцелярии, которую хотите ввести:");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1 - Скоросшиватели");
            Console.WriteLine("2 - Тетради");
            Console.WriteLine("3 - Органайзеры");
            Console.WriteLine("4 - Карандаши");
            Console.WriteLine("0 - Выход");
            Console.WriteLine("----------------------------");
        }

        // Ввод конкретного вида канцелярии
        static void InputStationeryKindFromConsole<T>(List list) where T : Stationery, new()
        {
            Console.Write("Введите количество товаров: ");
            int size = int.Parse(Console.ReadLine());
            list.InputAllData<T>(size);
        }

        // Ввод данных с консоли
        static void InputDataFromConsole(List list)
        {
            PrintStationeryMenu();
            Console.Write("Введите команду: ");
            string command = Console.ReadLine();
            Console.Clear(); // Очистка консоли

            switch (command)
            {
                case "0":
                    Console.WriteLine("Вы остановили ввод данных.\nДля возврата в главное меню нажмите любую клавишу...");
                    Console.ReadKey(true);
                    break;
                case "1":
                    InputStationeryKindFromConsole<Folder>(list);
                    Console.WriteLine("\nВы завершили ввод данных.\nДля возврата в главное меню нажмите любую клавишу...");
                    Console.ReadKey(true);
                    break;
                case "2":
                    InputStationeryKindFromConsole<Notebook>(list);
                    Console.WriteLine("\nВы завершили ввод данных.\nДля возврата в главное меню нажмите любую клавишу...");
                    Console.ReadKey(true);
                    break;
                case "3":
                    InputStationeryKindFromConsole<Organizer>(list);
                    Console.WriteLine("\nВы завершили ввод данных.\nДля возврата в главное меню нажмите любую клавишу...");
                    Console.ReadKey(true);
                    break;
                case "4":
                    InputStationeryKindFromConsole<Pencil>(list);
                    Console.WriteLine("\nВы завершили ввод данных.\nДля возврата в главное меню нажмите любую клавишу...");
                    Console.ReadKey(true);
                    break;
                default:
                    Console.WriteLine("Ошибочная команда.");
                    Console.WriteLine("\nДля возврата в меню нажмите любую клавишу...");
                    Console.ReadKey(true);
                    break;
            }
        }

        // Вывод меню выбора поля
        static void PrintFieldChooseMenu(string action)
        {
            Console.Clear(); // Очистка консоли
            Console.WriteLine($"-----{action}-----");
            Console.WriteLine("Выберите поле:");
            Console.WriteLine("1 - Фирма-производитель");
            Console.WriteLine("2 - Цена");
            Console.WriteLine("0 - Возврат в главное меню");
        }

        // Поиск записей в массиве (в файл изменения не попадают)
        static void Search(List list)
        {
            bool flag = true;

            while (flag)
            {
                PrintFieldChooseMenu("Поиск");
                Console.Write("\nВведите команду: ");
                string command = Console.ReadLine();
                Console.Clear();
                switch (command)
                {
                    case "1":
                        Console.Write("Введите фирму-производителя для поиска: ");
                        string company = Console.ReadLine().ToLower();
                        Console.WriteLine("Результат поиска");
                        bool successSearch = list.SearchByCompany(company);
                        if (!successSearch)
                        {
                            Console.WriteLine("Ничего не найдено");
                        }
                        Console.WriteLine("\nДля возврата в меню поиска нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case "2":
                        bool success = false;
                        while (!success)
                        {
                            Console.Write("Введите цену товара для поиска: ");
                            success = float.TryParse(Console.ReadLine(), out float price);
                            if (success)
                            {
                                Console.WriteLine("Результат поиска");
                                successSearch = list.SearchByPrice(price);
                                if (!successSearch)
                                {
                                    Console.WriteLine("Ничего не найдено");
                                }
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
        static void Edit(List list)
        {
            Console.WriteLine("-----Редактирование-----");
            Console.WriteLine("\nВведите номер товара, который хотите отредактировать.\nВведите 0 для возврата в главное меню");
            Console.Write("\nНомер товара: ");
            bool success = false;
            while (!success)
            {
                if (int.TryParse(Console.ReadLine(), out int listNumber) && (listNumber > 0))
                {
                    success = list.Edit(listNumber - 1);
                }
                else Console.WriteLine("Неверный номер. Повторите ввод");
            }
        }

        static void Sort(List list)
        {
            bool flag = true;

            while (flag)
            {
                PrintFieldChooseMenu("Сортировка");
                Console.Write("\nВведите команду: ");
                string command = Console.ReadLine();
                Console.Clear(); // Очистка консоли
                switch (command)
                {
                    case "1":
                        list.SortByCompany();
                        Console.WriteLine("Результат сортировки по полю 'Фирма-производитель'");
                        list.Print();
                        Console.WriteLine("\nДля возврата в меню сортировки нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case "2":
                        list.SortByPrice();
                        Console.WriteLine("Результат сортировки по полю 'Цена'");
                        list.Print();
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

        static void Menu(string filePath, List list)
        {
            bool flag = true;

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
                        InputDataFromConsole(list);
                        break;
                    case "2":
                        if (list.SaveToFile(filePath))
                        {
                            Console.WriteLine("Данные успешно сохранены в файл");
                        }
                        else
                        {
                            Console.WriteLine("Данные отсутствуют");
                        }
                        Console.WriteLine("\nДля возврата в главное меню нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case "3":
                        if (list.LoadFromFile(filePath))
                        {
                            Console.WriteLine("Данные успешно загружены из файла");
                            list.Print();
                        }
                        else
                        {
                            Console.WriteLine("Файл пустой");
                        }
                        Console.WriteLine("\nДля возврата в главное меню нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case "4":
                        if (!list.Print())
                        {
                            Console.WriteLine("Данные отсутствуют");
                        }
                        Console.WriteLine("\nДля возврата в главное меню нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case "5":
                        Search(list);
                        Console.WriteLine("\nДля возврата в главное меню нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case "6":
                        Edit(list);
                        Console.WriteLine("\nДля возврата в главное меню нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case "7":
                        Sort(list);
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
    }
}

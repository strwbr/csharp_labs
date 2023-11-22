using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string PATH = "data.dat";
            //const int SIZE = 1;
            Menu(PATH);



            //Console.WriteLine("--> Скоросшиватели:");
            //Stationery[] folders = service.InputAllData<Folder>(SIZE);
            //service.SaveToFile(folders, PATH);

            //Console.WriteLine("\n--> Органайзеры:");
            //Stationery[] organizers = service.InputAllData<Organizer>(SIZE);
            //service.SaveToFile(organizers, PATH);

            //Console.WriteLine("\n--> Карандаши:");
            //Stationery[] pencils = service.InputAllData<Pencil>(SIZE);
            //service.SaveToFile(pencils, PATH);

            //Console.WriteLine("\n--> Тетради:");
            //Stationery[] noteboks = service.InputAllData<Notebook>(SIZE);
            //service.SaveToFile(noteboks, PATH);

            //Stationery[] readData = service.LoadFromFile(PATH);
            //service.PrintData(readData);

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
        static Stationery[] InputStationeryKindFromConsole<T>(StationeryService service) where T : Stationery, new()
        {
            Console.Write("Введите количество товаров: ");
            int size = int.Parse(Console.ReadLine());
            Stationery[] temp = service.InputAllData<T>(size);
            return temp;
        }

        // Ввод данных с консоли
        static Stationery[] InputDataFromConsole(StationeryService service)
        {
            PrintStationeryMenu();
            Console.Write("Введите команду: ");
            string command = Console.ReadLine();
            Console.Clear(); // Очистка консоли
            Stationery[] temp = null;

            switch (command)
            {
                case "0":
                    Console.WriteLine("Вы остановили ввод данных.\nДля возврата в главное меню нажмите любую клавишу...");
                    Console.ReadKey(true);
                    break;
                case "1":
                    temp = InputStationeryKindFromConsole<Folder>(service);
                    Console.WriteLine("\nВы завершили ввод данных.\nДля возврата в главное меню нажмите любую клавишу...");
                    Console.ReadKey(true);
                    break;
                case "2":
                    temp = InputStationeryKindFromConsole<Notebook>(service);
                    Console.WriteLine("\nВы завершили ввод данных.\nДля возврата в главное меню нажмите любую клавишу...");
                    Console.ReadKey(true);
                    break;
                case "3":
                    temp = InputStationeryKindFromConsole<Organizer>(service);
                    Console.WriteLine("\nВы завершили ввод данных.\nДля возврата в главное меню нажмите любую клавишу...");
                    Console.ReadKey(true);
                    break;
                case "4":
                    temp = InputStationeryKindFromConsole<Pencil>(service);
                    Console.WriteLine("\nВы завершили ввод данных.\nДля возврата в главное меню нажмите любую клавишу...");
                    Console.ReadKey(true);
                    break;
                default:
                    Console.WriteLine("Ошибочная команда.");
                    Console.WriteLine("\nДля возврата в меню нажмите любую клавишу...");
                    Console.ReadKey(true);
                    break;
            }
            return temp;
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

        // если кринге уберем тогда
        static void PrintFieldChooseMenu(string action)
        {
            Console.Clear(); // Очистка консоли
            Console.WriteLine($"-----{action}-----");
            Console.WriteLine("Выберите поле:");
            Console.WriteLine("1 - Фирма-производитель");
            Console.WriteLine("2 - Цена");
            Console.WriteLine("0 - Возврат в главное меню");
        }

        //static void PrintSearchMenu()
        //{
        //    Console.Clear(); // Очистка консоли
        //    Console.WriteLine("-----Поиск-----");
        //    Console.WriteLine("Выберите поле для поиска:");
        //    Console.WriteLine("1 - Фирма-производитель");
        //    Console.WriteLine("2 - Цена");
        //    Console.WriteLine("0 - Возврат в главное меню");
        //}

        // Поиск записей в массиве (в файл изменения не попадают)
        static void Search(StationeryService service, Stationery[] data)
        {
            bool flag = true;

            while (flag)
            {
                //PrintSearchMenu();
                PrintFieldChooseMenu("Поиск");
                Console.Write("\nВведите команду: ");
                string command = Console.ReadLine();
                Console.Clear();
                switch (command)
                {
                    case "1":
                        Console.Write("Введите фирму-производителя для поиска: ");
                        string company = Console.ReadLine().ToLower();
                        PrintSearchData(service, service.SearchByCompany(data, company));
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
        static void Edit(Stationery[] data)
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
                    data[listNumber - 1].Print();

                    Console.WriteLine("\nВведите новое значение поля, если хотите его отредактировать\nИначе введите '-'");
                    data[listNumber - 1].Edit();
                    Console.WriteLine("\nОтредактированная запись");
                    data[listNumber - 1].Print();

                }
                else Console.WriteLine("Неверный номер. Повторите ввод");
            }
        }

        //static void PrintSortMenu()
        //{
        //    Console.Clear(); // Очистка консоли
        //    Console.WriteLine("-----Сортировка-----");
        //    Console.WriteLine("Выберите поле для сортировки:");
        //    Console.WriteLine("1 - Фирма-производитель");
        //    Console.WriteLine("2 - Цена");
        //    Console.WriteLine("0 - Возврат в главное меню");
        //}

        static void Sort(StationeryService service, Stationery[] data)
        {
            bool flag = true;

            while (flag)
            {
                //PrintSortMenu();
                PrintFieldChooseMenu("Сортировка");
                Console.Write("\nВведите команду: ");
                string command = Console.ReadLine();
                Console.Clear(); // Очистка консоли
                switch (command)
                {
                    case "1":
                        data = service.SortByCompany(data);
                        Console.WriteLine("Результат сортировки по полю 'Фирма-производитель'");
                        service.PrintData(data);
                        Console.WriteLine("\nДля возврата в меню сортировки нажмите любую клавишу...");
                        Console.ReadKey(true);
                        break;
                    case "2":
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

        //  Главное меню программы
        static void Menu(string filePath)
        {
            StationeryService service = new StationeryService();
            //тут число мб проблемы
            Stationery[] data = null;
            bool flag = true;

            while (flag)
            {
                PrintMenu(); // Вывод меню
                // Считывание команды с консоли
                Console.Write("Введите команду: ");
                string command = Console.ReadLine();
                Console.Clear(); // Очистка консоли

                switch(command)
                {
                    case "0":
                        Console.WriteLine("Закрытие программы...");
                        flag = false;
                        break;
                    case "1":
                        data = InputDataFromConsole(service);
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
                            Edit(data);
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
    }
}

using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_7
{
    internal class List
    {
        private Node Head { get; set; }
        
        public List()
        {
            Head = null;
        }

        public void Add(Stationery stationery)
        {
            Node newNode = new Node(stationery);
            if (Head == null)
            {
                Head = newNode;
                Head.Next = newNode;
                Head.Previous = newNode;
            }
            else
            {
                Node tailNode = Head.Previous;
                newNode.Next = Head;
                newNode.Previous = tailNode;
                tailNode.Next = newNode;
                Head.Previous = newNode;
            }
        }

        public bool Delete(int index)
        {
            if (Head == null)
            {
                return false;
            }

            Node current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
                if (current == Head)
                {
                    return false;
                }
            }

            current.Previous.Next = current.Next;
            current.Next.Previous = current.Previous;

            // Если удаляллся головной узел
            if (current == Head)
            {
                Head = current.Next;
            }
            return true;
        }

        public bool Edit(int index)
        {
            if (Head == null)
            {
                return false;
            }

            Node current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
                if (current == Head)
                {
                    return false;
                }
            }
            Console.WriteLine("Товар №" + (index + 1));
            current.Data.Print();
            Console.WriteLine("\nВведите новое значение поля, если хотите его отредактировать\nИначе введите '-'");
            current.Data.Edit();
            Console.WriteLine("\nОтредактированная запись");
            current.Data.Print();
            return true;
        }

        public bool Print()
        {
            if (Head == null)
            {
                return false;
            }

            Node current = Head;
            string format = $"| {{0,-5}} ";
            int number = 1;
            do
            {
                Console.WriteLine();

                Console.WriteLine(string.Format(format, "№") + current.Data.TableHeader());
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                Console.Write(format, number);
                Console.WriteLine(current.Data.ToString());
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");

                current = current.Next;
                number++;
            } while (current != Head);

            return true;
        }

        public bool SearchByCompany(string query)
        {
            if (Head == null)
            {
                return false;
            }

            Node current = Head;
            string format = $"| {{0,-5}} ";
            int number = 1;
            do
            {
                if (current.Data.Company.ToLower() == query.ToLower())
                {
                    Console.WriteLine();

                    Console.WriteLine(string.Format(format, "№") + current.Data.TableHeader());
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                    Console.Write(format, number);
                    Console.WriteLine(current.Data.ToString());
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                }

                current = current.Next;
                number++;
            } while (current != Head);
            return true;
        }

        public bool SearchByPrice(float query)
        {
            if (Head == null)
            {
                return false;
            }

            Node current = Head;
            string format = $"| {{0,-5}} ";
            int number = 1;
            do
            {
                if (current.Data.Price == query)
                {
                    Console.WriteLine();

                    Console.WriteLine(string.Format(format, "№") + current.Data.TableHeader());
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                    Console.Write(format, number);
                    Console.WriteLine(current.Data.ToString());
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                }

                current = current.Next;
                number++;
            } while (current != Head);
            return true;
        }

        public void SortByCompany()
        {
            // Список пуст или содержит только один элемент
            if (Head == null || Head.Next == null)
            {
                return;
            }

            Node current = Head;
            do
            {
                Node next = current.Next;
                do
                {
                    if (string.Compare(current.Data.Company, next.Data.Company) > 0)
                    {
                        (next.Data, current.Data) = (current.Data, next.Data);
                    }
                    next = next.Next;
                } while (next != Head);
                current = current.Next;
            } while (current != Head && current.Next != Head);
        }

        public void SortByPrice()
        {
            // Список пуст или содержит только один элемент
            if (Head == null || Head.Next == null)
            {
                return;
            }

            Node current = Head;
            do
            {
                Node next = current.Next;
                do
                {
                    if (current.Data.Price > next.Data.Price)
                    {
                        (next.Data, current.Data) = (current.Data, next.Data);
                    }
                    next = next.Next;
                } while (next != Head);
                current = current.Next;
            } while (current != Head && current.Next != Head);
        }

        // Чтение данных из файла
        private bool IsFileEmpty(string path)
        {
            var fileInfo = new FileInfo(path);
            return fileInfo.Length == 0;
        }

        public Stationery GetStationeryInstance(char label)
        {
            switch (label)
            {
                case 'F': return new Folder();
                case 'O': return new Organizer();
                case 'P': return new Pencil();
                case 'N': return new Notebook();
            }
            return null;
        }

        public bool LoadFromFile(string path)
        {
            // Очистка списка
            Head = null;
            if (IsFileEmpty(path))
                return false;
            BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate));
            while (reader.PeekChar() > -1)
            {
                char label = reader.ReadChar();
                Stationery temp = GetStationeryInstance(label);
                if (temp.ReadFromFile(reader))
                    Add(temp);
            }
            reader.Close();
            return true;
        }

        public bool SaveToFile(string path)
        {
            if (Head == null)
            {
                return false;
            }
            BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Append));
            Node current = Head;
            do
            {
                current.Data.WriteToFile(writer);
                current = current.Next;
            } while (current != Head);
            writer.Close();

            return true;
        }

        // Ввод с консоли
        public void InputAllData<T>(int size) where T : Stationery, new()
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"\nТовар {i + 1}");
                T temp = new T();
                temp.ReadFromConsole();
                Add(temp);
            }
        }
    }
}

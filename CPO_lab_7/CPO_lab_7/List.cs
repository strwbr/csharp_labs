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
        private StationeryNode Head { get; set; }
        
        public List()
        {
            Head = null;
        }

        public void Add(Stationery stationery)
        {
            StationeryNode newNode = new StationeryNode(stationery);
            if (Head == null)
            {
                Head = newNode;
                Head.Next = newNode;
                Head.Previous = newNode;
            }
            else
            {
                StationeryNode tailNode = Head.Previous;
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

            StationeryNode current = Head;
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

            // Если удалялась голова
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

            StationeryNode current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
                if (current == Head)
                {
                    return false;
                }
            }

            current.Data.Edit();
            return true;
        }

        public bool Print()
        {
            if (Head == null)
            {
                return false;
            }

            StationeryNode current = Head;
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
            // раньше просто чепятал список, не сохранял нигде
            if (Head == null)
            {
                return false;
            }

            StationeryNode current = Head;
            string format = $"| {{0,-5}} ";
            int number = 1;
            do
            {
                //я не понимаю какого хрена творится
                //current.Data.Company это ошибка, нет поля

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
            // раньше просто чепятал список, не сохранял нигде
            if (Head == null)
            {
                return false;
            }

            StationeryNode current = Head;
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

            StationeryNode current = Head;
            do
            {
                StationeryNode next = current.Next;
                do
                {
                    if (string.Compare(current.Data.Company, next.Data.Company) < 0)
                    {
                        (next.Data, current.Data) = (current.Data, next.Data);
                    }
                    next = next.Next;
                } while (next != Head);
                current = current.Next;
            } while (current != Head);
        }

        public void SortByPrice()
        {
            // Список пуст или содержит только один элемент
            if (Head == null || Head.Next == null)
            {
                return;
            }

            StationeryNode current = Head;
            do
            {
                StationeryNode next = current.Next;
                do
                {
                    if (current.Data.Price < next.Data.Price)
                    {
                        (next.Data, current.Data) = (current.Data, next.Data);
                    }
                    next = next.Next;
                } while (next != Head);
                current = current.Next;
            } while (current != Head);
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
            StationeryNode current = Head;
            do
            {
                current.Data.WriteToFile(writer);
                current = current.Next;
            } while (current != Head);
            writer.Close();

            return true;
        }
    }
}

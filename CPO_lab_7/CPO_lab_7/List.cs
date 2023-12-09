using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    }
}

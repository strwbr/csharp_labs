using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CPO_lab_7
{
    internal class CircularDoublyLinkedList<Stationery>
    {
        private Node<Stationery> head;

        public CircularDoublyLinkedList()
        {
            head = null;
        }

        public void Add(Stationery stationery)
        {
            Node<Stationery> newNode = new Node<Stationery>(stationery);
            if (head == null)
            {
                head = newNode;
                head.Next = newNode;
                head.Previous = newNode;
            }
            else
            {
                Node<Stationery> tailNode = head.Previous;
                newNode.Next = head;
                newNode.Previous = tailNode;
                tailNode.Next = newNode;
                head.Previous = newNode;
            }
        }

        // На фолс в Программе будем выводить штуки в духе "Пусто" "Не найдено" и тп

        // По индексу проще удалять. Если по объекту придется иквалс писать
        public bool Delete(int index)
        {
            if (head == null)
            {
                return false;
            }
            
            Node<Stationery> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
                if (current == head)
                {
                    return false;
                }
            }

            current.Previous.Next = current.Next;
            current.Next.Previous = current.Previous;

            // Если удалялась голова
            if (current == head)
            {
                head = current.Next;
            }
            return true;
        }

        public bool Edit(int index)
        {
            if (head == null)
            {
                return false;
            }

            Node<Stationery> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
                if (current == head)
                {
                    return false;
                }
            }

            // Главная страшилка местного кода
            Type type = current.Data.GetType();
            var edit = type.GetMethod("Edit");
            if (edit != null)
            {
                edit.Invoke(current.Data, null);
                return true;
            }
            else return false;
        }

        public bool Print()
        {
            if (head == null)
            {
                return false;
            }

            Node<Stationery> current = head;
            Type type = current.Data.GetType();
            var toString = type.GetMethod("ToString");
            var tableHeader = type.GetMethod("TableHeader");
            if (toString != null)
            {
                string format = $"| {{0,-5}} ";
                int number = 1;
                do
                {
                    Console.WriteLine();

                    Console.WriteLine(string.Format(format, "№") + tableHeader.Invoke(current.Data, null));
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                    Console.Write(format, number);
                    Console.WriteLine(toString.Invoke(current.Data, null));
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");

                    current = current.Next;
                    number++;
                } while (current != head);
            }
            else return false;

            return true;
        }

        public bool SearchByCompany(string query)
        {
            // раньше просто чепятал список, не сохранял нигде
            if (head == null)
            {
                return false;
            }

            Node<Stationery> current = head;
            Type type = current.Data.GetType();
            var toString = type.GetMethod("ToString");
            var tableHeader = type.GetMethod("TableHeader");
            var company = type.GetMethod("GetCompany");
            if (toString != null)
            {
                string format = $"| {{0,-5}} ";
                int number = 1;
                do
                {
                    //я не понимаю какого хрена творится
                    //current.Data.Company это ошибка, нет поля
                    
                    if (company.Invoke(current.Data, null).ToString().ToLower() == query.ToLower())
                    {
                        Console.WriteLine();

                        Console.WriteLine(string.Format(format, "№") + tableHeader.Invoke(current.Data, null));
                        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                        Console.Write(format, number);
                        Console.WriteLine(toString.Invoke(current.Data, null));
                        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                    }
                    
                    current = current.Next;
                    number++;
                } while (current != head);
            }
            else return false;
            return true;
        }

        public bool SearchByPrice(float query)
        {
            // раньше просто чепятал список, не сохранял нигде
            if (head == null)
            {
                return false;
            }

            Node<Stationery> current = head;
            Type type = current.Data.GetType();
            var toString = type.GetMethod("ToString");
            var tableHeader = type.GetMethod("TableHeader");
            var price = type.GetMethod("GetPrice");
            if (toString != null)
            {
                string format = $"| {{0,-5}} ";
                int number = 1;
                do
                {
                    if ((float)price.Invoke(current.Data, null) == query)
                    {
                        Console.WriteLine();

                        Console.WriteLine(string.Format(format, "№") + tableHeader.Invoke(current.Data, null));
                        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                        Console.Write(format, number);
                        Console.WriteLine(toString.Invoke(current.Data, null));
                        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                    }

                    current = current.Next;
                    number++;
                } while (current != head);
            }
            else return false;
            return true;
        }
    }
}

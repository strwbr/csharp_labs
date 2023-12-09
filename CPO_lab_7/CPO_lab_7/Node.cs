using System;

namespace CPO_lab_7
{
    internal class Node<Stationery>
    {
        public Stationery Data { get; set; }
        public Node<Stationery> Next { get; set; }
        public Node<Stationery> Previous { get; set;  }

        public Node(Stationery stationery)
        {
            this.Data = stationery;
            this.Next = null;
            this.Previous = null;
        }

        // Возможно не понадобится, но студия его сама сгенерила)))
        public Node(Stationery stationery, Node<Stationery> next, Node<Stationery> previous)
        {
            this.Data = stationery;
            this.Next = next;
            this.Previous = previous;
        }
    }
}

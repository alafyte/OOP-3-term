using System;

namespace Lab07
{
    /*2) Возьмите за основу лабораторную № 3 «Перегрузка операций» и 
    с делайте из нее обобщенный тип (класс) CollectionType<T>, в который 
    вложите обобщённую коллекцию. Наследуйте в обобщенном классе интерфейс 
    из п.1. Реализуйте необходимые методы (добавления, удаления, и т.д.).
    Наложите какое-либо ограничение на обобщение*/
    public class List<T> : IGeneric<T> //where T : class
    {
        public class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
        }

        public Node Head { get; set; }
        public Node Tail { get; set; }
        private int _count;

        public List(T data)
        {
            Head = Tail = new Node();
            Head.Data = data;
            Tail.Data = data;
            _count = 1;
        }
        public List()
        {
            Head = Tail = new Node();
            _count = 0;
        }

        public void Add(T data)
        {
            var newNode = new Node
            {
                Data = data
            };

            if (_count == 0)
            {
                Tail = Head = newNode;
            }
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }

            _count++;
        }

        public void Remove(T data)
        {
            if (_count == 0)
                throw new InvalidOperationException();

            Node current = Head;
            Node previous = null;

            while (current != null)
            {
                if (Equals(current.Data, data))
                {
                    _count--;
                    if (previous == null)
                    {
                        Head = Head.Next;
                        if (Head == null)
                        {
                            Tail = null;
                        }
                        return;
                    }

                    previous.Next = current.Next;

                    if (current.Next == null)
                        Tail = previous;

                    return;
                }

                previous = current;
                current = current.Next;
            }
        }

        public void Show()
        {
            if (_count == 0)
            {
                Console.WriteLine("Список пуст");
                return;
            }

            if (_count == 1)
            {
                Console.WriteLine($"*{Head.Data}-->NULL");
                return;
            }

            Node current = Head;

            Console.Write($"*{current.Data}-->");

            current = current.Next;

            while (current.Next != null)
            {
                Console.Write($"{current.Data}-->");
                current = current.Next;
            }
            Console.WriteLine($"{current.Data}-->NULL");


        }

        public void ClearList()
        {
            Head = Tail = new Node();
            _count = 0;
        }

        //////////////////////////////////////////////////////////////////////////
        public static List<T> operator !(List<T> a)
        {
            if (a._count <= 0) 
                return a;

            var newList = new List<T>();
            var temporary = new T[a._count];
            var counter = a._count - 1;
            var current = a.Head;

            while (current != null)
            {
                temporary[counter] = current.Data;
                counter--;
                current = current.Next;
            }

            foreach (T item in temporary)
            {
                newList.Add(item);
            }

            return newList;
        }

        public static List<T> operator +(List<T> a, List<T> b)
        {
            List<T> newList = new List<T>();

            if (a._count > 0)
            {
                var current = a.Head;
                while (current != null)
                {
                    newList.Add(current.Data);
                    current = current.Next;
                }
            }
            if (b._count > 0)
            {
                var current = b.Head;
                while (current != null)
                {
                    newList.Add(current.Data);
                    current = current.Next;
                }
            }

            return newList;
        }

        public static bool operator ==(List<T> a, List<T> b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(List<T> a, List<T> b)
        {
            return !(a.Equals(b));
        }

        public static List<T> operator <(List<T> a, List<T> b)
        {
            return (a + b);
        }
        public static List<T> operator >(List<T> a, List<T> b)
        {
            return (b + a);
        }

        public override bool Equals(object obj)
        {
            List<T> b = obj as List<T>;
            if (this._count != b._count)
                return false;

            var currentFirst = this.Head;
            var currentSecond = b.Head;
            while (currentFirst != null)
            {
                if (!Equals(currentFirst.Data, currentSecond.Data))
                    return false;
                currentFirst = currentFirst.Next;
                currentSecond = currentSecond.Next;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}


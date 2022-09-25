using System;


namespace Lab03
{
    /*1) Создать заданный в варианте класс. Определить в классе необходимые 
        методы, конструкторы и заданные перегруженные 
        операции.*/
    public class List
    {
        public class Node
        {
            public string Data { get; set; }
            public Node Next { get; set; }
        }


        /*Добавьте в свой класс вложенный объект Production, который содержит 
        Id, название организации.*/
        public class Production
        {
            private readonly int _organisationID;
            public string OrganisationName { get; set; }

            public Production()
            {
                _organisationID = GetHashCode();
            }
            public Production(string name)
            {
                _organisationID = GetHashCode();
                this.OrganisationName = name;
            }

        }

        //) Добавьте в свой класс вложенный класс Developer (разработчик – фио, id, отдел).
        public class Developer
        {
            private readonly int _developerID;

            public string Name { get; set; }
            public string Department { get; set; }

            public Developer()
            {
                _developerID = GetHashCode();
            }
            public Developer(string name, string department)
            {
                _developerID = GetHashCode();
                this.Name = name;
                this.Department = department;
            }

        }

        public Node Head { get; set; }
        public Node Tail { get; set; }

        private int _count;

        //Конструкторы
        public List(string data)
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

        //Необходимые методы
        public void AddElem(string data)
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

        public void RemoveElem(string data)
        {
            if (_count == 0)
                throw new InvalidOperationException();

            Node current = Head;
            Node previous = null;

            while (current != null)
            {
                if (current.Data == data)
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

        public void ShowList()
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
        



        /*перегрузить следующие операции: ! – инверсия элементов; 
        + - объединить два списка; = = - проверка на равенство; < -
        добавление одного списка к другому.*/
        public static List operator !(List a)
        {
            if (a._count <= 0) return a;

            var newList = new List();
            var temporary = new string[a._count];
            var counter = a._count - 1;
            var current = a.Head;

            while (current != null)
            {
                temporary[counter] = current.Data;
                counter--;
                current = current.Next;
            }

            foreach (string item in temporary)
            {
                newList.AddElem(item);
            }

            return newList;
        }

        public static List operator +(List a, List b)
        {
            List newList = new List();

            if (a._count > 0)
            {
                var current = a.Head;
                while (current != null)
                {
                    newList.AddElem(current.Data);
                    current = current.Next;
                }
            }
            if (b._count > 0)
            {
                var current = b.Head;
                while (current != null)
                {
                    newList.AddElem(current.Data);
                    current = current.Next;
                }
            }

            return newList;
        }

        public static bool operator ==(List a, List b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(List a, List b)
        {
            return !(a.Equals(b));
        }

        public static List operator <(List a, List b)
        {
            return (a + b);
        }
        public static List operator >(List a, List b)
        {
            return (b + a);
        }

        public override bool Equals(object obj)
        {
            List b = obj as List;
            if (this._count != b._count)
                return false;

            var currentFirst = this.Head;
            var currentSecond = b.Head;
            while (currentFirst != null)
            {
                if (currentFirst.Data != currentSecond.Data)
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

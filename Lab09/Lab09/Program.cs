using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Lab09
{
    class Program
    {
        static void Main(string[] args)
        {
            /*1) Продемонстрируйте работу с коллекцией (добавление/удаление/поиск/вывод):*/
            Console.WriteLine("--------------------------------------------------");
            GeometricFiguresCollection collection = new GeometricFiguresCollection();
            collection.Add(new GeometricFigure("Прямоугольник", 8));
            collection.Add(new GeometricFigure("Тетраэдр", 20));
            collection.Add(new GeometricFigure("Параллелепипед", 10));
            collection.Add(new GeometricFigure("Треугольник", 6));
            collection.Add(new GeometricFigure("Октаэдр", 11));
            collection.Add(new GeometricFigure("Дельтоид", 9));
            collection.Show();
            Console.WriteLine("--------------------------------------------------");
            collection.RemoveAt(3);
            collection.Show();
            Console.WriteLine("--------------------------------------------------");
            collection.Insert(2, new GeometricFigure("Тор", 4));
            collection.Show();
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"{collection[5]}");

            /*2)Создайте универсальную коллекцию в соответствии с вариантом задания и 
            заполнить ее данными встроенного типа.Net(int, char,…).*/
            Console.WriteLine("--------------------------------------------------");
            Stack<int> stack = new Stack<int>();

            for (int i = 1; i < 8; i++)
                stack.Push(i);

            /*a)Выведите коллекцию на консоль*/
            foreach (var i in stack)
                Console.WriteLine(i.ToString());
            Console.WriteLine("--------------------------------------------------");
            //b) Удалите из коллекции n последовательных элементов
            for (int i = 0; i < 4; i++)
                stack.Pop();
            foreach (var i in stack)
                Console.WriteLine(i.ToString());

            /*c) Добавьте другие элементы (используйте все возможные методы 
            добавления для вашего типа коллекции). */
            Console.WriteLine("--------------------------------------------------");
            stack.Push(10);
            stack.Push(11);
            stack.Push(12);
            foreach (var i in stack)
                Console.WriteLine(i.ToString());

            /*d) Создайте вторую коллекцию (из таблицы выберите другой тип 
            коллекции) и заполните ее данными из первой коллекции.*/
            HashSet<int> vs = new HashSet<int>();

            int n;
            while (stack.Count != 0)
            {
                if (stack.TryPeek(out n))
                    vs.Add(n);

                stack.Pop();
            }
            //e) Выведите вторую коллекцию на консоль.
            Console.WriteLine("--------------------------------------------------");
            foreach (var i in vs)
                Console.WriteLine(i.ToString());


            /*3. Создайте объект наблюдаемой коллекции ObservableCollection<T>. Создайте 
            произвольный метод и зарегистрируйте его на событие CollectionChange. 
            Напишите демонстрацию с добавлением и удалением элементов. В качестве 
            типа T используйте свой класс из таблицы.*/
            Console.WriteLine("--------------------------------------------------");
            ObservableCollection<GeometricFigure> geometricFigures = new ObservableCollection<GeometricFigure>()
            {
                new GeometricFigure("Прямоугольник", 7),
                new GeometricFigure("Ромб", 10),
                new GeometricFigure("Квадрат", 6),
                new GeometricFigure("Параллелограмм", 8)
            };

            foreach (var i in geometricFigures)
                Console.WriteLine(i.ToString());
            Console.WriteLine("--------------------------------------------------");
            

            geometricFigures.CollectionChanged += FiguresCollectionChanged;

            geometricFigures.Add(new GeometricFigure("Круг", 9));
            geometricFigures[0] = new GeometricFigure("Треугольник", 11);
            geometricFigures.RemoveAt(3);

            Console.WriteLine("--------------------------------------------------");
            foreach (var i in geometricFigures)
                Console.WriteLine(i.ToString());
        }

        public static void FiguresCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems?[0] is GeometricFigure newFigure)
                        Console.WriteLine($"Добавлен новый объект: {newFigure.Name}, {newFigure.Area}");
                    break;

                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems?[0] is GeometricFigure oldFigure)
                        Console.WriteLine($"Удален объект: {oldFigure.Name}, {oldFigure.Area}");
                    break;

                case NotifyCollectionChangedAction.Replace:
                    if ((e.NewItems?[0] is GeometricFigure replacingFigure) &&
                        (e.OldItems?[0] is GeometricFigure replacedFigure))
                        Console.WriteLine($"Объект {replacedFigure.Name}, {replacedFigure.Area} " +
                            $"заменен объектом {replacingFigure.Name}, {replacingFigure.Area}");
                    break;
            }
        }
    }
}

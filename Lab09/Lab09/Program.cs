using System;

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

        }
    }
}

using System;

namespace Lab03
{
    class Program
    {
        static void Main(string[] args)
        {
            //Написать программу тестирования, в которой проверяется использование перегруженных операций.
            List fruits = new List();

            fruits.ShowList();

            fruits.AddElem("Яблоко");
            fruits.AddElem("Апельсин");
            fruits.AddElem("Банан");
            fruits.ShowList();

            fruits.RemoveElem("Апельсин");
            fruits.ShowList();

            fruits.ClearList();
            fruits.ShowList();


            List vegetables1 = new List();
            vegetables1.AddElem("Морковь");
            vegetables1.AddElem("Огурец");
            vegetables1.AddElem("Помидор");

            List vegetables2 = new List();
            vegetables2.AddElem("Перец");
            vegetables2.AddElem("Кабачок");
            vegetables2.AddElem("Салат");


            Console.WriteLine($"\nfruits равен vegetables1? - {vegetables1 == fruits}");

            Console.Write($"\nvegetables1 + vegetables2: ");

            (vegetables1 + vegetables2).ShowList();

            Console.Write($"\nvegetables1 (инверсия): ");

            (!vegetables1).ShowList();

            Console.Write($"\nДобавление vegetables2 к vegetables1: ");
            (vegetables1 < vegetables2).ShowList();
            Console.Write($"\nДобавление vegetables1 к vegetables2: ");
            (vegetables1 > vegetables2).ShowList();


            //Инициализация Production и Developer

            List.Production prod1 = new List.Production
            {
                OrganisationName = "BSTU"
            };

            List.Production prod2 = new List.Production("EPAM");

            List.Developer dev1 = new List.Developer
            {
                Name = "Ковалева Е.А",
                Department = "IT"
            };
            List.Developer dev2 = new List.Developer("Соколов Ю.М.", "IT");


            //Работа с классом StatisticOperation
            Console.WriteLine($"\nКонкатенация данных списка vegetables1: {StatisticOperation.ConcatStrings(vegetables1)}");
            Console.WriteLine($"Количество элементов списка vegetables1: {StatisticOperation.CountOfElements(vegetables1)}");
            Console.WriteLine($"Самая длинная строка списка vegetables1: {StatisticOperation.LongestString(vegetables1)}");
            Console.WriteLine($"Самая короткая строка списка vegetables1: {StatisticOperation.ShortestString(vegetables1)}");

            /*Усечение строки до заданной длины*/
            Console.Write($"\nУсечение строки 'Морковь' до 3 символов: ");
            vegetables1.TruncString(3, "Морковь");
            vegetables1.ShowList();


        }
    }
}
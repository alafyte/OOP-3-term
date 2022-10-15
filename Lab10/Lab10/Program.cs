using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            /*1) Задайте массив типа string, содержащий 12 месяцев (June, July, May, 
            December, January ….). Используя LINQ to Object напишите запрос выбирающий 
            последовательность месяцев с длиной строки равной n, запрос возвращающий 
            только летние и зимние месяцы, запрос вывода месяцев в алфавитном порядке,
            запрос считающий месяцы содержащие букву «u» и длиной имени не менее 4-х.*/

            string[] months = {"January", "February", "March", "April", "May", "June",
                   "July", "August", "September", "October", "November", "December", };

            int n = 8;
            var selectedMonths = from m in months where m.Length == n select m;
            Console.WriteLine("------------------------------------------------------------------");
            foreach (string i in selectedMonths)
                Console.WriteLine(i);

            selectedMonths = from m in months where Array.IndexOf(months, m) < 2 ||
            Array.IndexOf(months, m) > 4 && Array.IndexOf(months, m) < 8 ||
            Array.IndexOf(months, m) == 11
            select m;
            Console.WriteLine("------------------------------------------------------------------");
            foreach (string i in selectedMonths)
                Console.WriteLine(i);

            selectedMonths = from m in months orderby m select m;
            Console.WriteLine("------------------------------------------------------------------");
            foreach (string i in selectedMonths)
                Console.WriteLine(i);

            selectedMonths = from m in months where m.Contains('u') && m.Length >= 4 select m;
            Console.WriteLine("------------------------------------------------------------------");
            foreach (string i in selectedMonths)
                Console.WriteLine(i);

            /*. Создайте коллекцию List<T> и параметризируйте ее типом (классом) 
                из лабораторной №2 (при необходимости реализуйте нужные интерфейсы). 
                Заполните ее минимум 10 элементами. */
            List<Bus> buses = new List<Bus>();
            buses.Add(new Bus("Иванов И.И.", 1233, 24, 2003, 92443));
            buses.Add(new Bus("Петров Е.Ф.", 2043, 59, 2010, 44321));
            buses.Add(new Bus("Сидоренко А.О.", 3876, 133, 2008, 32122));
            buses.Add(new Bus("Соколова К.Б.", 7665, 91, 2013, 11099));
            buses.Add(new Bus("Зотова К.А", 4543, 105, 2015, 10086));
            buses.Add(new Bus("Сергеев С.М.", 9834, 133, 2010, 20032));
            buses.Add(new Bus("Николаев И.И.", 3345, 100, 2013, 12309));
            buses.Add(new Bus("Софронова А.Е.", 2465, 37, 2007, 32398));
            buses.Add(new Bus("Волкова А.С.", 5623, 29, 2016, 9002));
            buses.Add(new Bus("Родин Д.С", 2377, 44, 2004, 90231));

            //a) список автобусов для заданного номера маршрута
            int number = 133;
            var selectedBuses = from b in buses where b.RouteNum == number select b;
            Console.WriteLine("------------------------------------------------------------------");
            foreach (var bus in selectedBuses)
                Console.WriteLine($"{bus.driverName}, {bus.BusNum}, {bus.RouteNum}");

            //b) список автобусов, которые эксплуатируются больше заданного срока;
            int age = 10;
            selectedBuses = from b in buses where b.BusAge() > age select b;
            Console.WriteLine("------------------------------------------------------------------");
            foreach (var bus in selectedBuses)
                Console.WriteLine($"{bus.driverName}, {bus.BusNum}, {bus.RouteNum}, срок эксплуатации: {bus.BusAge()}");

            //c) минимальный по пробегу автобус
            selectedBuses = from b in buses where b.Mileage == buses.Min(b => b.Mileage) select b;
            Console.WriteLine("------------------------------------------------------------------");
            foreach (var bus in selectedBuses)
                Console.WriteLine($"{bus.driverName}, {bus.BusNum}, пробег: {bus.Mileage}");

            //d) последние два автобуса максимальные по пробегу
            Console.WriteLine("------------------------------------------------------------------");
            selectedBuses = from b in buses orderby b.Mileage descending select b;
            Console.WriteLine($"{selectedBuses.ToList()[0].Mileage}, {selectedBuses.ToList()[0].BusNum}");
            Console.WriteLine($"{selectedBuses.ToList()[1].Mileage}, {selectedBuses.ToList()[1].BusNum}");

            //e)упорядоченный список автобусов по номеру
            selectedBuses = from b in buses orderby b.BusNum select b;
            Console.WriteLine("------------------------------------------------------------------");
            foreach (var bus in selectedBuses)
                Console.WriteLine($"{bus.driverName}, {bus.BusNum}, {bus.RouteNum}");

            /*4) Придумайте и напишите свой собственный запрос, в котором было 
            бы не менее 5 операторов из разных категорий: условия, проекций, 
            упорядочивания, группировки, агрегирования, кванторов и разбиения.*/
            Console.WriteLine("------------------------------------------------------------------");
            int sum = buses.OrderBy(b => b.RouteNum).Where(b => b.Mileage < 12000).Take(5).SkipLast(1).Sum(b => b.RouteNum);
            Console.WriteLine(sum);

            //5) Придумайте запрос с оператором Join
            var busList = new List<Bus>()
            {
                new Bus("Иванов И.И.", 1233, 24, 2003, 92443),
                new Bus("Софронова А.Е.", 2465, 37, 2007, 32398)
            };

            var driversList = new List<Driver>()
            {
                new Driver("Иванов И.И.", new DateTime(1988, 9, 16)),
                new Driver("Софронова А.Е.", new DateTime(1992, 3, 9))
            };

            var result = from b in busList
                         join d in driversList on b.driverName equals d.Name
                         select new { Name = d.Name, BusNum = b.BusNum, RouteNumber = b.RouteNum };

            Console.WriteLine("------------------------------------------------------------------");
            foreach (var item in result)
            {
                Console.WriteLine(item.ToString());
            }

        }
    }
}

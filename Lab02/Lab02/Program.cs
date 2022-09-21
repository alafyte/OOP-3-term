using System;

namespace Lab02
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Создайте несколько объектов вашего типа. Выполните вызов 
            конструкторов, свойств, методов, сравнение объекты, проверьте тип 
            созданного объекта и т.п. */
            Bus bus1 = new("Ковалёв А.Ю.", 1123, 1, 1990, 12345);
            Bus bus2 = new();
            Bus bus3 = new(22);
            
            Console.WriteLine(bus1.ToString());
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(bus2.ToString());
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(bus3.ToString());
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"bus1 равен bus2? - {bus1.Equals(bus2)}");
            Console.WriteLine($"Тип bus1 - {bus1.GetType()}");
            Console.Write($"Возраст автобуса bus1: {bus1.BusAge()}");

            int mileageBus1 = bus1.Mileage;
            bus1.IncreaseMileage(ref mileageBus1);
            bus1.Mileage = mileageBus1;
            Console.WriteLine($"\nУвеличить пробег автобуса bus1 на 1 км: {bus1.Mileage}");
            string driverNameBus1 = bus1.driverName;
            bus1.ChangeDriver(out driverNameBus1, "Петров А.В.");
            bus1.driverName = driverNameBus1;
            Console.WriteLine($"Изменить водителя автобуса bus1: {driverNameBus1}");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Информация о классе:");
            Bus.ShowClassInfo();


            /*Создайте массив объектов вашего типа. И выполните задание, 
            выделенное курсивом в таблице.*/
            Console.WriteLine("------------------------------------------");
            var buses = new Bus[5];
            buses[0] = new Bus("Иванов И.И.", 3097, 24,  1990, 201345);
            buses[1] = new Bus("Смирнов В.Ю", 2368, 44, 2030, 10248);
            buses[2] = new Bus("Свиягин А.М.", 9038, 91,  2000, 52334);
            buses[3] = new Bus("Андреева А.В.", 2418, 59,  2013, 21256);
            buses[4] = new Bus("Соколова Е.М.", 9341, 24, 2019, 2356);

            //список автобусов для заданного номера маршрута;
            foreach (var bus in buses)
                if (bus.RouteNum == 24)
                    Console.WriteLine($"Автобус номер {bus.BusNum} следует по маршруту 24");

            /*список автобусов, которые эксплуатируются больше
            заданного срока;*/
            Console.WriteLine("------------------------------------------");
            foreach (var bus in buses)
                if (bus.BusAge() >= 20)
                    Console.WriteLine($"Автобус номер {bus.BusNum} эксплуатируется больше 20 лет");
            Console.WriteLine("------------------------------------------");

            //создайте и выведите анонимный тип (по образцу вашего класса)
            var busDriver = new { Name = "Пильщиков", Surname = "Василий" };
            Console.WriteLine($"Имя водителя: {busDriver.Name}\n" +
                              $"Фамилия водителя: {busDriver.Surname}\n");
        }
    }
}

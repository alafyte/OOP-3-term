using System;

namespace Lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Написать демонстрационную программу, в которой создаются объекты 
            различных классов. Поработать с объектами через ссылки на абстрактные 
            классы и интерфейсы. В этом случае для идентификации типов объектов 
            использовать операторы is или as.*/

            Bench bench1 = new Bench("Скамейка №1");
            Inventory bench2 = new Bench("Скамейка №2");
            IUseInventory bench3 = new Bench("Скамейка №3");

            if (bench1 is Bench)
            {
                Console.WriteLine("bench1 это скамейка");
            }
            if (bench2 is Bench)
            {
                Console.WriteLine("bench2 это скамейка");
            }
            if (bench3 is Bench)
            {
                Console.WriteLine("bench3 это скамейка");
            }
            if ((bench1 as Inventory) != null)
            {
                Console.WriteLine("bench1 преобразован в инвентарь");
            }

            bench2.GetInventoryType();
            bench3.GetInventoryType(); 
            bench1.TakeItem();
            bench1.UseInventory();

            /*В демонстрационной программе создайте массив, содержащий ссылки на разнотипные объекты
            ваших классов по иерархии, а также объект класса Printer и последовательно 
            вызовите его метод IAmPrinting со всеми ссылками в качестве аргументов.*/
            Console.WriteLine("----------------------------------------------");

            var bench = new Bench("Скамейка 1");
            var mats = new Mats("Мат 1");
            var bars = new Bars("Брус 1");
            var ball = new BasketballBall("Баскетбольный мяч 1", 7);

            var inventoryItems = new Inventory[4];
            var printer = new Printer();

            inventoryItems[0] = bench;
            inventoryItems[1] = mats;
            inventoryItems[2] = bars;
            inventoryItems[3] = ball;

            foreach (var item in inventoryItems)
            {
                printer.IAmPrinting(item);
            }
        }
    }
}

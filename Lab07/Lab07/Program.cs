using System;


namespace Lab07
{
    class Program
    {
        static void Main(string[] args)
        {
            //2) Добавьте обработку исключений c finally. 
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("---------------Список типа sbyte---------------\n");
            try
            {
                List<sbyte> sbyteList = new List<sbyte>();
                sbyteList.Add(23);
                sbyteList.Add(100);
                sbyteList.Add(127);
                sbyteList.Remove(23);
                sbyteList.Remove(100);
                sbyteList.Remove(127);
                sbyteList.Remove(23);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Finally");
            }
            /*3) Проверьте использование обобщения для стандартных типов данных (в 
            качестве стандартных типов использовать целые, вещественные и т.д.). */
            Console.WriteLine("\n---------------Список типа char---------------\n");
            List<char> charList = new List<char>();
            charList.Add('A');
            charList.Add('B');
            charList.Add('C');
            charList.Add('D');
            charList.Add('E');
            charList.Show();
            Console.WriteLine("\n--------------Список типа double--------------\n");

            List<double> doubleList = new List<double>();
            doubleList.Add(1.276);
            doubleList.Add(93.786);
            doubleList.Add(4.475);
            doubleList.Add(344.475);
            doubleList.Show();
            Console.WriteLine("\n---------------Список типа int----------------\n");

            List<int> intList = new List<int>();
            intList.Add(10);
            intList.Add(20);
            intList.Add(30);
            intList.Add(40);
            intList.Show();
            Console.WriteLine("\n---------------Список типа Bars---------------\n");

            List<Bars> barsList = new List<Bars>();
            barsList.Add(new Bars("Брусья №12", 123));
            barsList.Add(new Bars("Брусья №13", 146));
            barsList.Add(new Bars("Брусья №14", 201));
            barsList.Add(new Bars("Брусья №15", 133));
            barsList.Show();
            Console.WriteLine("\n---------------Список типа Bars из JSON---------------\n");

            List<Bars> barsListJson = new List<Bars>();
            barsListJson.Add(new Bars("Брусья №200", 200));
            barsListJson.Add(new Bars("Брусья №300", 210));
            barsListJson.Add(new Bars("Брусья №400", 220));
            barsListJson.Add(new Bars("Брусья №500", 230));

            GenericsAndFiles.WriteList(barsListJson);
            List<Bars> testJson = new List<Bars>();
            GenericsAndFiles.ReadList(testJson);
            testJson.Show();
        }
    }
}

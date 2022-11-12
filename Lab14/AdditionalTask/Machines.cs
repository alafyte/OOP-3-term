using System;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace AdditionalTask
{
    /*На складе имеются товары (файл с записями). Создайте три потока - машины, 
      каждая машина имеет свою скорость загрузки/разгрузки. Разгрузите склад. 
      Обеспечьте последовательный доступ складу (только одна машина может 
      загружаться единовременно)*/
    public class Machine
    {
        private static string[,] Product = new string[3, 10];
        private static Mutex mutex = new Mutex();

        public static void Machine1()
        {
            const int number = 0;

            mutex.WaitOne();
            Console.WriteLine("\n--- Первая машина: разгрузка склада ---");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Unloading(200, number);


            stopwatch.Stop();
            Console.WriteLine($"Время, потраченное на разгрузку: {(double)stopwatch.ElapsedMilliseconds} мс\n\n");

            ///////////////////////////////////////////////////////////////////////////////////////////////////// 

            Console.WriteLine("\nЗагрузка...");
            stopwatch.Restart();

            Loading(300, number);

            stopwatch.Stop();
            Console.WriteLine($"Время, потраченное на загрузку: {(double)stopwatch.ElapsedMilliseconds} мс\n\n");
            mutex.ReleaseMutex();
        }
        public static void Machine2()
        {
            const int number = 1;
            mutex.WaitOne();

            Console.WriteLine("\n--- Вторая машина: разгрузка склада ---");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Unloading(400, number);

            stopwatch.Stop();
            Console.WriteLine($"Время, потраченное на разгрузку: {(double)stopwatch.ElapsedMilliseconds} мс\n\n");
            /////////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("\nЗагрузка...");

            stopwatch.Restart();

            Loading(600, number);

            stopwatch.Stop();
            Console.WriteLine($"Время, потраченное на загрузку: {(double)stopwatch.ElapsedMilliseconds} мс\n\n");
            mutex.ReleaseMutex();
        }
        public static void Machine3()
        {
            const int number = 2;
            mutex.WaitOne();

            Console.WriteLine("\n--- Третья машина: разгрузка склада ---");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Unloading(600, number);

            stopwatch.Stop();
            Console.WriteLine($"Время, потраченное на разгрузку: {(double)stopwatch.ElapsedMilliseconds} мс\n\n");

            //////////////////////////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("\nЗагрузка...");
            stopwatch.Restart();

            Loading(800, number);

            stopwatch.Stop();
            Console.WriteLine($"Время, потраченное на загрузку: {(double)stopwatch.ElapsedMilliseconds} мс\n\n");
            mutex.ReleaseMutex();
        }

        public static void Unloading(int sleep, int IndexMachine)
        {
            var product = File.ReadAllLines(@"C:\University\3_cем\ОOП\Lab14\AdditionalTask\Товары.txt");

            Console.WriteLine("Разгрузка склада началась");

            Console.WriteLine("Список товаров: ");

            for (int i = IndexMachine * 10; i < 10 * (IndexMachine + 1); i++)
            {
                Thread.Sleep(sleep);
                Product[IndexMachine, i - IndexMachine * 10] = product[i];
                Console.WriteLine("- " + product[i]);
            }
            Console.WriteLine("Разгрузка завершена");
        }

        public static void Loading(int sleep, int IndexMachine)
        {
            Console.WriteLine("Начата загрузка машины");
            Console.WriteLine("Список товаров: ");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(sleep);
                Console.WriteLine("* " + Product[IndexMachine, i]);
            }
            Console.WriteLine("Загрузка завершена");
        }
    }
}

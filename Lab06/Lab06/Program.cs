using System;
using System.IO;
using System.Diagnostics;

namespace Lab06
{
    class Program
    {
        /*2) Смоделируйте и обработайте как минимум пять различных 
        исключительных ситуаций на основе своих и стандартных исключений. 
        Например, не позволять при инициализации объектов передавать 
        неверные данные, обрабатывать ошибки при работе с памятью и ошибки 
        работы с файлами, деление на ноль, неверный индекс, нулевой указатель и т. д.*/
        /*6) Обработку исключений вынести в main. При обработке выводить 
        специфическую информацию о месте, диагностику и причине 
        исключения. Последним должен быть блок, который отлавливает все исключения (finally)*/
        static void Main(string[] args)
        {
            try 
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Inventory bench = new Bench("Скамейка №1", 1203);
            }
            catch (CostException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine($"Ошибка при создании экземляра класса {e.ErrorInClass}");
                Console.WriteLine($"Неверное значение: {e.Cost}");
            }
            Console.WriteLine("\n--------------------------------------\n");
            try
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Ball ball = new Ball("Футбольный мяч", 400, 9);
            }
            catch (BallSizeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine($"Ошибка при создании экземляра класса {e.ErrorInClass}");
                Console.WriteLine($"Неверное значение: {e.BallSize}");
            }
            Console.WriteLine("\n--------------------------------------\n");
            //3) В конце поставьте универсальный обработчик catch.
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                BasketballBall basketballBall = new BasketballBall("Баскетбольный мяч", 10, 50);
            }
            catch
            {
                Console.WriteLine("Неверные данные!");
            }
            Console.WriteLine("\n--------------------------------------\n");
            //4) Используйте классический вид try-catch-finally.
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                GymContainer gym = new GymContainer(300);
                Bars bars = new Bars("Брусья", 400);
                gym.AddItem(bars);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Console.WriteLine("Finally");
            }
         
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            GymContainer gym2 = new GymContainer(1000);
            try
            {
                GymController.CreateGymJSON(gym2);
            }
            catch (Exception ex)
            {
                //Пример работы с логгером
                Logger.WriteLogFileConsole(ex, true);
                Logger.WriteLogFileConsole(ex);
            }
            

            /*7)Добавьте в код макрос Assert. Объясните что он 
            проверяет, как будет выполняться программа в случае не выполнения 
            условия. Объясните назначение Assert. */
            //Inventory mat = new Mats("Мат", 120);
            //Debug.Assert(mat.Cost > 200, "Цена не может быть меньше 200");

        }
    }
}

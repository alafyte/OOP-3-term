using System;
using System.Threading;

namespace AdditionalTask
{
    /*Создайте пул ресурсов видеоканалов (класс) которых изначально меньше чем клиентов
    (класс), которые хотят ими воспользоваться. Каждый клиент получает доступ к 
    каналу, причем пользоваться можно только одним каналом. Если все каналы заняты, 
    то клиент ждет заданное время и по его истечении уходит не получив услуги. 
    (используйте средства синхронизации - семафор)*/
    class Client
    {
        Thread myThread;

        public Client(int i)
        {
            myThread = new Thread(Pull.Using);
            myThread.Name = $"Клиент {i}";
            myThread.Start();
        }

    }
    class Pull
    {
        static Semaphore sem = new Semaphore(4, 4);
        static int count = 4;
        public static void Using()
        {
            while (count > 0)
            {
                if (!sem.WaitOne(3000))
                {
                    Console.WriteLine($"Время ожидания клиента {Thread.CurrentThread.Name} истекло");
                    break;
                }

                Console.WriteLine($"{Thread.CurrentThread.Name} начал пользоваться каналом");

                Console.WriteLine($"{Thread.CurrentThread.Name} использует...");
                Thread.Sleep(1000);

                Console.WriteLine($"{Thread.CurrentThread.Name} прекратил использование канала");

                sem.Release();

                count--;
                Thread.Sleep(2000);
            }
        }
    }
}

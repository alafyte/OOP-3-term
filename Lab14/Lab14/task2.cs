using System;
using System.Threading;
using System.IO;

namespace Lab14
{
    public static class Task2
    {
        public static void EvenOdd(int n)
        {
            object locker = new();
            Thread.Sleep(n * 1000 / 3);
            Thread evenNum = new Thread(ShowEvenNumbers);
            Thread oddNum = new Thread(ShowOddNumbers);
            evenNum.Start(n);
            oddNum.Start(n);

            void ShowEvenNumbers(object n)
            { 
                bool acquiredLock = false;
                try
                {
                    Console.WriteLine("\n3-й поток");
                    Monitor.Enter(locker, ref acquiredLock);
                    using (StreamWriter sw = new StreamWriter(@"C:\University\3_cем\ОOП\Lab14\Lab14\task3.txt", true))
                    {
                        for (var i = 0; i < (int)n; i++)
                        {
                            Thread.Sleep(10);
                            if (i % 2 == 0)
                            {
                                Console.Write($"{i} ");
                                sw.Write($"{i} ");
                            }
                        }
                    }
                }
                finally
                {
                    if (acquiredLock)
                        Monitor.Exit(locker);
                }
            }
            void ShowOddNumbers(object n)
            {
                bool acquiredLock = false;
                try
                {
                    Console.WriteLine("4-й поток");
                    Monitor.Enter(locker, ref acquiredLock);
                    using (StreamWriter sw = new StreamWriter(@"C:\University\3_cем\ОOП\Lab14\Lab14\task3.txt", true))
                    {
                        for (var i = 0; i < (int)n; i++)
                        {
                            Thread.Sleep(10);
                            if (i % 2 != 0)
                            {
                                Console.Write($"{i} ");
                                sw.Write($"{i} ");
                            }
                        }
                    }
                }
                finally
                {
                    if (acquiredLock)
                        Monitor.Exit(locker);
                }
            }
        }

        public static void OneEvenOneOdd(int n)
        {
            Mutex mutex = new Mutex();

            Thread evenNum2 = new Thread(ShowEvenNumbers2);
            Thread oddNum2 = new Thread(ShowOddNumbers2);
            Thread.Sleep(n * 1000 / 2);
            evenNum2.Start(n);
            oddNum2.Start(n);

            void ShowEvenNumbers2(object n)
            {
                Console.WriteLine("\n5-й поток");
                for (var i = 0; i < (int)n; i++)
                {
                    mutex.WaitOne();
                    Thread.Sleep(10);
                    if (i % 2 == 0)
                    {
                        Console.Write($"{i} ");
                    }
                    mutex.ReleaseMutex();
                }
            }
            void ShowOddNumbers2(object n)
            {
                Console.WriteLine("6-й поток");
                for (var i = 0; i < (int)n; i++)
                {
                    mutex.WaitOne();
                    Thread.Sleep(10);
                    if (i % 2 != 0)
                    {
                        Console.Write($"{i} ");
                    }
                    mutex.ReleaseMutex();
                }
            }
        }
    }
}

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace Lab15
{
    class Program
    {
        static void Main(string[] args)
        {
            /*1. Используя TPL создайте длительную по времени задачу (на основе
           Task) на выбор:
           Задача: создание множества Мандельброта*/

            var task = new Task<int>(() => MandelbrotSet());
            
            Console.WriteLine($"Задача №{task.Id} статус - {task.Status}");

            var stopwatch = new Stopwatch();
            task.Start();
            stopwatch.Start();
            Console.WriteLine($"Задача №{task.Id} статус - {task.Status}");
            task.Wait();
            stopwatch.Stop();
            Console.WriteLine($"Задача №{task.Id} статус - {task.Status}");
            Console.WriteLine($"Задача - время выполнения: {stopwatch.ElapsedMilliseconds} мс ");
            Console.WriteLine($"Кол-во итераций подсчета элементов множества Мандельброта: {task.Result}");

            stopwatch.Restart();
            int mainThreadResult = MandelbrotSet();
            stopwatch.Stop();
            Console.WriteLine($"Время выполнения последовательного алгоритма: {stopwatch.ElapsedMilliseconds} мс ");
            Console.WriteLine($"Кол-во итераций подсчета элементов множества Мандельброта: {mainThreadResult}\n");

            /*2. Реализуйте второй вариант этой же задачи с токеном отмены 
            CancellationToken и отмените задачy*/
            var cancellationToken = new CancellationTokenSource();

            Task second = Task.Factory.StartNew(MandelbrotSetWithCancellation, cancellationToken.Token, cancellationToken.Token);
            try
            {
                cancellationToken.Cancel();
                second.Wait();
            }
            catch (AggregateException e)
            {
                if (second.IsCanceled)
                    Console.WriteLine($"{second.Id} задача была отменена\n");
            }

            /*3. Создайте три задачи с возвратом результата и используйте их для 
            выполнения четвертой задачи. Например, расчет по формуле.*/

            double a = new Random().Next(1, 9);
            double b = new Random().Next(0, 9);
            var asqr = new Task<double>(() => Math.Pow(a, 2));
            var twoab = new Task<double>(() => 2 * a* b);
            var bsqr = new Task<double>(() => Math.Pow(b, 2));

            asqr.Start();
            twoab.Start();
            bsqr.Start();
            bsqr.Wait();
            asqr.Wait();
            twoab.Wait();

            var aPlusbInSquare = new Task<double>(() => asqr.Result + twoab.Result + bsqr.Result);
            aPlusbInSquare.Start();
            Console.WriteLine($"(a + b)^2, где a = {a}, b = {b} => {aPlusbInSquare.Result}\n");

            /*4. Создайте задачу продолжения (continuation task) в двух вариантах:
            1) C ContinueWith - планировка на основе завершения множества 
                предшествующих задач
            2) На основе объекта ожидания и методов GetAwaiter(),GetResult();*/

            var expr1 = new Task<int>(() => 1 + 10 / 5 % 10 - 100 * 8 );
            var showSum = expr1.ContinueWith(s => Console.WriteLine($"Результат1: {expr1.Result}"));
            expr1.Start();

            var expr2 = new Task<int>(() => 1203 - 76 * 4 / (9 + 45));

            var awaiterCountFor = expr2.GetAwaiter();
            awaiterCountFor.OnCompleted(() =>
            {
                awaiterCountFor.GetResult();
                Console.WriteLine($"Результат2: {expr2.Result}\n");
            });
            expr2.Start();
            expr2.Wait();

            /*5. Используя Класс Parallel распараллельте вычисления циклов For(),
            ForEach(). Например, на выбор: обработку (преобразования)
            последовательности, генерация нескольких массивов по 1000000 
            элементов, быстрая сортировка последовательности, обработка текстов
            (удаление, замена). Оцените производительность по сравнению с обычными циклами*/
            var array1 = new int[10000000];
            var array2 = new int[10000000];
            var array3 = new int[10000000];

            var stopwatch5 = new Stopwatch();

            stopwatch5.Start();
            Parallel.For(0, 10000000, CreatingArrayElements);
            stopwatch5.Stop();
            Console.WriteLine($"Распараллеленный For: {stopwatch5.ElapsedMilliseconds} мс");

            stopwatch5.Restart();
            for (var i = 0; i < 10000000; i++)
            {
                array1[i] = 1;
                array2[i] = 1;
                array3[i] = 1;
            }

            stopwatch5.Stop();
            Console.WriteLine($"Обычный For: {stopwatch5.ElapsedMilliseconds} мс");


            int sum5 = 0;
            stopwatch5.Restart();
            Parallel.ForEach(array1, SumOfElements);
            stopwatch5.Stop();
            Console.WriteLine($"Распараллеленный ForEach {stopwatch5.ElapsedMilliseconds} мс");

            sum5 = 0;
            stopwatch5.Restart();
            foreach (int item in array1) 
                sum5 += item;
            stopwatch5.Stop();
            Console.WriteLine($"Обычный ForEach {stopwatch5.ElapsedMilliseconds} ms");

            void CreatingArrayElements(int x)
            {
                array1[x] = 2;
                array2[x] = 2;
                array3[x] = 2;
            }

            void SumOfElements(int item)
            {
                sum5 += item;
            }

            /*6. Используя Parallel.Invoke() распараллельте выполнение блока операторов.*/
            var array16 = new int[10000000];
            var array26 = new int[10000000];
            var array36 = new int[10000000];


            Parallel.Invoke
            (

                () =>
                {
                    for (var i = 0; i < array16.Length; i++)
                    {
                        array16[i] = i;
                    }
                },
                () =>
                {
                    for (var i = 0; i < array26.Length; i++)
                    {
                        array26[i] = i;
                    }
                },
                () =>
                {
                    for (var i = 0; i < array36.Length; i++)
                    {
                        array36[i] = i;
                    }
                }
            );

            /*7. Используя Класс BlockingCollection реализуйте следующую задачу:
                Есть 5 поставщиков бытовой техники, они завозят уникальные товары 
                на склад (каждый по одному) и 10 покупателей – покупают все подряд, 
                если товара нет - уходят. В вашей задаче: cпрос превышает 
                предложение. Изначально склад пустой. У каждого поставщика своя 
                скорость завоза товара. Каждый раз при изменении состоянии склада
                выводите наименования товаров на складе.*/
            Console.WriteLine();
            BlockingCollection<string> bc = new BlockingCollection<string>(5);

            //5 поставщиков
            Task[] sellers = new Task[5]
            {
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(700);
                        bc.Add("Посудомоечная машина");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(400);
                        bc.Add("Миксер");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(500);
                        bc.Add("Стиральная машина");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(300);
                        bc.Add("Микроволновая печь");
                    }
                }),
                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(700);
                        bc.Add("Робот-пылесос");
                    }
                })
            };

            foreach (var i in sellers)
                if (i.Status != TaskStatus.Running)
                    i.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Количество товара на складе: {bc.Count}");
                Thread.Sleep(600);
                Thread thr = new Thread(Client);
                thr.Start();
            }

            void Client()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (bc.Count == 0)
                {
                    Console.WriteLine("Покупатель ушёл, ничего не купив");
                    return;
                }
                Console.WriteLine($"Покупатель купил {bc.Take()}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            /*8. Используя async и await организуйте асинхронное выполнение любого 
            метода.*/
            Thread.Sleep(1000);
            Console.WriteLine();
            int Fibonacci(int n)
            {
                if (n == 0 || n == 1)
                {
                    return n;
                }

                Thread.Sleep(100);
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }

            async void FibonacciAsync(int n)
            {
                Console.WriteLine($"Начат подсчет {n}-го числа Фибоначчи");
                var result = Task<int>.Factory.StartNew(() => Fibonacci(n));
                int value = await result;
                Console.WriteLine($"Результат: {value}");
            }

            FibonacciAsync(7);
            Console.ReadKey();
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
     
        private static int MandelbrotSet()
        {
            int xMax = 800, yMax = 800;
            int maxIterations = 500;
            Complex zk = new Complex(0, 0);
            int count = 0;
            for (double y = 0; y < yMax; y += 0.1)
                for (double x = 0; x < xMax; x += 0.1)
                {
                    Complex c = new Complex(x, y);
                    int k = 0;
                    do
                    {
                        zk = Complex.Pow(zk, 2) + c;
                        k++;
                        count++;
                    } while ((zk.Magnitude <= 2.0) && (k < maxIterations));
                }
            
            return count;
        }
        private static int MandelbrotSetWithCancellation(object obj)
        {
            int xMax = 800, yMax = 800;
            int maxIterations = 500;
            var token = (CancellationToken)obj;
            Complex zk = new Complex(0, 0);
            int count = 0;
            for (double y = 0; y < yMax; y += 0.1)
                for (double x = 0; x < xMax; x += 0.1)
                {
                    Complex c = new Complex(x, y);
                    int k = 0;
                    do
                    {
                        if (token.IsCancellationRequested)
                        {
                            Console.WriteLine("Запрос отмены");
                            token.ThrowIfCancellationRequested();
                            return 0;
                        }
                        zk = Complex.Pow(zk, 2) + c;
                        k++;
                        count++;
                    } while ((zk.Magnitude <= 2.0) && (k < maxIterations));
                }

            return count;
        }
    }
}

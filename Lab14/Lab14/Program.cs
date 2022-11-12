using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Lab14
{
    class Program
    {
        static void Main(string[] args)
        {
            /*1) Определите и выведите на консоль/в файл все запущенные процессы:id, имя, приоритет, 
            время запуска, текущее состояние, сколько всего времени использовал процессор и т.д*/
            var allProcess = Process.GetProcesses();
            foreach (var process in allProcess)
            {
                try
                {
                    Console.WriteLine(
                        $"ID: {process.Id}\n" +
                        $"Имя процесса: {process.ProcessName}\n" +
                        $"Приоритет: {process.BasePriority}\n" +
                        $"VirtualMemorySize64: {process.VirtualMemorySize64}\n" +
                        $"Время запуска: {process.StartTime}\n" +
                        $"Cколько всего времени использовал процессор: {process.TotalProcessorTime}\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            /*2) Исследуйте текущий домен вашего приложения: имя, детали конфигурации, все сборки,
            загруженные в домен. Создайте новый домен. Загрузите туда сборку. Выгрузите домен.*/
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Имя домена: {domain.FriendlyName}");
            Console.WriteLine($"Детали конфигурации: {domain.SetupInformation}");
            Console.WriteLine($"Все сборки: ");
            Assembly[] assemblies = domain.GetAssemblies();
            foreach (Assembly asm in assemblies)
                Console.WriteLine(asm.GetName().Name);
            Console.WriteLine();

            try
            {
                AppDomain newD = AppDomain.CreateDomain("Новый домен");
                newD.Load(@"C:\University\3_cем\ОOП\Lab13\Lab13\obj\Debug\netcoreapp3.1\Lab13.dll");
                AppDomain.Unload(newD);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }

            /*3) Создайте в отдельном потоке следующую задачу расчета (можно сделать sleep для 
            задержки) и записи в файл и на консоль простых чисел от 1 до n (задает пользователь). 
            Вызовите методы управления потоком (запуск, приостановка, возобновление и т.д.) Во 
            время выполнения выведите информацию о статусе потока, имени, приоритете, числовой 
            идентификатор и т.д.*/

            var firstThread = new Thread(ThreadInfo);
            firstThread.Start(Thread.CurrentThread);
            Thread.Sleep(1000);
            int n;
            Console.WriteLine("Введите n");
            n = int.Parse(Console.ReadLine());

            using (StreamWriter sw = new StreamWriter(@"C:\University\3_cем\ОOП\Lab14\Lab14\task2.txt", false))
            {
                for (var i = 1; i <= n; i++)
                {
                    var isSimple = true;
                    for (var j = 2; j <= i / 2; j++)
                        if (i % j == 0)
                        {
                            isSimple = false;
                            break;
                        }

                    if (isSimple)
                    {
                        Console.Write($"{i} ");
                        sw.Write($"{i} ");
                    }
                }
            }
            void ThreadInfo(object thread)
            {
                var currentThread = thread as Thread;
                Console.WriteLine($"Имя потока: {currentThread.Name}");
                Console.WriteLine($"Id: {currentThread.ManagedThreadId}");
                Console.WriteLine($"Приоритет: {currentThread.Priority}");
                Console.WriteLine($"Статус: {currentThread.ThreadState}");
            }

            /*4) Создайте два потока. Первый выводит четные числа, второй нечетные до n и 
            записывают их в общий файл и на консоль. Скорость расчета чисел у потоков – разная.
            a. Поменяйте приоритет одного из потоков. 
            b. Используя средства синхронизации организуйте работу потоков, таким образом, чтобы:
                i. выводились сначала четные, потом нечетные числа
                ii. последовательно выводились одно четное, другое нечетное. */
            Console.WriteLine("\n");
            Console.WriteLine("Введите n");
            n = int.Parse(Console.ReadLine());
            Thread evenThread = new Thread(ShowEvenNumbers) { Priority = ThreadPriority.Highest }; ;
            Thread oddThread = new Thread(ShowOddNumbers);
            evenThread.Start(n);
            oddThread.Start(n);

            void ShowEvenNumbers(object n)
            {
                Console.WriteLine("1-й поток");
                for (var i = 0; i < (int)n; i++)
                {
                    Thread.Sleep(10);
                    if (i % 2 == 0)
                    {
                        Console.Write($"{i} ");
                    }
                }
            }
            void ShowOddNumbers(object n)
            {
                Console.WriteLine("2-й поток");
                for (var i = 0; i < (int)n; i++)
                {
                    Thread.Sleep(60);
                    if (i % 2 != 0)
                    {
                        Console.Write($"{i} ");
                    }
                }
            }

            //четные, потом нечетные
            Task2.EvenOdd(n);
            //одно четное - одно нечетное
            Task2.OneEvenOneOdd(n);

            //5) Придумайте и реализуйте повторяющуюся задачу на основе класса Timer
            TimerCallback tm = new TimerCallback(ShowCurrenrTime);
            Timer timer = new Timer(tm, null, 1000, 1000);
            Thread.Sleep(6000);

            void ShowCurrenrTime(object obj)
            {
                Console.WriteLine($"\nТекущее время - {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}");
            }
        }
    }
}

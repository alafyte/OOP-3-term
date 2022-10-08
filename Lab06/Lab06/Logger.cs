using System;
using System.IO;

namespace Lab06
{
    static class Logger
    {
        /*1) Создайте класс Logger, который будет заниматься логгированием 
        различных событий и исключений. Логгер должен уметь логгировать 
        ошибки/исключения, предупреждения и просто какую-то информацию. 
        2) Логгер должен записывать лог в виде: время, тип_записи_лога: 
        дополнительное сообщение. 27.10.2019 02:36, INFO: Test log message. 
        3) Создайте 2 реализации логгера: FileLogger и ConsoleLogger. FileLogger
        будет записывать сообщения лога в файл, добавляя записи к уже существующим. 
        ConsoleLogger – выводить сообщения на консоль. 
        4) Добавьте в классы из л.р. 6 логгер так, чтобы его возможно было быстро 
        заменить во время выполнения другим и вместо простого вывода на консоль 
        сообщения об ошибке, используйте свой логгер.*/

        public static void WriteLogFileConsole(Exception e, bool fileFlag = false)
        {
            if (fileFlag)
                FileLogger(e);
            else
                ConsoleLogger(e);
        }
        private static void FileLogger(Exception e)
        {
            using var stream = new StreamWriter(@"C:\University\3_cем\ОOП\Lab06\Lab06\Log.txt", true);
            stream.WriteLine($"------------{DateTime.Now}------------");
            stream.WriteLine($"TYPE: {e.GetType()}");
            stream.WriteLine($"INFO: {e.Message}");
        }
        private static void ConsoleLogger(Exception e)
        {
            Console.WriteLine($"------------{DateTime.Now}------------");
            Console.WriteLine($"TYPE: {e.GetType()}");
            Console.WriteLine($"INFO: {e.Message}");
        }
    }
}

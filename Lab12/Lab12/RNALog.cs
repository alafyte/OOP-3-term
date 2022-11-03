using System;
using System.IO;
using System.Text;

namespace Lab12
{
    /*1. Создать класс XXXLog. Он должен отвечать за работу с текстовым файлом
    xxxlogfile.txt. в который записываются все действия пользователя и 
    соответственно методами записи в текстовый файл, чтения, поиска нужной 
    информации.
        a. Используя данный класс выполните запись всех последующих действиях пользователя с указанием действия, 
        детальной информации (имя файла, путь) и времени (дата/время) */
    public static class RNALog
    {
        private static StreamWriter logfile;
        private static string pathLog = @"C:\University\3_cем\ОOП\Lab12\Lab12\RNALogfile.txt";
        public static void WriteInLog(string action, string fileName = "", string path = "")
        {
            if (fileName.Length != 0 && path.Length != 0)
            {
                using (logfile = new StreamWriter(pathLog, true))
                {
                    logfile.WriteLine($"{DateTime.Now.ToString()}");
                    logfile.WriteLine($"Действие: {action}");
                    logfile.WriteLine($"Имя файла: {fileName}");
                    logfile.WriteLine($"Путь к файлу: {path}");
                    logfile.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
                }
            }
            else
            {
                using (logfile = new StreamWriter(pathLog, true))
                {
                    logfile.WriteLine($"{DateTime.Now.ToString()}");
                    logfile.WriteLine($"Действие: {action}");
                    logfile.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
                }
            }
        }

        /*6. Найдите и выведите сохраненную информацию в файле xxxlogfile.txt о действиях пользователя за определенный день/ 
           * диапазон времени/по ключевому слову. Посчитайте количество записей в нем. Удалите часть информации, 
           * оставьте только записи за текущий час.*/
        public static void FindInfo()
        {
            var output = new StringBuilder();

            using (var stream = new StreamReader(pathLog))
            {
                var textline = "";
                var isActual = false;
                while (!stream.EndOfStream)
                {
                    isActual = false;
                    textline = stream.ReadLine();
                    if (textline != "" && DateTime.Parse(textline).Day == DateTime.Now.Day)
                    {
                        isActual = true;
                        textline += Environment.NewLine;
                        output.AppendFormat(textline);
                    }

                    textline = stream.ReadLine();
                    while (textline != "▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬")
                    {
                        if (isActual)
                        {
                            textline += Environment.NewLine;
                            output.AppendFormat(textline);
                        }

                        textline = stream.ReadLine();
                    }

                    if (isActual)
                    {
                        output.AppendFormat("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
                        output.AppendFormat(Environment.NewLine);
                    }
                }
            }

            using (var stream = new StreamWriter(@"C:\University\3_cем\ОOП\Lab12\Lab12\LogV2.txt"))
            {
                stream.WriteLine(output.ToString());
            }
        }
    }
}

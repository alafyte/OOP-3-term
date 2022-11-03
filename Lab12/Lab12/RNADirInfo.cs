using System;
using System.IO;

namespace Lab12
{
    public static class RNADirInfo
    {
        /*4. Создать класс XXXDirInfo c методами для вывода информации о конкретном директории
            a. Количестве файлов
            b. Время создания
            c. Количестве поддиректориев
            d. Список родительских директориев
            e. Продемонстрируйте работу класса*/
        public static void WriteDirInfo(string dirName)
        {
            if (Directory.Exists(dirName))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                Console.WriteLine($"Количество файлов: {dirInfo.GetFiles().Length}\n" +
                    $"Время создания: {dirInfo.CreationTime}\n" +
                    $"Количество поддиректориев: {dirInfo.GetDirectories().Length}\n" +
                    $"Список родительских директориев: {dirInfo.Parent}");
            }
            else
                throw new ArgumentException();
        }
    }
}

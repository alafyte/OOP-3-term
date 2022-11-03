using System;
using System.IO;
using System.Linq;

namespace Lab12
{
    /*3. Создать класс XXXFileInfo c методами для вывода информации о конкретном файле
        a. Полный путь 
        b. Размер, расширение, имя
        c. Дата создания, изменения
        d. Продемонстрируйте работу класса*/
    public static class RNAFileInfo
    {
        public static void WriteFileInfo(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                Console.WriteLine($"Полный путь к файлу {fileInfo.Name}: {fileInfo.FullName}\n" +
                    $"Размер: {fileInfo.Length}\n" +
                    $"Расширение: {fileInfo.Extension}\n" +
                    $"Дата создания: {fileInfo.CreationTime}\n" +
                    $"Дата изменения: {fileInfo.LastWriteTime}");
            }
            else
                throw new FileNotFoundException();
        }
    }
}

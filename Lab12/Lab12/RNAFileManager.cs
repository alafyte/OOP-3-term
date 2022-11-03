using System.IO.Compression;
using System.IO;
using System.Linq;

namespace Lab12
{
    /*5. Создать класс XXXFileManager. Набор методов определите самостоятельно. С его помощью выполнить следующие действия:
        a. Прочитать список файлов и папок заданного диска. Создать директорий XXXInspect, создать текстовый файл 
        xxxdirinfo.txt и сохранить туда информацию. Создать копию файла и переименовать его. Удалить первоначальный файл.
        b. Создать еще один директорий XXXFiles. Скопировать в него все файлы с заданным расширением из заданного 
        пользователем директория. Переместить XXXFiles в XXXInspect.
        c. Сделайте архив из файлов директория XXXFiles. Разархивируйте его в другой директорий.*/
    public static class RNAFileManager
    {
        public static void InspectDriver(string driverName)
        {
            Directory.CreateDirectory(@"C:\University\3_cем\ОOП\Lab12\Lab12\RNAInspect");
            File.Create(@"C:\University\3_cем\ОOП\Lab12\Lab12\RNAInspect\RNAdirinfo.txt").Close();
            var currentDrive = DriveInfo.GetDrives().Single(x => x.Name == driverName);

            using (StreamWriter file = new StreamWriter(@"C:\University\3_cем\ОOП\Lab12\Lab12\RNAInspect\RNAdirinfo.txt"))
            {
                file.WriteLine("Список папок:");
                foreach (var s in currentDrive.RootDirectory.GetDirectories())
                {
                    file.WriteLine(s);
                }
                file.WriteLine("Список файлов:");
                foreach (var f in currentDrive.RootDirectory.GetFiles())
                {
                    file.WriteLine(f);
                }
            }

            File.Copy(@"C:\University\3_cем\ОOП\Lab12\Lab12\RNAInspect\RNAdirinfo.txt", @"C:\University\3_cем\ОOП\Lab12\Lab12\RNAInspect\RNAdirinfoCopy.txt", true);
            File.Delete(@"C:\University\3_cем\ОOП\Lab12\Lab12\RNAInspect\RNAdirinfo.txt");
        }

        public static void CopyFiles(string path, string extention)
        {
            Directory.CreateDirectory(@"C:\University\3_cем\ОOП\Lab12\Lab12\RNAFiles");
            DirectoryInfo directory = new DirectoryInfo(path);
            DirectoryInfo directory2 = new DirectoryInfo(@"C:\University\3_cем\ОOП\Lab12\Lab12\RNAInspect\RNAFiles\");
            foreach (var f in directory.GetFiles())
            {
                if (f.Extension == extention)
                    f.CopyTo(@"C:\University\3_cем\ОOП\Lab12\Lab12\RNAFiles\" + f.Name + extention, true);
            }
            if (!directory2.Exists)
                Directory.Move(@"C:\University\3_cем\ОOП\Lab12\Lab12\RNAFiles\", @"C:\University\3_cем\ОOП\Lab12\Lab12\RNAInspect\RNAFiles\");
            else
                Directory.Delete(@"C:\University\3_cем\ОOП\Lab12\Lab12\RNAFiles\", true);
        }

        public static void CreateArchive(string dir)
        {
            string name = @"C:\University\3_cем\ОOП\Lab12\Lab12\RNAInspect\RNAFiles";
            if (new DirectoryInfo(@"C:\University\3_cем\ОOП\Lab12\Lab12\RNAInspect").GetFiles("*.zip").Length == 0)
            {
                ZipFile.CreateFromDirectory(name, name + ".zip");
                DirectoryInfo direct = new DirectoryInfo(dir);
                foreach (var innerFile in direct.GetFiles())
                    innerFile.Delete();
                direct.Delete();
                ZipFile.ExtractToDirectory(name + ".zip", dir);
            }
        }
    }
}

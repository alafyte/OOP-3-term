using System;
using System.IO;
using System.Linq;

namespace Lab12
{
    /*2. Создать класс XXXDiskInfo c методами для вывода информации о
        a. свободном месте на диске
        b. Файловой системе
        c. Для каждого существующего диска - имя, объем, доступный объем, метка тома.
        d. Продемонстрируйте работу класса */
    public static class RNADiskInfo
    {
        public static void WriteDiskInfo(string driverName)
        {
            var driver = DriveInfo.GetDrives().Single(d => d.Name == driverName);
            Console.WriteLine($"Имя диска: {driver.Name}");
            Console.WriteLine($"Свободное место на диске: {driver.TotalFreeSpace}");
            Console.WriteLine($"Файловая система: {driver.DriveFormat}");
            Console.WriteLine($"Тип диска: {driver.DriveType}");
            Console.WriteLine($"Метка тома: {driver.VolumeLabel}");
            Console.WriteLine($"Объём: {driver.TotalSize}");
            Console.WriteLine($"Доступный объём: {driver.AvailableFreeSpace}");
        }
    }
}

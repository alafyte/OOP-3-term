using System;

namespace Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("*****************************************************************************************************");
                RNADiskInfo.WriteDiskInfo("C:\\");
                RNALog.WriteInLog("RNADiskInfo.getFreeDrivesSpace()");

                Console.WriteLine("******************************************************************************************************");
                RNAFileInfo.WriteFileInfo(@"C:\University\3_cем\ОOП\Lab12\12_Потоки_файловая система.pdf");
                RNALog.WriteInLog("RNAFileInfo.WriteFileInfo()", "RNALogfile.txt", @"C:\University\3_cем\ОOП\Lab12\RNALogfile.txt");

                Console.WriteLine("******************************************************************************************************");
                RNADirInfo.WriteDirInfo(@"C:\University\3_cем\ОOП");
                RNALog.WriteInLog("RNADirInfo.WriteDirInfo()", @"C:\University\3_cем\ОOП");

                RNAFileManager.InspectDriver("C:\\");
                RNALog.WriteInLog("RNAFileManager.InspectDriver()", "C:\\");
                RNAFileManager.CopyFiles(@"C:\University\3_cем\ТРПИ", ".docx");
                RNALog.WriteInLog("RNAFileManager.CopyFiles()", @"C:\University\3_cем\ТРПИ");
                RNAFileManager.CreateArchive(@"C:\University\3_cем\ОOП\Lab12\Lab12\ForArchive");
                RNALog.WriteInLog(" RNAFileManager.CreateArchive()");

                RNALog.FindInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
